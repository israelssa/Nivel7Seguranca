using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nivel7DALSeguranca;

namespace Nivel7BLLSeguranca
{
    public class Tela_OperacaoBLL
    {
        Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();

        public void Insert(int IDTela, int IDOperacao)
        {            
            entity.Tela_OperacaoInsert(IDTela, IDOperacao);
            entity.SaveChanges();
        }

        public void Delete(int IDTela, int IDOperacao)
        {
            entity.Tela_OperacaoDelete(IDTela, IDOperacao);
            entity.SaveChanges();
        }

        public IQueryable GetTelaOperacaoByIDTela(int IDTela)
        {
            return from vwTelaop in entity.vwTelaOperacao 
                   where vwTelaop.IDTela == IDTela 
                   select vwTelaop;
        }

        public IQueryable GetTelaOperacaoByIDAplicacao(int IDTela)
        {
            return from vwTelaop in entity.vwTelaOperacao
                   where vwTelaop.IDTela == IDTela
                   select vwTelaop;
        }

        public IQueryable GetTelaOperacaoByIDOperacao(int IDOperacao)
        {
            return from vwTelaop in entity.vwTelaOperacao
                   where vwTelaop.IDOperacao == IDOperacao
                   select vwTelaop;
        }

        public IQueryable GetAllTelaOperacao()
        {
            return from vwTelaop in entity.vwTelaOperacao                   
                   select vwTelaop;
        }

    }
}
