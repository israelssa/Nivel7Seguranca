using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nivel7DALSeguranca;
using System.Data.Objects;

namespace Nivel7BLLSeguranca
{
    public class TelaSistemaBLL
    {
        Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();
        public TelaSistema getTelaByID(int IDTela)
        {
           return (from tela in entity.TelaSistema where tela.IDTela == IDTela select tela).First<TelaSistema>();
        }

        public IQueryable GetAllTelaAtivos()
        {
            return (from tela in entity.TelaSistema where tela.DataExclusao == null select tela);
        }

        public IQueryable GetAllTela() 
        {
            return (from tela in entity.TelaSistema select tela);
        }

        public int Insert(TelaSistema telaEntity)
        {
            var idParameter = new ObjectParameter("IDTela", typeof(int));
            
            entity.TelaSistemaInsert(idParameter,telaEntity.IDAplicacao,telaEntity.NomeArquivo,telaEntity.CodigoTela,telaEntity.NomeArquivo);
            entity.SaveChanges();
            return (int)idParameter.Value;
        }

        public void Update(TelaSistema telaEntity)
        {
            entity.TelaSistemaUpdate(telaEntity.IDTela, telaEntity.IDAplicacao, telaEntity.NomeArquivo, telaEntity.CodigoTela, telaEntity.NomeArquivo);
            entity.SaveChanges();
        }

        public void Delete(int IDTela)
        {
            entity.TelaSistemaDelete(IDTela);
            entity.SaveChanges();
        }

    }
}
