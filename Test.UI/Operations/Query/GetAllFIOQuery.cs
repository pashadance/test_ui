using System.Collections.Generic;
using System.Linq;
using Incoding.CQRS;
using Test.UI.Operations.Entity;

namespace Test.UI.Operations.Query
{
    public class GetAllFIOQuery : QueryBase<List<GetAllFIOQuery.FIO>>
    {
        public class FIO
        {
            public string Sername { get; set; }
            public string Name { get; set; }
            public string FatherName { get; set; }
            public string FamiliaIO { get; set; }
            public string IDUser { get; set; }
        }

        protected override List<FIO> ExecuteResult()
        {            
            string  N = "";
            string F = "";
            string S = ""; 
            List<FIO> listfio = new List<FIO>();
            List<User> users = Repository.Query<User>().ToList();

            foreach (var user in users)
            {
                S = user.Sername + " ";
                N = user.Name.Substring(0, 1) + ".";
                if (user.FatherName != "")
                    F = user.FatherName.Substring(0, 1) + ".";
                else
                    F = "-.";

                listfio.Add(new FIO()
                {
                    FamiliaIO = S+N+F,
                    Sername = user.Sername,
                    Name = user.Name,
                    FatherName = user.FatherName,
                    IDUser = user.Id
                });
            }
            listfio.Sort((a, b) => a.Sername.CompareTo(b.Sername));
            return listfio;
        }
    }
}