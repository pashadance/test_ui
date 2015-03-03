using Incoding.CQRS;
using Test.UI.Operations.Entity;
using Test.UI.Operations.Query;

namespace Test.UI.Operations.Command
{
    public class DeactivateTimeTrackByIdCommand : CommandBase
    {
        public string deactivate_id { get; set; }
       
        public override void Execute()
        {
            Repository.GetById<TimeTrack>(deactivate_id).Active = false;
            // Repository.Delete<User>(delete_id);
        }
    }
}