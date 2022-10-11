namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (this.Suite != null && this.Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                if(this.Suite == null)
                {
                    throw new Exception("atributo Suite nulo");
                }
                else
                {
                    throw new Exception("a capacidade da suite eh menor que o numero de hospedes");
                }
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if(this.Hospedes == null)
            {
                throw new Exception("atributo Hospedes nulo");
            }
            else
            {
                return this.Hospedes.Count;
            }
        }

        public decimal CalcularValorDiaria()
        {
            if(this.Suite == null || this.DiasReservados == 0)
            {
                throw new Exception("Suite e/ou DiasReservados invalidos");
            }
            decimal valor = this.Suite.ValorDiaria * this.DiasReservados;

            if (this.DiasReservados >= 10)
            {
                valor = valor * 0.9m;
            }

            return valor;
        }
    }
}