using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Owner.API.Model;


namespace Owner.API.Data
{
    public class OwnerData
    {
        public List<OwnerModel> GetAllOwners()
        {
            return new List<OwnerModel>
            {
                new OwnerModel
                {
                    ID = 1,
                    Name = "Alex",
                    Surname = "Souza",
                    Date = new DateTime(2022,07,19),  /*System.DateTime.Now,*/
                    Explanation = "student",
                    Type = "member"
                },
                new OwnerModel
                {
                    ID = 2,
                    Name = "Dirk",
                    Surname = "Kuyt",
                    Date = new DateTime(2014,06,17),
                    Explanation = "footballer",
                    Type = "elite"
                },
                   new OwnerModel
                {
                    ID = 3,
                    Name = "Moussa",
                    Surname = "Sow",
                    Date =new DateTime(2016,06,06),
                    Explanation = "player",
                    Type = "member"
                },
                      new OwnerModel
                {
                    ID = 4,
                    Name = "Ekpe",
                    Surname = "Udoh",
                    Date = new DateTime(2020,11,06),
                    Explanation = "basketballer",
                    Type = "elite"
                }

            };
    }
    }
}
