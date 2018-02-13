using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS485Light
{
    public class StandardWebService : ILedWebService
    {
        public StandardWebService(string Host, int Port)
        {

        }

        public bool SendData(byte Address, byte Intensity, byte Data)
        {
            var DataPackage = System.Convert.ToBase64String(new byte[] { 3, Address, Intensity, Data });

            var client = new RestClient(string.Format("http://localhost:50713/api/RS485?Base64EncodedDataPackage={0}", DataPackage));
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
