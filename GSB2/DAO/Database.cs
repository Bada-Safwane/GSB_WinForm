using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace GSB2
{
    public class Database
    {

       private readonly string myConnectionString = "server=localhost;uid=root;pwd=root;database=bd_gsb";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(myConnectionString);
        }

    }
}
