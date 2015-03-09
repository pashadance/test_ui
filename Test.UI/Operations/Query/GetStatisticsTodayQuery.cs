using System;
using System.Collections.Generic;
using System.Linq;
using Incoding.CQRS;
using Test.UI.Operations.Entity;

namespace Test.UI.Operations.Query
{
    public class GetStatisticsTodayQuery : QueryBase<GetStatisticsTodayQuery.StatTodayResponse>
    {
        public class StatTodayResponse
        {
            public int SumToday { get; set; }
            public int CountBikes { get; set; }
            public int CountMens { get; set; }
            public string DayOfWeek { get; set; }
        }

        private string[] month = new string[12]
        {
            "января", "февраля",
            "марта", "апреля", "мая", 
            "июня", "июля", "августа",
            "сентября", "октября", "ноября",
            "декабря"
        };
        
        protected override StatTodayResponse ExecuteResult()
        {
            int m = 0;
            int summa = 0;
            int kolvo_velov = 0;
            int kolvo_chelovekov = 0;
            
            var yesterday = DateTime.Now.AddDays(-1).Date;
            var tomorrow = DateTime.Now.AddDays(1).Date;

            List<TimeTrack> ttList = Repository.Query<TimeTrack>().ToList();

            foreach (var timeTrack in ttList)
            {
                if (timeTrack.StartTime.Date < tomorrow & timeTrack.StartTime.Date > yesterday &
                    timeTrack.EndTime.Date < tomorrow & timeTrack.EndTime.Date > yesterday)
                {
                    if (timeTrack.Cost != null & timeTrack.Count != null & timeTrack.Active==false)
                    {
                        summa += int.Parse(timeTrack.Cost);
                        kolvo_velov += int.Parse(timeTrack.Count);
                        kolvo_chelovekov++;
                    }
                }
            }
            
            if (DateTime.Now.Month == 0)
            m = 0;
            else
            m = DateTime.Now.Month - 1;
           
            StatTodayResponse sr = new StatTodayResponse()
            {
                DayOfWeek = DateTime.Now.Day.ToString() + " " + month[m] + " " + DateTime.Now.Year,
                SumToday = summa,
                CountBikes = kolvo_velov,
                CountMens = kolvo_chelovekov
            };
            return sr;
        }
    }
}