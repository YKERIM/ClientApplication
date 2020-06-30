using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls.WebParts;

namespace ClientWCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceClient" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceClient.svc ou ServiceClient.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceClient : IServiceClient
    {
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2LKBDJM;Initial Catalog=ClientApplication;Integrated Security=True");
        public int compteur = 0;

        public string TokenApp(string TokenApp)
        {
            Guid Guid_TokenUser;
            string TokenUser = null;
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From UserList where TokenApp ='" + TokenApp + "' and State ='" + 1 + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {

                Guid_TokenUser = Guid.NewGuid();
                TokenUser = Guid_TokenUser.ToString();
                SqlDataAdapter sdb = new SqlDataAdapter("Update UserList set TokenUser = '" + Guid_TokenUser + "' where TokenApp ='" + TokenApp +  "'", con);
                sdb.Fill(dt);
            }
            else
            {
                
            }

            return TokenUser;
        }

        public string Decrypt(string text, string key)
        {
            var result = new StringBuilder();
            

            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));

            if (key == "ZZZZ")
            {
                compteur = compteur + 1;
                //System.Diagnostics.Debug.WriteLine(result.ToString());
                //System.Diagnostics.Debug.WriteLine("Thread " + compteur + " finished at : " + DateTime.Now);
            }

            return result.ToString();
        }

        public void DecryptLauncher(List<string> file_user, List<string> file_name)
        {
            
                string[] stringArray = new string[2];

                for (int i = 0; i < file_user.Count; i++)
                {
                    stringArray[0] = file_user[i];
                    stringArray[1] = file_name[i];

                    Thread t = new Thread(KeyDecryptor);
                    t.Start(stringArray);
                    Thread.Sleep(100);
                }
        }
        
        public void KeyDecryptor(Object args)
        {
            Array argArray = new object[2];
            argArray = (Array)args;
            string text = (string)argArray.GetValue(0);
            string name = (string)argArray.GetValue(1);

            int first = 0;
            int second = 0;
            int third = 0;
            int fourth = 0;
            string attempt = "";
            string[] array = {
            "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
            };
            System.Diagnostics.Debug.WriteLine("Thread 1 : begin at : " + DateTime.Now);

            while (attempt != "ZZZZ")
            {
                if (first == 26)
                {
                    second++;
                    first = 0;
                }
                
                if (second == 26)
                {
                    third++;
                    second = 0;
                }

                if (third == 26)
                {
                    fourth++;
                    third = 0;
                }

                if (fourth == 26)
                {
                    break;
                }
                attempt = array[fourth] + array[third] + array[second] + array[first];
                string decryptedText = Decrypt(text, attempt);
                sendToJava(name, decryptedText, attempt);
                first++;
            }
            System.Diagnostics.Debug.WriteLine("Name : " + name);
        }

        private void sendToJava(string fileName, string fileContent, string key)
        {
            using (var service = new ComService.ComEndpointClient("ComPort"))
            {
                var result = service.checkFileOperation(fileName, fileContent, key);
            }
        }

        public JavaFile getJavaFile(string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
            List<string> stringList = value.Split('|').ToList();

            JavaFile javaData = new JavaFile()
            {
                fileName = stringList[0],
                key = stringList[1],
                secretWord = stringList[2]
            };

            System.Diagnostics.Debug.WriteLine(javaData.fileName);
            System.Diagnostics.Debug.WriteLine(javaData.key);
            System.Diagnostics.Debug.WriteLine(javaData.secretWord);


            return javaData;

        }

        //Fonction pour envoyer les résultats par mail
        public void sendEmailResult()
        {
            string fromAdress = "dababy.letsgo45@gmail.com"; //Statique
            string toAddress = "sambao407@gmail.com"; // A Rendre dynamique
            MailMessage message = new MailMessage(fromAdress, toAddress); 

            const string subject = "Resultat de décryptage";
            const string body = "Veuillez vous connectez, le résultat pour votre demande de Bruteforce a été trouvé";
            message.Subject = subject;
            message.Body = body;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential()
            {
                UserName = "dababy.letsgo45@gmail.com",
                Password = "xor_project"
            };
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
    }
}