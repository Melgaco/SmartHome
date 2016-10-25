using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceID.Database
{
    class Update
    {
       /* string nome = "Json.Nome";
        string fone = "Json.Fone";
        string nasc = "Json.Date";
        string mail = "Json.Mail";*/
        //VS2012
        static string strCn = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mostratec\Documents\SH2\APIREALSENSE\FaceID\Database\SHDB.mdf;Integrated Security=True";
        //VS2015
        //static string strCn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mostratec\Documents\SH2\APIREALSENSE\FaceID\Database\SHDB.mdf;Integrated Security=True";
        SqlConnection conexao = new SqlConnection(strCn);

        private void Altera(string nome, string fone, string nasc, string email)
        {

            string altera = "update tbusers set Nome= '" + nome + "', Fone= '" + fone + "', Email= '" + email + "where nome=" + nome;

            SqlCommand cmd = new SqlCommand(altera, conexao);
            try
            {
                conexao.Open();
                int resultado;
                resultado = cmd.ExecuteNonQuery();

                if (resultado == 1)
                {
                    Console.WriteLine("Registro alterado com sucesso");
                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //exiba qual é o erro
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
