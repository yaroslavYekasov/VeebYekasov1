using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VeebYekasov1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimitiividController : ControllerBase
    {
        Random rnd = new Random();

        // GET: primitiivid/hello-world
        [HttpGet("hello-world")]
        public string HelloWorld()
        {
            return "Hello world at " + DateTime.Now;
        }

        // GET: primitiivid/hello-variable/mari
        [HttpGet("hello-variable/{nimi}")]
        public string HelloVariable(string nimi)
        {
            return "Hello " + nimi;
        }

        // GET: primitiivid/add/5/6
        [HttpGet("add/{nr1}/{nr2}")]
        public int AddNumbers(int nr1, int nr2)
        {
            return nr1 + nr2;
        }

        // GET: primitiivid/multiply/5/6
        [HttpGet("multiply/{nr1}/{nr2}")]
        public int Multiply(int nr1, int nr2)
        {
            return nr1 * nr2;
        }

        // GET: random/5/6
        [HttpGet("random/{nr1}/{nr2}")]
        public int RandomNum(int nr1, int nr2)
        {
            int month = rnd.Next(nr1, nr2);
            return month;
        }

        // GET: birthdate/year/month/day
        [HttpGet("random/{year}/{month}/{day}")]
        public int Birth(int year, int month, int day)
        {
            int dateYear = DateTime.Now.Year;
            int dateMonth = DateTime.Now.Month;
            int dateDay = DateTime.Now.Day;

            if (month < dateMonth)
            {
                return dateYear - year;
            }
            else if(month < dateDay)
            {
                return dateYear - year;
            }
            else
            {
                return dateYear - year - 1;
            }
        }

        // GET: primitiivid/do-logs/5
        [HttpGet("do-logs/{arv}")]
        public void DoLogs(int arv)
        {
            for (int i = 0; i < arv; i++)
            {
                Console.WriteLine("See on logi nr " + i);
            }
        }
    }
}
