using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceID
{
    class Create
    {

        //VS2012
        static string strCn = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mostratec\Documents\SH2\APIREALSENSE\FaceID\Database\SHDB.mdf;Integrated Security=True";
        //vs2015----MSSQLLocalDB
        //static string strCn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mostratec\Documents\SH2\APIREALSENSE\FaceID\Database\SHDB.mdf;Integrated Security=True";
        SqlConnection conexao = new SqlConnection(strCn);

        public void Adiciona(string nome, string fone, string nasc, string email, string ID_Cam)
        {
            //Console.WriteLine(nome+fone+nasc+email);
            //string adiciona = "insert into TableName (nome,fone,nasc) values '('" + nome + "','" + fone + "','" + nasc + "')'";

            SqlCommand cmd = new SqlCommand("INSERT INTO tbusers (nome,tel,email,nasc) VALUES ('"+nome+"','"+fone+"','"+nasc+"','"+email+ "','" + ID_Cam + "')");

            using (SqlConnection connection = new SqlConnection(strCn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexao;
            }

            try
            {
                conexao.Open();
                int resultado;
                resultado = cmd.ExecuteNonQuery();

                if (resultado != 0)
                {
                    Console.WriteLine("Registro adicionado com sucesso");
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
