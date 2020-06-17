using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroWindowsForms.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }
        public DateTime DataNascimento { get; set; }

        public Usuario()
        {

        }

        public Usuario(string nome, string endereco, string email, string senha, bool admin, DateTime dataNascimento)
        {
            Nome = nome;
            Endereco = endereco;
            Email = email;
            Senha = senha;
            Admin = admin;
            DataNascimento = dataNascimento;
        }

        public void AlterarInformacoes(Usuario usuario)
        {
            Nome = usuario.Nome;
            Endereco = usuario.Endereco;
            Email = usuario.Email;
            Senha = usuario.Senha;
            Admin = usuario.Admin;
            DataNascimento = usuario.DataNascimento;
        }
    }
}
