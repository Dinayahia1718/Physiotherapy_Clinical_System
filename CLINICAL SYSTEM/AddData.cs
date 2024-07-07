using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CLINICAL_SYSTEM
{
    internal class AddData
    {
        public void adding(string query)
        {
            string cs = ConfigurationManager.ConnectionStrings["db"].ToString();
            MySqlConnection con = new MySqlConnection(cs);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
