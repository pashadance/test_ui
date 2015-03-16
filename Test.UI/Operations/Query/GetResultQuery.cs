using System;
using System.Globalization;
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
            public string Period { get; set; }
        }

        protected override Result ExecuteResult()
        {
            CultureInfo ci = new CultureInfo("ru-RU");
            string cost_1 = "";
            if (int.Parse(Repository.GetById<TimeTrack>(Id).Count) != 1)
            {
                cost_1 = "Итог для одного: " + Repository.GetById<TimeTrack>(Id).CostOne;
            }
            var result = new Result()
            {
                Sername = Repository.GetById<TimeTrack>(Id).User.Sername,
                Name = Repository.GetById<TimeTrack>(Id).User.Name,
                FatherName = Repository.GetById<TimeTrack>(Id).User.FatherName,
                Count = Repository.GetById<TimeTrack>(Id).Count,
                Price = Repository.GetById<TimeTrack>(Id).Price,
                StartTime = Repository.GetById<TimeTrack>(Id).StartTime.ToString("T", ci),
                EndTime = Repository.GetById<TimeTrack>(Id).EndTime.ToString("T", ci),
                Duration = TimeSpan.FromHours(Repository.GetById<TimeTrack>(Id).Duration).ToString(@"hh\:mm\:ss"),
                CostOne = cost_1,
                Cost = Repository.GetById<TimeTrack>(Id).Cost,
                Period = Repository.GetById<TimeTrack>(Id).Period
            };

           return result;
        }
    }
}