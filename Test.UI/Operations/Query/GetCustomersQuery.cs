using System;
using System.Collections.Generic;
using System.Linq;
using Incoding.CQRS;
using Test.UI.Operations.Entity;

namespace Test.UI.Operations
{
    public class GetCustomersQuery : QueryBase<List<GetCustomersQuery.Response>>
    {
        public class Response
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Sername { get; set; }
            public string Count { get; set; }
            public string Price { get; set; }
            public DateTime Start_time { get; set; }        
        }

        protected override List<Response> ExecuteResult()
        {
            List<User> uuu = Repository.Query<User>().ToList();
            List<TimeTrack> tt = Repository.Query<TimeTrack>().ToList();
            List<Response> fff = new List<Response>();

            foreach (var customer in uuu)
            {
                fff.Add(new Response()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Sername = customer.Sername
                });
            }
            foreach (var cus in tt)
            {
                fff.Add(new Response()
                {
                    Count = cus.Count,
                    Price = cus.Price,
                    Start_time = cus.StartTime

                });
            }

            return fff;
        }
    }
}