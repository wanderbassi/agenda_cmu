using Agenda.Model;
using Agenda.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Agenda.Presentation
{
    public partial class cadastrocliente : Form
    {
        MySqlConnection conexao;

        private ClienteService _clienteService { get; set; }
        public int X = 3, Y = 3, N = 0, id = 0;
        public cadastrocliente()
        {
            this._clienteService = new ClienteService();

            InitializeComponent();
        }

        private void CadastroCli(object sender, EventArgs e)
        {
            //Necessario pelo menos um telefone
            Criar_Telefone();
           
        }

        private void Criar_Telefone()
        {
            //Iniciando a classe masket text box
            MaskedTextBox mt = new MaskedTextBox();
            // mtxttel1 
            mt.Location = new System.Drawing.Point(X, Y);
            mt.Mask = "(00) 000000000 ";
            mt.Name = "Telefone" + id;
            mt.Size = new System.Drawing.Size(127, 23);
            mt.TabIndex = 27;
            panel1.Controls.Add(mt);
            Y += 25;
            id += 1;
        }

        private void cadastrocliente_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
            
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           Contato teste = new Contato((-1),txtnome.Text,"aaaa","aaaa-se","aaaa","aaaa", "aaaa", "3");; // TESTE TESTE TESTE
            Repository.Banco add = new Repository.Banco();
            add.UpdateContato(teste);
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void adtel_Click(object sender, EventArgs e)
        {
            //addtel
            Criar_Teleffone();
            ((MaskedTextBox)panel1.Controls["Telefone" + (id-1)]).Focus();
        }
    }
}
