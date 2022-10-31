using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Owner.API.Data;
using Owner.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Owner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        [Route("Name")]
        [HttpGet]
        public string GetName()
        {
            return "return name";
        }

        [Route("AllOwner")]
        [HttpGet]
        public IActionResult GetOwner()
        {
            var owners = new List<OwnerModel>()
            {
                new OwnerModel{
                    ID=100,
                    Name= "Rabia",
                    Surname = "Yılmaz",
                    Date = new DateTime(1998,08,19),
                    Explanation = "engineer",
                    Type = "member"

                },
                new OwnerModel{
                    ID=101,
                    Name= "Esra",
                    Surname = "Kozan",
                    Date = new DateTime(1998,04,11),
                    Explanation = "doctor",
                    Type = "member",

                }
            };
            if (owners.Any(x => x.Name.Contains("Elif")))
            {
                return Ok(owners);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("All")]
        [HttpGet]
        public List<OwnerModel> GetOwners()
        {
            return new List<OwnerModel>
            {

                new OwnerModel
                {
                    ID = 1,
                    Name = "Alex",
                    Surname = "Souza",
                    Date = new DateTime(2022,07,19),
                    Explanation = "student",
                    Type = "member"
                },
                new OwnerModel
                {
                    ID = 2,
                    Name = "Dirk",
                    Surname = "Kuyt",
                    Date = new DateTime(2016,06,06),
                    Explanation = "footballer",
                    Type = "elite"
                },
                new OwnerModel
                {
                    ID = 3,
                    Name = "Moussa",
                    Surname = "Sow",
                    Date = new DateTime(2020,11,06),
                    Explanation = "player",
                    Type = "member"
                }
            };

        }

        [HttpPost]
        public IActionResult AddOwner(OwnerModel model)
        {
            var owner = new List<OwnerModel>();
            owner.Add(model);
            return Ok(owner);
        }

        [HttpPost("Create")]
        public IActionResult CreateOwner(OwnerModel owner)
        {
            if (owner == null)
                return BadRequest();

            return CreatedAtAction(nameof(CreateOwner), owner);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var owners = new OwnerData().GetAllOwners();

            var owner = owners.FirstOrDefault(x => x.ID == id);

            if (owner == null)
                return NotFound($"{id} nolu müşteri bulunamadı");

            owners.Remove(owner);

            return Ok("Silindi");
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, OwnerModel owner)
        {
            if (id != owner.ID)
                return BadRequest("Id'ler eşleşmedi");

            var owners = new OwnerData().GetAllOwners();

            var update = owners.FirstOrDefault(x => x.ID == id);

            update.Name = owner.Name.ToUpper();
            update.Surname = owner.Surname.ToLower();
            update.Date = owner.Date;
            update.Explanation = owner.Explanation;
            update.Type = $"{owner.Type} Türü";

            return Ok(update);

        }

        [HttpPost("XMLPost")]
        [Consumes("application/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult NewRequestFromBody(OwnerModel owner)
        {
            return Ok();
        }

    }
}
