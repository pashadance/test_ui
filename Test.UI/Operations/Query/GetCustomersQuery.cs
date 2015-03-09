using System.Collections.Generic;
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
        }

        protected override List<Response> ExecuteResult()
        {
            List<Response> resp = new List<Response>();

            List<TimeTrack> tt = Repository.Query<TimeTrack>().ToList();
            foreach (var timetrack in tt)
            {
                if (timetrack.Active)
                    resp.Add(new Response()
                    {
                        IdUser = timetrack.User.Id,
                        Id = timetrack.Id,
                        Count = timetrack.Count,
                        Price = timetrack.Price,
                        Start_time = timetrack.StartTime.ToString().Substring(timetrack.StartTime.ToString().IndexOf(" "))
                    });
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
            return resp;
        }
    }
}