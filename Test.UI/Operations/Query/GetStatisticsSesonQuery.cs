using System;
using System.Collections.Generic;
using System.Linq;
using Test.UI.Operations.Entity;
using Incoding.CQRS;

namespace Test.UI.Operations.Query
{
    public class GetStatisticsSesonQuery : QueryBase<GetStatisticsSesonQuery.StatSesonResponse>
    {
        public class StatSesonResponse
        {
            public int SumSeson { get; set; }
            public int CountBikesSeson { get; set; }
            public int CountMens { get; set; }
            public int DateSeson { get; set; }
        }

        protected override StatSesonResponse ExecuteResult()
        {
           // StatSesonResponse ssr= new StatSesonResponse();

            int summa = 0;
            int kolvo_velov = 0;
            int kolvo_chelovekov = 0;

            var seson = DateTime.Now.Year;

            List<TimeTrack> ttList = Repository.Query<TimeTrack>().ToList();

            foreach (var timeTrack in ttList)
            {
                if (timeTrack.StartTime.Year == seson & timeTrack.EndTime.Year == seson)
                {
                    if (timeTrack.Cost != null & timeTrack.Count != null & timeTrack.Active == false)
                    {
                        summa += int.Parse(timeTrack.Cost);
                        kolvo_velov += int.Parse(timeTrack.Count);
                        kolvo_chelovekov++;
                    }
                }
            }
            StatSesonResponse ssr = new StatSesonResponse()
            {
                DateSeson = seson,
                SumSeson = summa,
                CountBikesSeson = kolvo_velov,
                CountMens = kolvo_chelovekov
            };
            return ssr;
        }
    }
}