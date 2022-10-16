using ProjetoIntegradorV1.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoIntegradorV1.Principal.Cliente
{
    public partial class ClientePrincipal : Form
    {
        long id;
        string name;
        string cpf;
        long saldo;

        public ClientePrincipal()
        {
            InitializeComponent();
         
        }
        public void ReceberPessoa(Pessoa pessoa)
        {
           this.id = pessoa.id;
           this.name = pessoa.nome;
           this.cpf = pessoa.cpf;
           this.saldo = pessoa.saldo;
           label1.Text = "Bem Vindo: " + pessoa.nome;
           label3.Text = Convert.ToString("Saldo:" + pessoa.saldo);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //aqui
            Boolean creditos25 = checkBox2.Checked;
            Boolean creditos50 = checkBox4.Checked;

            if (creditos25 == true)
            {
                int creditos = 25;
                comprarCredito(creditos);
                MessageBox.Show("FAVOR ENVIAR COMPROVANTE PARA O WhatsApp da Secretaria XX-XXXXXXX");
                
            }
            else if (creditos50 == true)
            {
                int creditos = 50;
                comprarCredito(creditos);
                MessageBox.Show("FAVOR ENVIAR COMPROVANTE PARA O WhatsApp da Secretaria XX-XXXXXXX");
            }
            checkBox4.Checked = false;
            checkBox2.Checked = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public Boolean comprarCredito(int creditos)
        {

            string Date = DateTime.Now.ToString("yyyy-MM-dd");

            ConexaoBD db = new ConexaoBD();
            db.Conectar();  


            string sql = $"INSERT INTO compra (pago, [data], idPessoa, quantidade) VALUES(0, '{Date}', {this.id}, {creditos})";
            SqlCommand comando = new SqlCommand(sql, db.cn);
            comando.ExecuteNonQuery();
            return true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
           
        }

        private void ClientePrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");
            string link = textBox1.Text;
            string quantidade = textBox2.Text;
            int convert = Convert.ToInt32(quantidade);

            ConexaoBD db = new ConexaoBD();
            db.Conectar();

            string sql = $"INSERT INTO impressao (idPessoa, quantidade, data, impressao) VALUES({this.id}, {convert}, '{Date}', '{link}')";
            SqlCommand comando = new SqlCommand(sql, db.cn);
            comando.ExecuteNonQuery();

            long result = this.saldo - convert;

            string sql2= $"UPDATE pessoa SET  saldo={result} WHERE id={this.id};";
            SqlCommand comando2 = new SqlCommand(sql2, db.cn);
            comando2.ExecuteNonQuery();

            MessageBox.Show("Impressão Enviada Com Sucesso");
            this.saldo = result;
            label3.Update();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
