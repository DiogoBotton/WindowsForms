using PrimeiroWindowsForms.Models;
using PrimeiroWindowsForms.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeiroWindowsForms
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            idioma.Items.Add("Português PT-BR");
            idioma.Items.Add("Inglês EN");

            UsuarioRepository.Usuarios.Add(new Usuario()
            {
                Id = 1,
                Email = "admin@email.com",
                Senha = "admin123",
                Admin = true,
                Nome = "Admin"
            });

            UsuarioRepository.Usuarios.Add(new Usuario()
            {
                Id = 1,
                Email = "usuario@email.com",
                Senha = "usuario123",
                Admin = false,
                Nome = "Usuário Normal"
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            relogio.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void idioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (idioma.SelectedIndex == 0)
            {
                label1.Text = "Email:";
                label2.Text = "Senha:";
                label3.Text = "Idioma:";

                button1.Text = "Entrar";
                button2.Text = "Sair";
                button3.Text = "Novo Usuário";
            }
            else
            {
                label1.Text = "Email:";
                label2.Text = "Password:";
                label3.Text = "Language:";

                button1.Text = "Login";
                button2.Text = "Exit";
                button3.Text = "New User";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                if (idioma.SelectedIndex == 0)
                    MessageBox.Show("Complete os campos obrigatórios para realizar o Login.");
                else
                    MessageBox.Show("Complete the required fields to login.");
            }
            else
            {
                var usuario = UsuarioRepository.Login(textBox1.Text, textBox2.Text);

                if (usuario == null)
                    MessageBox.Show("Usuário e/ou senha incorretos");
                else
                {
                    if (usuario.Admin)
                    {
                        TelaAdm adm = new TelaAdm();
                        adm.ShowDialog();
                    }
                    else
                    {
                        TelaUsuario u = new TelaUsuario();
                        u.ShowDialog();
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Tem certeza que deseja sair?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
