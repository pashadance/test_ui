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
        public string Sername { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Count { get; set; }
        public string Price { get; set; }
        public DateTime Start_time { get; set; }
        
        public ItemAppendCommand(){}
        public ItemAppendCommand(string sername,string name, string otch , string count, string price)
        {
            Sername = sername;
            Name = name;
            FatherName = otch;
            Count = count;
            Price = price;
        }

        public static string Normalize(string inputString)
        {
            char[] charsToTrim = { '*', ' ', '\'', '-', '=', '+', '.', ',', '_', '/', '"' };
            inputString = Regex.Replace(inputString.Trim(charsToTrim), @"[\d]", "", RegexOptions.Compiled);
            inputString = inputString.Replace("  ", string.Empty);
            inputString = inputString.Trim().Replace(" ", string.Empty);
            if (inputString != string.Empty)
            {
                inputString = inputString[0].ToString().ToUpper() + inputString.Substring(1);
            }
            return inputString;
        }
       
        public override void Execute()
        {
            if (FatherName == null){FatherName = string.Empty;}

            if (Name != null & Sername != null)
            {
                bool setuser = false;
                // приведение ФИО к нормальному виду 
                Sername = Normalize(Sername);
                Name = Normalize(Name);
                FatherName = Normalize(FatherName);

                Start_time = DateTime.Now;
               
                // проверка юзера на существование в бд 
                List<User> uselist = Repository.Query<User>().ToList();
                if (uselist.Count == 0) { setuser = true; }
                User userok = null;
                
                foreach (var user in uselist)
                {
                    if (Name == user.Name & Sername == user.Sername & FatherName==user.FatherName)
                    {
                        userok = user;
                        setuser = false;
                        break;
                    }
                    else setuser = true;
                }
                
                if (setuser)//если юзер новый, он пишется в бд
                {
                    userok = new User()
                    {
                        Sername = Sername,
                        Name = Name,
                        FatherName = FatherName
                    };
                    Repository.Save(userok);
                }
                
                TimeTrack timetr = new TimeTrack()
                {
                    Count = Count,
                    Price = Price,
                    StartTime = Start_time,
                    EndTime = Start_time,
                    Duration = (float) 0.0,
                    CostOne = "0",
                    Cost = "0",
                    User = userok,
                    Active = true
                };
                Repository.Save(timetr);

            }
        }
    }
}