using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nivel7DALSeguranca;
using System.Data.Objects;

namespace Nivel7BLLSeguranca
{
    public class PerfilSistemaBLL
    {
        Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();

        public IQueryable GetPerfilSistemaByIDAplicacao(int IDAplicacao)
        {            
            return from perfil in entity.PerfilSistema 
                   where perfil.IDAplicacao == IDAplicacao && perfil.dataexclusao == null
                   select perfil;
        }

        public PerfilSistema GetPerfilSistemaByID(int IDPerfil)
        {
            return (from perfil in entity.PerfilSistema where perfil.IDPerfilSistema == IDPerfil select perfil).First<PerfilSistema>();
        }

        public int InsertPerfilSistema(PerfilSistema perfilsistema)
        {
            var idParameter = new ObjectParameter("IDPerfilSistema", typeof(int));
            entity.PerfilSistemaInsert(idParameter, perfilsistema.IDAplicacao, perfilsistema.NomePerfil);
            entity.SaveChanges();
            return (int)idParameter.Value;
        }

        public void UpdatePerfilSistema(PerfilSistema perfilsistema)
        {            
            entity.PerfilSistemaUpdate(perfilsistema.IDAplicacao,perfilsistema.IDAplicacao, perfilsistema.NomePerfil);                  
        }

        public void DeletePerfilSistema(int idperfilsistema)
        {
            entity.PerfilSistemaDelete(idperfilsistema);            
        }

        public List<vwPerfilUsuario> GetUsuarioDoPerfil(int IDPerfil)
        {
            return (from perfil in entity.vwPerfilUsuario where perfil.IDPerfilSistema == IDPerfil select perfil).ToList<vwPerfilUsuario>();
        }

        public List<vwOperacaoTelaPerfil> GetOperacoesDoPerfil(int IDPerfil)
        {
            return (from operacao in entity.vwOperacaoTelaPerfil where operacao.IDPerfilSistema == IDPerfil select operacao).ToList<vwOperacaoTelaPerfil>();
        }

        public void insertOperacaoTelaPerfil(int idoperacao, int idtela, int idperfil)
        {
            entity.OperacaoTelaPerfilInsert(idperfil, idtela, idoperacao);
        }

        public void deleteOperacaoTelaPerfil(int idoperacao, int idtela, int idperfil)
        {
            entity.OperacaoTelaPerfilDelete(idperfil, idtela, idoperacao);
        }

    }
}
