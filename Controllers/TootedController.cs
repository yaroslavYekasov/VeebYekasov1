using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VeebYekasov1.Models;

namespace VeebYekasov1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TootedController : ControllerBase
    {
        private static List<Toode> _tooted = new List<Toode>{
            new Toode(1, "Koola", 1.5, true),
            new Toode(2, "Fanta", 1.0, false),
            new Toode(3, "Sprite", 1.7, true),
            new Toode(4, "Vichy", 2.0, true),
            new Toode(5, "Vitamin well", 2.5, true)
        };

        [HttpGet]
        public ActionResult<List<Toode>> Get()
        {
            return Ok(_tooted);
        }

        [HttpDelete("{index}")]
        public ActionResult<List<Toode>> Delete(int index)
        {
            if (index < 0 || index >= _tooted.Count)
            {
                return NotFound("Product not found.");
            }
            _tooted.RemoveAt(index);
            return Ok(_tooted);
        }

        [HttpPost("lisa")]
        public ActionResult<List<Toode>> Add([FromBody] Toode toode)
        {
            if (toode == null)
            {
                return BadRequest("Invalid product data.");
            }
            _tooted.Add(toode);
            return Ok(_tooted);
        }

        [HttpPatch("hind-dollaritesse/{kurss}")]
        public ActionResult<List<Toode>> Dollaritesse(double kurss)
        {
            if (kurss <= 0)
            {
                return BadRequest("Invalid conversion rate.");
            }

            foreach (var toode in _tooted)
            {
                toode.Price *= kurss;
            }
            return Ok(_tooted);
        }

        [HttpGet("byNumber/{index}")]
        public ActionResult<Toode> ByNumber(int index)
        {
            var toode = _tooted.FirstOrDefault(t => t.Id == index);
            if (toode == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(toode);
        }

        [HttpGet("price")]
        public ActionResult<Toode> Price()
        {
            var maxPrice = _tooted.Max(p => p.Price);
            var toode = _tooted.FirstOrDefault(p => p.Price == maxPrice);
            return Ok(toode);
        }

        [HttpPut("update/{id}")]
        public ActionResult<List<Toode>> UpdateProduct(int id, [FromBody] Toode updatedToode)
        {
            var existingToode = _tooted.FirstOrDefault(t => t.Id == id);
            if (existingToode == null)
            {
                return NotFound("Product not found.");
            }

            // Update properties of the existing product
            existingToode.Name = updatedToode.Name;
            existingToode.Price = updatedToode.Price;
            existingToode.IsActive = updatedToode.IsActive;

            return Ok(_tooted);
        }
    }
}
