namespace Test.UI.Operations
{
    using System.Collections.Generic;
    using System.Linq;
    using Incoding.CQRS;

    public class GetCustomersQuery : QueryBase<List<GetCustomersQuery.Response>>
    {
        public class Response
        {
            public string Name { get; set; }
            public string sdfsdurname { get; set; }



        }

        protected override List<Response> ExecuteResult()
        {


            List<Customer> ttt = Repository.Query<Customer>()
                             .ToList();
            List<Response> fff = new List<Response>();
            foreach (var customer in ttt)
            {
                fff.Add(new Response()
                {
                    Name = customer.Name ,
                    sdfsdurname = customer.Surname

                });
            }
      

            return fff;
        }


    }
}