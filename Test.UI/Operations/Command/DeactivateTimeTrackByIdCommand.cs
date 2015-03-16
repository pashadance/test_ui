using System;
using Incoding.CQRS;
using Test.UI.Operations.Entity;

namespace Test.UI.Operations.Command
{
    public class DeactivateTimeTrackByIdCommand : CommandBase
    {
        public string deactivate_id { get; set; }

        public override void Execute()
        {
            DateTime starttime = Repository.GetById<TimeTrack>(deactivate_id).StartTime;
            DateTime endtime = DateTime.Now;
            float duration = (float)endtime.Subtract(starttime).TotalHours;
            int count = int.Parse(Repository.GetById<TimeTrack>(deactivate_id).Count);
            int price = int.Parse(Repository.GetById<TimeTrack>(deactivate_id).Price);
           
            Repository.GetById<TimeTrack>(deactivate_id).EndTime = endtime;
            Repository.GetById<TimeTrack>(deactivate_id).Duration = duration;
            Repository.GetById<TimeTrack>(deactivate_id).Active = false;
            if (Repository.GetById<TimeTrack>(deactivate_id).Period == "час")
            {
                Repository.GetById<TimeTrack>(deactivate_id).CostOne = ((int) (price*duration)).ToString();
                int costone = int.Parse(Repository.GetById<TimeTrack>(deactivate_id).CostOne);
                Repository.GetById<TimeTrack>(deactivate_id).Cost = (count*costone).ToString();
            }
            else
            {
                Repository.GetById<TimeTrack>(deactivate_id).CostOne = ((int)(price)).ToString();
                int costone = int.Parse(Repository.GetById<TimeTrack>(deactivate_id).CostOne);
                Repository.GetById<TimeTrack>(deactivate_id).Cost = (count * costone).ToString();
            }
        }
    }
}