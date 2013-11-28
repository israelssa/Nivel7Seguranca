using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nivel7DALSeguranca;
using System.Data.Objects;

namespace Nivel7BLLSeguranca
{
    public class OperacaoSistemaBLL
    {
        

        public OperacaoSistema getOperacaoByIDOperacao(int IDOperacao)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            return (from operacao in entity.OperacaoSistema 
                   where operacao.IDOperacao == IDOperacao
                   select operacao).First<OperacaoSistema>();
        }

        public IQueryable GetOperacoesAtivas() 
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            return from operacao in entity.OperacaoSistema 
                   where operacao.DataExclusao != null 
                   select operacao;
        }

        public IQueryable GetAllOperacao() 
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            return from operacao in entity.OperacaoSistema
                   select operacao;
        }

        public int InsertOperacao(OperacaoSistema operacaoEntity)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            var idParameter = new ObjectParameter("IDOperacao", typeof(int));            
            entity.OperacaoSistemaInsert(idParameter, operacaoEntity.IDAplicacao, operacaoEntity.NomeOperacao);
            entity.SaveChanges();
            return (int)idParameter.Value;
        }

        public void UpdateOperacao(OperacaoSistema operacaoEntity)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            entity.OperacaoSistemaUpdate(operacaoEntity.IDOperacao, operacaoEntity.IDAplicacao, operacaoEntity.NomeOperacao);
            entity.SaveChanges();
        }

        public void DeleteOperacao(int IDOPeracao)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            entity.OperacaoSistemaDelete(IDOPeracao);
        }

        public List<OperacaoSistema> GetOperacoesByIDAplicacao(int IDAplicacao)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            return (from operacao in entity.OperacaoSistema
                   where
                   operacao.IDAplicacao == IDAplicacao && operacao.DataExclusao == null
                   select
                   operacao).ToList<OperacaoSistema>();
        }

        public List<vwTelaOperacao> GetOperacoesDaTela(int IDTela)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            return (from operacao in entity.vwTelaOperacao
                   where
                   operacao.IDTela == IDTela && operacao.DataExclusao == null
                   select
                   operacao).ToList<vwTelaOperacao>();
        }

        public List<vwAplicacaoTelaOperacao> GetAplicacaoTelaOperacao(int IDAplicacao)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            return (from associacao in entity.vwAplicacaoTelaOperacao
                    where
                    associacao.IDAplicacao == IDAplicacao && associacao.Expr1 == null && associacao.Expr3 == null
                    select
                    associacao).ToList<vwAplicacaoTelaOperacao>();
        }
    }
}
