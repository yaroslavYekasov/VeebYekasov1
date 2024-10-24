using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VeebYekasov1.Models;

namespace VeebYekasov1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KasutajaController : ControllerBase
    {
        private static List<Kasutaja> _kasutajad = new List<Kasutaja>{
            new Kasutaja(1, "user1", "password1", "John", "Doe"),
            new Kasutaja(2, "user2", "password2", "Jane", "Smith"),
            new Kasutaja(3, "user3", "password3", "Max", "Mustermann"),
        };

        [HttpGet]
        public ActionResult<List<Kasutaja>> Get()
        {
            return Ok(_kasutajad);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Kasutaja>> Delete(int id)
        {
            var kasutaja = _kasutajad.FirstOrDefault(k => k.Id == id);
            if (kasutaja == null)
            {
                return NotFound("User not found.");
            }
            _kasutajad.Remove(kasutaja);
            return Ok(_kasutajad);
        }

        [HttpPost("lisa")]
        public ActionResult<List<Kasutaja>> Add([FromBody] Kasutaja kasutaja)
        {
            if (kasutaja == null)
            {
                return BadRequest("Invalid user data.");
            }

            // Check for existing user with the same ID
            if (_kasutajad.Any(k => k.Id == kasutaja.Id))
            {
                return BadRequest("User with the same ID already exists.");
            }

            _kasutajad.Add(kasutaja);
            return Ok(_kasutajad);
        }

        [HttpPut("update/{id}")]
        public ActionResult<List<Kasutaja>> UpdateUser(int id, [FromBody] Kasutaja updatedKasutaja)
        {
            var existingKasutaja = _kasutajad.FirstOrDefault(k => k.Id == id);
            if (existingKasutaja == null)
            {
                return NotFound("User not found.");
            }

            // Update properties of the existing user
            existingKasutaja.Kasutajanimi = updatedKasutaja.Kasutajanimi;
            existingKasutaja.Parool = updatedKasutaja.Parool;
            existingKasutaja.Eesnimi = updatedKasutaja.Eesnimi;
            existingKasutaja.Perenimi = updatedKasutaja.Perenimi;

            return Ok(_kasutajad);
        }
    }
}
