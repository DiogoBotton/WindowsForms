using PrimeiroWindowsForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroWindowsForms.Repositories
{
    public class UsuarioRepository
    {
        public static List<Usuario> Usuarios = new List<Usuario>();

        public UsuarioRepository()
        {

        }

        public static void PostUsuario(Usuario usuario)
        {
            uint contador = (uint)Usuarios.Count + 1;
            usuario.Id = (int)contador;

            Usuarios.Add(usuario);
        }
        public static void DeleteUsuario(Usuario usuario)
        {
            Usuarios.RemoveAll(x => x.Id == usuario.Id);

            //Corrige os números ID's da lista para que não fique com um "buraco"
            int contador = 1;
            Usuarios.ForEach((x) =>
            {
                x.Id = contador;
                contador++;
            });
        }
        public static void PutUsuario(Usuario usuario)
        {
            //Usuarios.FirstOrDefault(x => x.Id == usuario.Id).AlterarInformacoes(usuario);

            foreach (Usuario u in Usuarios)
            {
                if (usuario.Id == u.Id)
                {
                    u.AlterarInformacoes(usuario);
                }
            }
        }

        public static Usuario GetUsuario(int id)
        {
            var usuario = Usuarios.FirstOrDefault(x => x.Id == id);

            return usuario == null ? null : usuario;
        }

        public static List<Usuario> GetAllUsuarios()
        {
            return Usuarios.ToList();
        }

        public static Usuario Login(string email, string senha)
        {
            var retorno = Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);

            return retorno == null ? null : retorno;
        }
    }
}
