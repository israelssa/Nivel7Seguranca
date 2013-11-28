using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nivel7DALSeguranca;
using System.Data.Objects;
using System.Linq.Expressions;

namespace Nivel7BLLSeguranca
{
    public class UsuarioBLL
    {
        Nivel7SegurancaEntities entity = new Nivel7SegurancaEntities();

        public Usuario GetUsuarioByID(int IDUsuario)
        {           
            return (from usuario in entity.Usuario 
                    where 
                    usuario.IDUsuario == IDUsuario 
                    select 
                    usuario).First<Usuario>();           
        }

        public List<vwAplicacaoUsuarioPerfil> GetUsuarioByWhere(Expression<Func<vwAplicacaoUsuarioPerfil, bool>> where)
        {
            return entity.vwAplicacaoUsuarioPerfil.Where(where).ToList<vwAplicacaoUsuarioPerfil>();
        }

        public List<vwAplicacaoUsuarioPerfil> GetUsuarioByName(string nome)
        {
            return (from usuario in entity.vwAplicacaoUsuarioPerfil 
                    where 
                    usuario.Nome.Contains(nome) && usuario.DataExclusao == null 
                    select 
                    usuario).ToList<vwAplicacaoUsuarioPerfil>();
        }

        public List<Usuario> GetAllUsuarioAtivo()
        {            
            return (from usuario in entity.Usuario 
                    where 
                    usuario.DataExclusao == null  
                    select 
                    usuario).ToList<Usuario>();
        }

        public List<vwAplicacaoUsuarioPerfil> GetAllUsuario()
        {
            return (from usuario in entity.vwAplicacaoUsuarioPerfil 
                    select 
                    usuario).ToList<vwAplicacaoUsuarioPerfil>();
        }

        public int InsertUsuario(Usuario usuarioEntity)
        {
            var idParameter = new ObjectParameter("IDUsuario", typeof(int));            
            entity.UsuarioInsert(idParameter,usuarioEntity.Nome,usuarioEntity.Email,usuarioEntity.TelefoneFixo,usuarioEntity.Celular,usuarioEntity.Bairro,usuarioEntity.Rua,usuarioEntity.Municipio,usuarioEntity.NumeroCasa,usuarioEntity.Estado);
            entity.SaveChanges();
            return (int)idParameter.Value;
        }

        public void UpdateUsuario(Usuario usuarioEntity)
        {
            entity.UsuarioUpdate(usuarioEntity.IDUsuario, usuarioEntity.Nome, usuarioEntity.Email, usuarioEntity.TelefoneFixo, usuarioEntity.Celular, usuarioEntity.Bairro, usuarioEntity.Rua, usuarioEntity.Municipio, usuarioEntity.NumeroCasa, usuarioEntity.Estado);
            entity.SaveChanges();
        }

        public void DeleteUsuario(int IDUsuario)
        {
            entity.UsuarioDelete(IDUsuario);
            entity.SaveChanges();
        }

        public List<vwAplicacaoUsuarioPerfil> GetAllUsuarioAplicacaoPerfilAtivo()
        {
            return (from associacao in entity.vwAplicacaoUsuarioPerfil 
                    where 
                    associacao.DataExclusao == null 
                    select associacao).ToList<vwAplicacaoUsuarioPerfil>();
        }     

        public UsuarioAplicacaoPerfil GetUsuarioAplicacaoPerfilByID(int IDAplicacao, int IDUsuario)
        {
            return (from associacao in entity.UsuarioAplicacaoPerfil 
                    where 
                    associacao.IDAplicacao == IDAplicacao && associacao.IDUsuario == IDUsuario 
                    select 
                    associacao).First<UsuarioAplicacaoPerfil>();
        }

        public void insertUsuarioAplicacaoPerfil(UsuarioAplicacaoPerfil associacao)
        {
            entity.UsuarioAplicacaoPerfilInsert(associacao.IDAplicacao, associacao.IDUsuario, associacao.IDPerfilSistema, associacao.Senha, associacao.AcessoPermitido);
        }

        public void UpdateUsuarioAplicacaoPerfil(int IDAplicacaoAtual, UsuarioAplicacaoPerfil usuarioAplicacaoPerfil)
        {
            entity.UsuarioAplicacaoPerfilUpdate(IDAplicacaoAtual, usuarioAplicacaoPerfil.IDAplicacao, usuarioAplicacaoPerfil.IDUsuario, usuarioAplicacaoPerfil.IDPerfilSistema, usuarioAplicacaoPerfil.Senha, usuarioAplicacaoPerfil.AcessoPermitido);
        }

        public void DeleteUsuarioAplicacaoPerfil(UsuarioAplicacaoPerfil associacao)
        {
            entity.DeleteObject(associacao);
            entity.SaveChanges();
        }

        public void AtualizarSenha(int IDUsuario, int IDAplicacao, string senha)
        {
            UsuarioAplicacaoPerfil usuarioaplicacaoperfil = GetUsuarioAplicacaoPerfilByID(IDAplicacao, IDUsuario);
            entity.UsuarioAplicacaoPerfilUpdate(IDAplicacao, IDAplicacao, IDUsuario, usuarioaplicacaoperfil.IDPerfilSistema, senha, usuarioaplicacaoperfil.AcessoPermitido);
        }

        public void DesativarUsuarioAplicacaoPerfil(int IDUsuario, int IDAplicacao)
        {
            entity.UsuarioAplicacaoPerfilDelete(IDAplicacao, IDUsuario);
        }

        public bool VerificaExistenciaRegistro(int idusuario, int idaplicacao)
        {
            if ((from existe in entity.UsuarioAplicacaoPerfil
                 where existe.IDAplicacao == idaplicacao && existe.IDUsuario == idusuario
                 select existe).Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
