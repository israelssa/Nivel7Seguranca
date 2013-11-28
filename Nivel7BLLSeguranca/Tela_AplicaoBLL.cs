using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nivel7DALSeguranca;

namespace Nivel7BLLSeguranca
{
    public class Tela_AplicaoBLL
    {
        public void Insert(int IDAplicacao, int IDTela)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            entity.TelaAplicacaoInsert(IDAplicacao, IDTela);
            entity.SaveChanges();
        }

        public IQueryable GetTelaByIDAplicacao(int IDAplicacao)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            return from Operacao in entity.vwTelaAplicacao
                   where Operacao.IDAplicacao == IDAplicacao && Operacao.DataExclusao == null
                   select Operacao;
        }
        public IQueryable GetAplicacaoByIDTela(int IDTela)
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            return from Operacao in entity.vwTelaAplicacao
                   where Operacao.IDTela == IDTela
                   select Operacao;
        }
        public IQueryable GetAllTelaAplicacao()
        {
            Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
            return from Operacao in entity.vwTelaAplicacao               
                   select Operacao;
        }
    }
}
