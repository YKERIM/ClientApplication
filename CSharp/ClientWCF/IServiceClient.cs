using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClientWCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceClient" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceClient
    {
        [OperationContract]
        string TokenApp(string token);

        [OperationContract]
        string Decrypt(string text, string key);

        [OperationContract]
        void DecryptLauncher(List<string> file_user, List<string> file_name);

        [OperationContract]
        void sendEmailResult();

        [OperationContract(Name = "getJavaFile")]
        [WebGet(UriTemplate = "getJavaFile/{value}")]
        JavaFile getJavaFile(string value);
    }

    [DataContract]
    public class JavaFile
    {
        [DataMember]
        public string fileName { get; set; }

        [DataMember]
        public string key { get; set; }

        [DataMember]
        public string secretWord { get; set; }
    }
}
