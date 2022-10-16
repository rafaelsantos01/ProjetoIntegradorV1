using ProjetoIntegradorV1.Principal.Cliente;
using ProjetoIntegradorV1.Principal.Professor;
using ProjetoIntegradorV1.Util;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoIntegradorV1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            

            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();

            ClientePrincipal cl = new ClientePrincipal();
            Professor pf = new Professor();
            string login = textBox1.Text;
            string senha = textBox2.Text;
            pessoa  = buscarLogin(login,senha);

            if (pessoa.tipo == "Cliente")
            {
                cl.ReceberPessoa(pessoa);
                cl.Show();
                
            }
            else if (pessoa.tipo == "Professor")
            {

                pf.Show();
            }
            else
            {
                MessageBox.Show("LOGIN INCORRETO");
            }
        }

        public Pessoa  buscarLogin(string login,string senha)
        {
            Pessoa pessoa = new Pessoa();
            ConexaoBD db = new ConexaoBD();
            db.Conectar();
            string sql = $"SELECT * FROM Pessoa WHERE usuario = '{login}'";
            SqlCommand comando = new SqlCommand(sql, db.cn);
          
            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    pessoa.usuario = reader.GetString(reader.GetOrdinal("usuario"));
                    pessoa.senha  = reader.GetString(reader.GetOrdinal("senha"));
                    pessoa.tipo  = reader.GetString(reader.GetOrdinal("tipo"));
                    pessoa.id = reader.GetInt32(reader.GetOrdinal("id"));
                    pessoa.saldo = reader.GetInt32(reader.GetOrdinal("saldo"));
                    pessoa.cpf = reader.GetString(reader.GetOrdinal("cpf"));
                    pessoa.email = reader.GetString(reader.GetOrdinal("email"));
                    pessoa.nome = reader.GetString(reader.GetOrdinal("nome"));

                    if (login == pessoa.usuario && senha == pessoa.senha)
                    {
                        return pessoa;
                    }
                }
            }
            pessoa.tipo = "erro";
           return pessoa;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}