using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIntegradorV1.Util
{
    public class ConexaoBD
    {
        public SqlConnection cn = new SqlConnection(Conn.StrCon);
        public void Conectar()
        {
            cn.Open();
            Console.WriteLine("Conectado ao banco de dados");
        }

    }
}
