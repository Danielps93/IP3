using IP3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IP3
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Validate();
            }
        }

        protected void BtnSimularNeg_ServerClick(object sender, EventArgs e)
        {
            if (txtCPF.Value == "")
            {
                return;
            }
            StringBuilder htmlTable = new StringBuilder();
            string baseUrl = HttpContext.Current.Request.UrlReferrer.Authority;
            string url = "https://" + baseUrl + "/api/Divida/simularNegociacao/" + txtCPF.Value;
            var requisicaoWeb = WebRequest.CreateHttp(url);
            requisicaoWeb.Method = "GET";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var post = JsonConvert.DeserializeObject<List<Divida>>(objResponse.ToString());
                streamDados.Close();
                resposta.Close();

                htmlTable.Append("<table class='table table-bordered table-responsive table-hover'>");
                htmlTable.Append("<tr>");
                htmlTable.Append("<th>CPF</th>");
                htmlTable.Append("<th>Id Simulacao</th>");
                htmlTable.Append("<th>Parcela</th>");
                htmlTable.Append("<th>Vencimento Parc.</th>");
                htmlTable.Append("<th>Valor Parc.</th>");
                htmlTable.Append("</tr>");

                foreach (var item in post)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + item.cpf + "</td>");
                    htmlTable.Append("<td>" + item.idSimulacao + "</td>");
                    htmlTable.Append("<td>" + item.parcela.Select(x => x.nrParcela).FirstOrDefault() + "</td>");
                    htmlTable.Append("<td>" + item.parcela.Select(x => x.vencimentoParcela).FirstOrDefault() + "</td>");
                    htmlTable.Append("<td>" + item.parcela.Select(x => x.valorParcela).FirstOrDefault() + "</td>");
                    htmlTable.Append("</tr>");
                }

                htmlTable.Append("</table>");
                lblResultado.Text = htmlTable.ToString();
            }
        }

        protected void BtnConfirmarNeg_ServerClick(object sender, EventArgs e)
        {
            if (txtCPF.Value == "")
            {
                return;
            }
            StringBuilder htmlTable = new StringBuilder();
            string baseUrl = HttpContext.Current.Request.UrlReferrer.Authority;
            string url = "https://" + baseUrl + "/api/Divida/confirmarNegociacao/" + txtCPF.Value;
            var requisicaoWeb = WebRequest.CreateHttp(url);
            requisicaoWeb.Method = "GET";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var post = JsonConvert.DeserializeObject<List<Divida>>(objResponse.ToString());
                streamDados.Close();
                resposta.Close();

                htmlTable.Append("<table class='table table-bordered table-responsive table-hover'>");
                htmlTable.Append("<tr>");
                htmlTable.Append("<th>Id Acordo</th>");
                htmlTable.Append("<th>Mensagem</th>");                
                htmlTable.Append("</tr>");


                foreach (var item in post)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + item.idAcordo + "</td>");
                    htmlTable.Append("<td>" + item.Msg + "</td>");
                    htmlTable.Append("</tr>");
                }

                htmlTable.Append("</table>");
                lblResultado.Text = htmlTable.ToString();
            }
        }

        protected void BtnConsultaDivida_ServerClick(object sender, EventArgs e)
        {
            if (txtCPF.Value == "")
            {
                return;
            }
            StringBuilder htmlTable = new StringBuilder();
            string baseUrl = HttpContext.Current.Request.UrlReferrer.Authority;
            string url = "https://" + baseUrl + "/api/Divida/consultarDivida/" + txtCPF.Value;
            var requisicaoWeb = WebRequest.CreateHttp(url);
            requisicaoWeb.Method = "GET";

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var post = JsonConvert.DeserializeObject<List<Divida>>(objResponse.ToString());
                streamDados.Close();
                resposta.Close();

                htmlTable.Append("<table class='table table-bordered table-responsive table-hover'>");
                htmlTable.Append("<tr>");
                htmlTable.Append("<th>CPF</th>");
                htmlTable.Append("<th>Valor Divida</th>");
                htmlTable.Append("<th>Data Atualizacao</th>");
                htmlTable.Append("</tr>");

                foreach (var item in post)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + item.cpf + "</td>");
                    htmlTable.Append("<td>" + item.vrDivida + "</td>");
                    htmlTable.Append("<td>" + item.dataAtualizacao + "</td>");
                    htmlTable.Append("</tr>");
                }

                htmlTable.Append("</table>");
                lblResultado.Text = htmlTable.ToString();
            }
        }

        protected void BtnCancelarNeg_ServerClick(object sender, EventArgs e)
        {
            if (txtCPF.Value == "")
            {
                return;
            }
            StringBuilder htmlTable = new StringBuilder();
            string baseUrl = HttpContext.Current.Request.UrlReferrer.Authority;
            string url = "https://" + baseUrl + "/api/Divida/cancelarNegociacao/" + txtCPF.Value;
            var requisicaoWeb = WebRequest.CreateHttp(url);
            requisicaoWeb.Method = "GET";

            htmlTable.Append("<table class='table table-bordered table-responsive table-hover'>");
            htmlTable.Append("<tr>");
            htmlTable.Append("<th>Mensagem</th>");
            htmlTable.Append("</tr>");

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var post = JsonConvert.DeserializeObject<List<Divida>>(objResponse.ToString());
                streamDados.Close();
                resposta.Close();

                foreach (var item in post)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + item.Msg + "</td>");
                    htmlTable.Append("</tr>");
                }
                htmlTable.Append("</table>");
                lblResultado.Text = htmlTable.ToString();

            }
        }
    }
}