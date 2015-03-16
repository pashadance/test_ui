using System;
using Incoding.Data;
namespace Test.UI.Operations.Entity
{
    public class TimeTrack : IncEntityBase
    {
        public virtual new string Id { get; set; }
        public virtual string Count { get; set; }
        public virtual string Price { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual float Duration { get; set; }
        public virtual string CostOne { get; set; }
        public virtual string Cost { get; set; }
        public virtual bool Active { get; set; }
        public virtual string Period { get; set; }
        public virtual User User { get; set; }

        public class TimeTrackMap : NHibernateEntityMap<TimeTrack>
        {
            protected TimeTrackMap()
            {
                Table("TimeTrack");
                IdGenerateByGuid(r => r.Id);
                Map(r => r.Count);
                Map(r => r.Price);
                Map(r => r.StartTime);
                Map(r => r.EndTime);
                Map(r => r.Duration);
                Map(r => r.CostOne);
                Map(r => r.Cost);
                Map(r => r.Active);
                Map(r => r.Period);
                References(r => r.User, "IdUser");
            }
        }
    }
}