
namespace BackendTest.Model
{
    public class Test
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Age { get; set; }

        public string ContaCorrente { get; set; }

        public double Saldo { get; set; }

        public double EfetuarDeposito(double valor)
        {
           Saldo += valor;
           return Saldo;

        }

    }
}
