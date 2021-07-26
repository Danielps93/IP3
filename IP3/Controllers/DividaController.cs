using IP3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace IP3.Controllers
{

    public class DividaController : ApiController
    {
        // GET: Divida

        //tipoConsulta



        public IEnumerable<Divida> Get(string tipoConsulta, string cpf)
        {

            if (tipoConsulta == "consultarDivida")
                return Simulacao.consultarDivida(cpf);
            else if (tipoConsulta == "simularNegociacao")
                return Simulacao.simularNegociacao(cpf);
            else if (tipoConsulta == "confirmarNegociacao")
                return Simulacao.confirmarNegociacao(cpf);
            else if (tipoConsulta == "cancelarNegociacao")
                return Simulacao.cancelarNegociacao(cpf);
            else
                throw new ArgumentException(
                    "Tipo de consulta inválido.");
        }


    }
}