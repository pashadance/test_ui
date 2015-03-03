using System;
using System.Text.RegularExpressions;
using Incoding.CQRS;
using Test.UI.Operations.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Test.UI.Operations.Command
{
    public class ItemAppendCommand : CommandBase
    {
        public string Name { get; set; }
        public string Sername { get; set; }
        public string Count { get; set; }
        public string Price { get; set; }
        public DateTime Start_time { get; set; }
        
        public ItemAppendCommand(){}
        
        public ItemAppendCommand(string name, string sername, string count, string price)
        {
            Name = name;
            Sername = sername;
            Count = count;
            Price = price;
        }
       
        public override void Execute()
        {
            if (Name != String.Empty & Sername != String.Empty /*& Count != 0 & Price != 0*/)
            {
                char[] charsToTrim = {'*', ' ', '\'', '-', '=', '+', '.', ',', '_', '/', '"'};
                Name = Regex.Replace(Name.Trim(charsToTrim), @"[\d]", "", RegexOptions.Compiled);
                Sername = Regex.Replace(Sername.Trim(charsToTrim), @"[\d]", "", RegexOptions.Compiled);
                Start_time = DateTime.Now;//.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

                //List<User> u = Repository.Query<User>().ToList();


                User userok = new User()
                {
                    Name = Name,
                    Sername = Sername
                };
                Repository.SaveOrUpdate(userok);
                    
                

                var timetr = new TimeTrack()
                {
                    Count = Count,
                    Price = Price,
                    StartTime = Start_time,
                    EndTime = Start_time,
                    Duration = Start_time,
                    IdUser = userok.Id,
                    Active = true
                };
                Repository.SaveOrUpdate(timetr);
            }
           
        }


    }
}