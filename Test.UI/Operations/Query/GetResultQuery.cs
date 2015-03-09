using System;
using Incoding.CQRS;
using Test.UI.Operations.Entity;

namespace Test.UI.Operations.Query
{
    public class GetResultQuery : QueryBase<GetResultQuery.Result>
    {
        public string Id { get; set; }
       
        public class Result
        {
            public string Sername { get; set; }
            public string Name { get; set; }
            public string FatherName { get; set; }
            public string Count { get; set; }
            public string Price { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public string Duration { get; set; }
            public string CostOne { get; set; }
            public string Cost { get; set; }
        }

       // public GetResultQuery(string id)
       // {Id = id;}

        protected override Result ExecuteResult()
        {
            //var dur = TimeSpan.FromHours(Repository.GetById<TimeTrack>(Id).Duration);
            var result = new Result()
            {
                Sername = Repository.GetById<TimeTrack>(Id).User.Sername,
                Name = Repository.GetById<TimeTrack>(Id).User.Name,
                FatherName = Repository.GetById<TimeTrack>(Id).User.FatherName,
                Count = Repository.GetById<TimeTrack>(Id).Count,
                Price = Repository.GetById<TimeTrack>(Id).Price,
                StartTime = Repository.GetById<TimeTrack>(Id).StartTime.ToString().Substring(9),
                EndTime = Repository.GetById<TimeTrack>(Id).EndTime.ToString().Substring(9),
                Duration = TimeSpan.FromHours(Repository.GetById<TimeTrack>(Id).Duration).ToString(@"hh\:mm\:ss"),
                CostOne = Repository.GetById<TimeTrack>(Id).CostOne,
                Cost = Repository.GetById<TimeTrack>(Id).Cost
            };

           return result;
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