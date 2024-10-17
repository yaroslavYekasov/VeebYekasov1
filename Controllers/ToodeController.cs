using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VeebYekasov1.Models;

namespace VeebYekasov1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToodeController : ControllerBase
    {
        private static Toode _toode = new Toode(1, "Koola", 1.5, true);

        // GET: toode
        [HttpGet]
        public Toode GetToode()
        {
            return _toode;
        }

        // GET: toode/suurenda-hinda
        [HttpGet("suurenda-hinda")]
        public Toode SuurendaHinda()
        {
            _toode.Price = _toode.Price + 1;
            return _toode;
        }
         //Switch to opposite isAvtive
        [HttpGet("toggle-activity")]
        public Toode ToggleActivity()
        {
            _toode.IsActive = !_toode.IsActive;
            return _toode;
        }

        //Change name 
        [HttpPut("change-name/{newName}")]
        public Toode ChangeName(string newName)
        {
            _toode.Name = newName;
            return _toode;
        }

        //Multiply price by
        [HttpPut("multiply-price/{factor}")]
        public Toode MultiplyPrice(double factor)
        {
            _toode.Price *= factor;
            return _toode;
        }
    }
}
