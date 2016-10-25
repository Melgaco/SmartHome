using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using FaceID.Database;

namespace FaceID
{
    class Actions
    {
        static Codigo codigo;
        public static MainWindow mw = new MainWindow();
        private static PXCMFaceData.RecognitionData recognitionData;
        

        public static void actions(string cod)
        {

            Console.WriteLine(cod);
            codigo = JsonConvert.DeserializeObject<Codigo>(cod);
                        
            switch (codigo.cod)
            {
                case "rect":
                    rect();
                    break;
                case "registerUser":
                    registerUser();
                    break;
                case "unregisterUser":
                    unregisterUser();
                    break;
            }
        }

        static void rect()
        {
            if (codigo.level == 1)
            {
                Server.conBROW1canWrite = codigo.rect;
            }
            if (codigo.level == 2)
            {
                Server.conBROW2canWrite = codigo.rect;
            }
            if (codigo.level == 3)
            {
                Server.conBROW3canWrite = codigo.rect;
            }
            //Server.sendMsg(codigo.level, "Rect level" + codigo.level + ": " + codigo.rect);       
            Console.WriteLine("Rect level" + codigo.level + ": " + codigo.rect);
        }

        static void registerUser()
        {
            
            var savedFile = mw.SaveDatabaseToFile();
            var userId = Convert.ToString(recognitionData.QueryUserID());

            Create create = new Create();
            create.Adiciona(codigo.nome, codigo.tel, codigo.age, codigo.email, userId);
        }

        static void unregisterUser()
        {
            Console.WriteLine("unregisterUser");            
        }

        
    }
}

class Codigo
{
    public int level { get; set; }
    public string cod { get; set; }

    public bool rect { get; set; }

    public string ID_Cam { get; set; }

    public string nome { get; set; }
    public string tel { get; set; }
    public string age { get; set; }
    public string email { get; set; }

}