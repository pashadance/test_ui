using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.UI.Operations.Entity;
using Incoding.CQRS;

namespace Test.UI.Operations.Query
{
    public class GetStatisticsCustomQuery : QueryBase<GetStatisticsCustomQuery.StatCustomResponse>
    {
        public string StartDay { get; set; }
        public string StartMonth { get; set; }
        public string StartYear { get; set; }
        public string EndDay { get; set; }
        public string EndMonth { get; set; }
        public string EndYear { get; set; }
        //public int StartDay { get; set; }
        private string[] month = new string[12]
        {
            "января", "февраля",
            "марта", "апреля", "мая", 
            "июня", "июля", "августа",
            "сентября", "октября", "ноября",
            "декабря"
        };

        public class StatCustomResponse
        {
            public int SumCustom { get; set; }
            public int CountBikesCustom { get; set; }
            public int CountMensCustom { get; set; }
            public string StaartDate { get; set; }
            public string EndDate { get; set; }
        }

        public static int ToInt(string input)
        {return int.Parse(input);}

        protected override StatCustomResponse ExecuteResult()
        {
            bool cheta = false;
            int m = 0;
            int summa = 0;
            int kolvo_velov = 0;
            int kolvo_chelovekov = 0;

            var startdate = new DateTime(ToInt(StartYear), ToInt(StartMonth), ToInt(StartDay)).Date;
            var enddate = new DateTime(ToInt(EndYear), ToInt(EndMonth), ToInt(EndDay)).Date;
            List<TimeTrack> timeTracks = Repository.Query<TimeTrack>().ToList();

            var startdatestr = startdate.Day.ToString() + "." + startdate.Month.ToString() + "." + startdate.Year.ToString();
            var enddatestr =  enddate.Day.ToString() + "." + enddate.Month.ToString() + "." + enddate.Year.ToString();

            if (DateTime.Now.Month == 0)
            m = 0;
            else
            m = DateTime.Now.Month - 1;

            if (startdate == enddate)
            {
                startdate = startdate.AddDays(-1).Date;
                enddate = enddate.AddDays(1).Date;
                cheta = true;
            }

            foreach (var timeTrack in timeTracks)
            {
                if (timeTrack.StartTime.Date > startdate & timeTrack.StartTime.Date < enddate &&
                    timeTrack.EndTime.Date > startdate & timeTrack.EndTime.Date < enddate)
                {
                    summa += ToInt(timeTrack.Cost);
                    kolvo_velov += ToInt(timeTrack.Count);
                    kolvo_chelovekov++;
                }
            }
            
            startdatestr = "с " + startdatestr;
            enddatestr = "по " + enddatestr;
            if (cheta)
            {
                if (startdate.AddDays(1).Date == DateTime.Now.Date)
                    startdatestr = "за сегодня";
                else
                    startdatestr = "за ";
                enddatestr = (enddate.Day - 1).ToString() + " " + month[enddate.Month - 1] + " "+ enddate.Year;
            }

            StatCustomResponse d = new StatCustomResponse()
            {
                SumCustom = summa,
                CountBikesCustom = kolvo_velov,
                CountMensCustom = kolvo_chelovekov,
                StaartDate = startdatestr,
                EndDate =enddatestr
            };
            return d;
        }
    }
  
}