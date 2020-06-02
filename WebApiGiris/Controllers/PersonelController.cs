using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiGiris.Models;

namespace WebApiGiris.Controllers
{
    public class PersonelController : ApiController
    {
        public List<Personel> personels = new List<Personel>()
        {
            new Personel{ Id = 1, Name = "Murat", Surname = "Döngel"},
            new Personel{ Id = 2, Name = "Hasan", Surname = "Şahin"},
            new Personel{ Id = 3, Name = "Emrah", Surname = "Aktaş"}
        };

        public IEnumerable<Personel> GetPersonels()
        {
            return personels;
        }

        public IHttpActionResult GetPersonel(int id)
        {
            var arananpersonel = personels.FirstOrDefault(x => x.Id == id);
            return Ok(arananpersonel);
        }

        public IHttpActionResult PostPersonel(Personel p)
        {
            if (personels.Where(x => x.Id == p.Id).Count() == 0)
            {
                return Ok();
            }
            else
            {
                return Conflict();
            }
        }
    }
}
