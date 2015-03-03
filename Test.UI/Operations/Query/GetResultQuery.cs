using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Incoding.CQRS;
using Test.UI.Operations.Command;

namespace Test.UI.Operations.Query
{
    public class GetResultQuery : CommandBase
    {
       
        public override void Execute()
        {
            //Result r = new Result();
            /*{
                Name = Name,
                Sername = old.Sername,
                Count = old.Count,
                Price = old.Price,
                Start_time = old.Start_time,
                End_time = old.End_time
            };*/
           //return r;
        }
        /*@(Html.When(JqueryBind.InitIncoding)
                        
                        .AjaxPost(Url.Dispatcher().Push(new GetResultQuery.Result()
                              {
                                 Name = each.For(r => r.Name),
                                 Sername  = each.For(r => r.Sername),
                                 Count = each.For(r => r.Count),
                                 Price = each.For(r => r.Price), 
                                 Start_time = each.For(r => r.Start_time) ,
                                 End_time = (DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString())
                              }))
                        .OnSuccess(dsl =>
                        {
                            var urlTmplu = Url.Dispatcher().AsView("~/Views/Customer/Result.cshtml");
                            dsl.WithId("89E66E7D-B3DA-46E5-ACDD-E3025EFD2033").Core().Insert.WithTemplateByUrl(urlTmplu).Html();
                        })
                        .AsHtmlAttributes( new {id = result_id})
                        .ToDiv())
        */
    }
}