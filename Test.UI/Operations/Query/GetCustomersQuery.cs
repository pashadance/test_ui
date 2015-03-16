using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Incoding.CQRS;
using Test.UI.Operations.Entity;

namespace Test.UI.Operations.Query
{
    public class GetCustomersQuery : QueryBase<List<GetCustomersQuery.Response>>
    {
        public class Response
        {
            public string Id { get; set; }
            public string IdUser { get; set; }
            public string Sername { get; set; }
            public string Name { get; set; }
            public string FatherName { get; set; }
            public string Count { get; set; }
            public string Price { get; set; }
            public string Start_time { get; set; }
            public string Period { get; set; }
            public string PeriodColor { get; set; } 
        }

        protected override List<Response> ExecuteResult()
        {
            CultureInfo ci = new CultureInfo("ru-RU");
            string stime = "";
            List<Response> resp = new List<Response>();

            List<TimeTrack> tt = Repository.Query<TimeTrack>().ToList();
            foreach (var timetrack in tt)
            {
                    if (timetrack.Period != "час" & timetrack.Active)
                    {
                        stime = timetrack.StartTime.Day.ToString() + "." + timetrack.StartTime.Month.ToString() + "." +
                                timetrack.StartTime.Year.ToString() + " " + timetrack.StartTime.ToString("T", ci);
                        resp.Add(new Response()
                        {
                            IdUser = timetrack.User.Id,
                            Id = timetrack.Id,
                            Count = timetrack.Count,
                            Price = timetrack.Price,
                            Start_time = stime,
                            Period = timetrack.Period,
                            PeriodColor = "#000030"
                        });
                    }
                    if (timetrack.Period == "час" & timetrack.Active)
                    {
                        stime = timetrack.StartTime.ToString("T", ci);
                        resp.Add(new Response()
                        {
                            IdUser = timetrack.User.Id,
                            Id = timetrack.Id,
                            Count = timetrack.Count,
                            Price = timetrack.Price,
                            Start_time = stime,
                            Period = timetrack.Period,
                            PeriodColor = "#E04F00"
                        });
                    }
            }

            List<User> u = Repository.Query<User>().ToList();
            
            foreach (var r in resp)
            {
                foreach (var user in u)
                {
                    if (r.IdUser == user.Id)
                    {
                        r.Sername = user.Sername;
                        r.Name = user.Name;
                        r.FatherName = user.FatherName;
                    }
                }
            }
            resp.Sort((a,b)=>a.Start_time.CompareTo(b.Start_time));
            return resp;
        }
    }
}