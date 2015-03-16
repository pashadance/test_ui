using System;
using System.Collections.Generic;
using System.Linq;
using Incoding.CQRS;
using Test.UI.Operations.Entity;

namespace Test.UI.Operations.Query
{
    public class GetInstantTimeQuery : QueryBase<GetInstantTimeQuery.InstantTimeResult>
    {
        public string id { get; set; }
        private DateTime starttime { get; set; }

        public class InstantTimeResult
        {
            public string InstantTime { get; set; }
            public string update { get; set; }
        }

        protected override InstantTimeResult ExecuteResult()
        {
            List<TimeTrack> tt = Repository.Query<TimeTrack>().ToList();
            foreach (var timetrack in tt)
            {
                if (timetrack.Active & id == timetrack.Id)
                {
                    starttime = timetrack.StartTime;
                    break;
                }
            }
           
            var itr = new InstantTimeResult()
            {
                InstantTime = (DateTime.Now.Subtract(starttime)).ToString(@"hh\:mm\:ss"),
                update = "обновить"
            };
            return itr;
        }
    }
}