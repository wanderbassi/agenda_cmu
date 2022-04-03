using Agenda.Model;
using Agenda.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda.Presentation
{
    public partial class MainForm : Form
    {

        private ClienteService _clienteService { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }



        private void cadastroClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastrocliente telacliente = new cadastrocliente();
            telacliente.ShowDialog();

        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
    }
}
