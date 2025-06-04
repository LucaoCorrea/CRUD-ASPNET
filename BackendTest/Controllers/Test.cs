using BackendTest.Model;
using Microsoft.AspNetCore.Mvc;

namespace BackendTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static List<Test> testData = new List<Test>
        {
            new Test { Id = 1, Nome = "João", Age = 30, ContaCorrente = "300-3" },
            new Test { Id = 2, Nome = "Maria", Age = 25, ContaCorrente = "300-4" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Test>> Get()
        {
            return Ok(testData);
        }

        [HttpGet("{id}")]
        public ActionResult<Test> GetById(int id)
        {
            var test = testData.FirstOrDefault(t => t.Id == id);
            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        [HttpPost]
        public ActionResult<Test> postTest([FromBody] Test newTest)
        {
            newTest.Id = testData.Max(t => t.Id) + 1;

            testData.Add(newTest);

            return CreatedAtAction(nameof(GetById), new { id = newTest.Id }, newTest);
        }

        [HttpPost("{id}/deposito")]
        public ActionResult<double> EfetuarDeposito(int id, [FromBody] double valor)
        {
            var test = testData.FirstOrDefault(t => t.Id == id);

            // not found
            if (test == null)
            {
                return NotFound();
            }


            double saldoAtualizado = test.EfetuarDeposito(valor);
            return Ok(new { saldo = saldoAtualizado });
        }

        [HttpGet("{id}/saldo")]
        public ActionResult<double> ConsultSaldo(int id)
        {
            var test = testData.FirstOrDefault(t => t.Id == id);


            // Not Found
            if (test == null)
            {
                return NotFound();
            }

            return Ok(new { saldo = test.Saldo });
        }
    }
}
