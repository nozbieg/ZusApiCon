using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZusApiCon.Classes;
using ZusApiCon.zusApi;
using ZusApiCon.zusService;

namespace ZusApiCon
{
    class Program
    {
        public static void ZusPobierzOswiadczenie()
        {
            zla_PortTypeClient cc = CreateBinding();
            AppLogins ap = new AppLogins();
            cc.ClientCredentials.UserName.UserName = ap.Username;
            cc.ClientCredentials.UserName.Password = ap.Password;
            
            string ret = cc.pobierzOswiadczenie();
            Console.WriteLine(ret);
            SerializeModule(ret);
        }

        public static void SerializeModule(string ret) //Metoda Deserialuzująca dane do obiektów i przygotowująca do wprowadzenia do bazy danych 
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Oswiadczenie";
            Oswiadczenie retDeserialized = new Oswiadczenie();
            zla_PortTypeClient gusWebService = new zla_PortTypeClient();
            XmlSerializer serializer = new XmlSerializer(typeof(Oswiadczenie), xRoot);
            using (TextReader reader = new StringReader(ret))
            {
                retDeserialized = (Oswiadczenie)serializer.Deserialize(reader);
            }
            Console.WriteLine(retDeserialized.Tresc);
            Console.Write(retDeserialized.Data.ToString("yyyy-MM-dd "));
            Console.WriteLine(retDeserialized.Czas.ToString("HH:mm:ss"));            
            Console.WriteLine(retDeserialized.Token);
            
        }

        public static zla_PortTypeClient CreateBinding()
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            myBinding.MessageEncoding = WSMessageEncoding.Mtom;
            myBinding.Security.Mode = BasicHttpSecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            myBinding.MaxReceivedMessageSize = 65536 * 2;
            EndpointAddress ea = new EndpointAddress("https://pue.zus.pl:8001/ws/zus.channel.gabinetoweV2:zla");
            zla_PortTypeClient cc = new zla_PortTypeClient(myBinding, ea);
            return cc;
        }
        static void Main(string[] args)
        {
            ZusPobierzOswiadczenie();
            Console.ReadLine();
        }
    }
}
