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
    public partial class TelaAdm : Form
    {
        public TelaAdm()
        {
            InitializeComponent();
            dataGridView1.DataSource = UsuarioRepository.Usuarios;
        }

    }
}
