using Incoding.CQRS;
using Test.UI.Operations.Entity;
using Test.UI.Operations.Query;

namespace Test.UI.Operations.Command
{
    public class DeleteCustomerByIdCommand : CommandBase
    {
        public string delete_id { get; set; }
        /*public string Name { get; set; }
        public string Sername { get; set; }
        public string Count { get; set; }
        public string Price { get; set; }
        public string Start_time { get; set; }
        public string End_time { get; set; }
        */

        public override void Execute()
        {
            Repository.Delete<User>(delete_id);
        }
    }
}