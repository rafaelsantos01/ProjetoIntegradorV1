using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIntegradorV1.Util
{
    public class Conn
    {
        private static string server = "Rafael";
        private static string dataBase = "JovemProgramador";
        private static string user = "sa";
        private static string password = "@Rfp238@";
        public static string StrCon
        {
            get { return $"Data Source={server}; Integrated Security=false;Initial Catalog={dataBase}; User ID={user}; Password={password}"; }
        }
    }
}
