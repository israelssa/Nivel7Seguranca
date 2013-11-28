using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nivel7DALSeguranca;
using System.Data.Objects;

namespace Nivel7BLLSeguranca
{
    public class AplicacaoBLL
    {

        public Aplicacao GetAplicacaoByID(int IDAplicacao)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            return (from aplicacao in entity.Aplicacao where aplicacao.IDAplicacao == IDAplicacao select aplicacao).First<Aplicacao>();       
        }

        public IQueryable GetAllAplicacaoAtivos()
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            return from aplicacao in entity.Aplicacao where aplicacao.DataExclusao == null select aplicacao;       
        }

        public IQueryable GetAllAplicacao() 
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            return from aplicacao in entity.Aplicacao select aplicacao;
        }

        public int Insert(Aplicacao aplicacaoEntity)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            var idParameter = new ObjectParameter("ID", typeof(int));
           
            entity.AplicacaoInsert(idParameter, aplicacaoEntity.NomeAplicacao, aplicacaoEntity.Descricao);           
            entity.SaveChanges();
            return (int)idParameter.Value;
        }

        public void Update(Aplicacao aplicacaoEntity)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            entity.AplicacaoUpdate(aplicacaoEntity.IDAplicacao, aplicacaoEntity.NomeAplicacao, aplicacaoEntity.Descricao);
            entity.SaveChanges();
        }

        public void Delete(int IDAplicacao)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            entity.AplicacaoDelete(IDAplicacao);
            entity.SaveChanges();
        }
        
        
    }
}
