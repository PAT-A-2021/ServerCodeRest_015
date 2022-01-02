using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceRest_20190140015_Muhamad_Arief_P_Suradi;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;


namespace ServerCodeRest_20190140015_Muhamad_Arief_P_Suradi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:9111/Mahasiswa");
            WebHttpBinding binding = new WebHttpBinding();

            try
            {
                hostObj = new ServiceHost(typeof(TI_UMY),address);
                hostObj.AddServiceEndpoint(typeof(ITI_UMY),binding,"");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                hostObj.Description.Behaviors.Add(smb);
                Binding mex = MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange),mex,"mex");

                WebHttpBehavior whb = new WebHttpBehavior();
                whb.HelpEnabled = true;
                hostObj.Description.Endpoints[0].EndpointBehaviors.Add(whb);

                hostObj.Open();
                Console.WriteLine("Servicenya nyala gan...");
                Console.ReadLine();
                hostObj.Close();
            }
            catch (Exception ex)
            {
                hostObj = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
