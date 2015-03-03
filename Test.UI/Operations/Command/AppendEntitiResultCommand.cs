using Incoding.CQRS;
using Test.UI.Operations.Entity;

namespace Test.UI.Operations.Command
{
    public class AppendEntitiResultCommand: CommandBase
    {
        public string Name { get; set; }
        public string Sername { get; set; }
        public string Cost { get; set; }
        public string Duration { get; set; }

        public int Count { get; set; }
        public int Price { get; set; }
        public string Start_time { get; set; }
        public string End_time { get; set; }

        public override void Execute()
        {/*
            var result = new Result()
            {
                Name = Name,
                Sername = Sername,
                Cost = Cost,
                Duration = Duration
            };
            Repository.SaveOrUpdate(result);*/
        }

    }
}