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
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoIntegradorV1.Principal.Professor
{
    public partial class NovoCadastro : Form
    {
        public NovoCadastro()
        {
            InitializeComponent();
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
           String teste = comboBox1.SelectedItem.ToString();

            Pessoa ps = new Pessoa();
            ps.cpf = cpfBox.Text;
            ps.email = emailBox.Text;
            ps.nome = nomeBox.Text;
            ps.usuario = loginBox.Text;
            ps.senha = senhaBox.Text;
            ps.tipo = teste;

            ConexaoBD db = new ConexaoBD();
            db.Conectar();
            string sql = $"INSERT INTO pessoa (nome, saldo, email, cpf, tipo, usuario, senha) VALUES('{ps.nome}', 0, '{ps.email}', '{ps.cpf}', '{ps.tipo}', '{ps.usuario}', '{ps.senha}');";
            SqlCommand comando = new SqlCommand(sql, db.cn);
            comando.ExecuteNonQuery();
            MessageBox.Show("Cliente Cadastrado Com Sucesso!");
            cpfBox.Clear();
            emailBox.Clear();
            nomeBox.Clear();
            loginBox.Clear();
            senhaBox.Clear();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Professor pf = new Professor();
            pf.Show();
        }
    }
}
