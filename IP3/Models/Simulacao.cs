using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IP3.Models;

namespace IP3.Models
{
    public static class Simulacao
    {
        //public static void Parcelas()
        //{
        //    List<Parcela> dadosaprc = new List<Parcela>();
        //    dadosaprc.Add(new Parcela()
        //    {
        //        nrParcela = 1,
        //        vencimentoParcela = DateTime.Now,
        //        valorParcela = 50.00
        //    }) ;

        //    dadosaprc.Add(new Parcela()
        //    {
        //        nrParcela = 2,
        //        vencimentoParcela = DateTime.Now.AddMonths(1),
        //        valorParcela = 50.00
        //    });

        //}

        //public static void InserirDivida()
        //{
        //    List<Divida> dadosneg = new List<Divida>();
        //    dadosneg.Add(new Divida()
        //    {
        //        cpf = "11111111111",
        //        vrDivida = 100,
        //        dataAtualizacao = DateTime.Now,
        //        qtdParcelas = 2,
        //        idSimulacao = 1,
        //        idAcordo = 1,
        //        Msg = "OK"                
        //    }) ;
        //}

        public static List<Divida> consultarDivida(string sCpf)
        {
            List<Divida> dadosneg = new List<Divida>();
            dadosneg.Add(new Divida()
            {
                cpf = "11111111111",
                vrDivida = 100,
                dataAtualizacao = DateTime.Now,
                qtdParcelas = 2,
                idSimulacao = 1,
                idAcordo = 1,
                Msg = "OK"
            });

            List<Parcela> dadosaprc = new List<Parcela>();
            dadosaprc.Add(new Parcela()
            {
                nrParcela = 1,
                vencimentoParcela = DateTime.Now,
                valorParcela = 50.00
            });

            dadosaprc.Add(new Parcela()
            {
                nrParcela = 2,
                vencimentoParcela = DateTime.Now.AddMonths(1),
                valorParcela = 50.00
            });

            var dadosConsulta = dadosneg.Where(x => x.cpf == sCpf).Select(x => new Divida { cpf = x.cpf, vrDivida = x.vrDivida, dataAtualizacao = x.dataAtualizacao }).ToList();

            return dadosConsulta;
        }

        public static List<Divida> simularNegociacao(string sCpf)
        {

            List<Parcela> dadosaprc = new List<Parcela>();
            dadosaprc.Add(new Parcela()
            {
                nrParcela = 1,
                vencimentoParcela = DateTime.Now,
                valorParcela = 50.00
            });

            dadosaprc.Add(new Parcela()
            {
                nrParcela = 2,
                vencimentoParcela = DateTime.Now.AddMonths(1),
                valorParcela = 50.00
            });

            List<Divida> dadosneg = new List<Divida>();
            dadosneg.Add(new Divida()
            {
                cpf = "11111111111",
                vrDivida = 100,
                dataAtualizacao = DateTime.Now,
                qtdParcelas = 2,
                idSimulacao = 1,
                idAcordo = 1,
                Msg = "OK",
                parcela = dadosaprc
            });            

            var dadosConsulta = dadosneg.Where(x => x.cpf == sCpf).Select(x => new Divida { cpf = x.cpf, idSimulacao = x.idSimulacao, parcela = x.parcela }).ToList();

            return dadosConsulta;
        }

        public static List<Divida> confirmarNegociacao(string sCpf)
        {
            List<Divida> dadosneg = new List<Divida>();
            dadosneg.Add(new Divida()
            {
                cpf = "11111111111",
                vrDivida = 100,
                dataAtualizacao = DateTime.Now,
                qtdParcelas = 2,
                idSimulacao = 1,
                idAcordo = 1,
                Msg = "OK"
            });

            List<Parcela> dadosaprc = new List<Parcela>();
            dadosaprc.Add(new Parcela()
            {
                nrParcela = 1,
                vencimentoParcela = DateTime.Now,
                valorParcela = 50.00
            });

            dadosaprc.Add(new Parcela()
            {
                nrParcela = 2,
                vencimentoParcela = DateTime.Now.AddMonths(1),
                valorParcela = 50.00
            });
            
            var dadosConsulta = dadosneg.Where(x => x.cpf == sCpf).Select(x => new Divida { idAcordo = x.idAcordo, Msg = x.Msg }).ToList();

            return dadosConsulta;

        }

        public static List<Divida> cancelarNegociacao(string sCpf)
        {
            List<Divida> dadosneg = new List<Divida>();
            dadosneg.Add(new Divida()
            {
                cpf = "11111111111",
                vrDivida = 100,
                dataAtualizacao = DateTime.Now,
                qtdParcelas = 2,
                idSimulacao = 1,
                idAcordo = 1,
                Msg = "OK"
            });

            List<Parcela> dadosaprc = new List<Parcela>();
            dadosaprc.Add(new Parcela()
            {
                nrParcela = 1,
                vencimentoParcela = DateTime.Now,
                valorParcela = 50.00
            });

            dadosaprc.Add(new Parcela()
            {
                nrParcela = 2,
                vencimentoParcela = DateTime.Now.AddMonths(1),
                valorParcela = 50.00
            });

            var dadosConsulta = dadosneg.Where(x => x.cpf == sCpf).Select(x => new Divida { Msg = x.Msg }).ToList();

            return dadosConsulta;
        }
    }
}