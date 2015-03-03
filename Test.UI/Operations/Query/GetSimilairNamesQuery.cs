using Test.UI.Operations.Entity;

namespace Test.UI.Operations
{
    using System.Collections.Generic;
    using System.Linq;
    using Incoding.CQRS;

    public class GetSimilairNamesQuery : QueryBase<List<GetCustomersQuery.Response>>

    {
        public string RequiredName { get; set; }
        public class Response
        {
            public string Result { get; set; }
        }

        protected override List<GetCustomersQuery.Response> ExecuteResult()
        {
            List<User> Customers = Repository.Query<User>().ToList();
            return
                Customers.Where(customer => customer.Name.Contains(RequiredName))
                    .Select(customer => new GetCustomersQuery.Response() {Name = customer.Name,Sername = "asdasdasda"}).ToList();


        }


    }
}