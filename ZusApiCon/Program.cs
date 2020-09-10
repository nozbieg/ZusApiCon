using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ZusApiCon.zusApi;
using ZusApiCon.zusService;

namespace ZusApiCon
{
    class Program
    {
        public static void Zus()
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            myBinding.MessageEncoding = WSMessageEncoding.Mtom;           
            myBinding.Security.Mode = BasicHttpSecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            myBinding.MaxReceivedMessageSize = 65536 * 2;
            EndpointAddress ea = new EndpointAddress("https://pue.zus.pl:8001/ws/zus.channel.gabinetoweV2:zla");
            zla_PortTypeClient cc = new zla_PortTypeClient(myBinding, ea);
            cc.ClientCredentials.UserName.UserName = "ezla_ag";
            cc.ClientCredentials.UserName.Password = "ezla_ag";
            
            string ret = cc.pobierzOswiadczenie();
            Console.WriteLine(ret);
        }


        static void Main(string[] args)
        {
            Zus();
            Console.ReadLine();
        }
    }
}
