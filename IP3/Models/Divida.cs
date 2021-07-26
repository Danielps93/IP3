using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IP3.Models
{
    public class Divida
    {
        public string cpf { get; set; }
        public double vrDivida { get; set; }
        public DateTime dataAtualizacao { get; set; }
        public int qtdParcelas { get; set; }

        public int idSimulacao { get; set; }

        public int idAcordo { get; set; }

        public string Msg { get; set; }

        public List<Parcela> parcela { get; set; } 

    }
}
