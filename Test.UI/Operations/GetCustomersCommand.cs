namespace Test.UI.Operations
{
    using System.Collections.Generic;
    using System.Linq;
    using Incoding.CQRS;

    public class GetCustomersCommand : CommandBase
    {
       
        public override void Execute()

        {
            var existcust = Repository.GetById<Customer>("2d43f060-e402-4766-be4e-a44000ec36d0");
            existcust.Name = "nnnnnnnnnnn";
            var cust = new Customer()
            {
                Name = "Name1",
                Surname = "Surname2"
            };
            Repository.SaveOrUpdate(cust);
        }


    }
}