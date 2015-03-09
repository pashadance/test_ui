using System;
using Test.UI.Operations.Entity;
using Test.UI.Operations.Query;

namespace Test.UI.Operations
{
    using System.Collections.Generic;
    using System.Linq;
    using Incoding.CQRS;

    public class GetSimilarSernamesQuery : QueryBase<GetSimilarSernamesQuery.SimilarResponse>
    {
        public string RequiredName { get; set; }

        public class SimilarResponse
        {
            public string ResultSername { get; set; }
            public string ResultName { get; set; }
            public string ResultFathername { get; set; }
        }

        protected override SimilarResponse ExecuteResult()
        {
            SimilarResponse slresp = new SimilarResponse();

            List<User> users = Repository.Query<User>().ToList();

            foreach (var user in users)
            {
                if (user.Sername.Substring(0, RequiredName.Length).ToLower() == RequiredName.ToLower())
                {
                    slresp.ResultSername = user.Sername;
                    slresp.ResultName = user.Name;
                    slresp.ResultFathername = user.FatherName;
                    break;
                }
            }
           // if (slresp.Result == null)
          //  {
          //      slresp.Result = RequiredName ;
         //   }
            return slresp;
        }
    }
}