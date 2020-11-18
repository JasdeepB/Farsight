using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Windows.Forms;

namespace Farsight.LCU.Plugin_lol_perks
{
    class LolPerksV1
    {
        public LolPerksV1()
        {

        }

        public static void CreateNewRunePage(RunePage runePage)
        {
            if (LCUInterface.IsLCUActive())
            {
                string[] accessInfo = LCUInterface.GetClientAccessInfo();
                runePage.name = "Farsight Test";

                RestClient client = new RestClient();

                client.BaseUrl = new Uri("https://127.0.0.1:" + accessInfo[0] + "/lol-perks/v1/pages");
                client.RemoteCertificateValidationCallback = (sender, certifacate, chain, ssPolicyErrors) => true;

                RestRequest request = new RestRequest(Method.POST);

                client.Authenticator = new HttpBasicAuthenticator("riot", accessInfo[1]);

                request.AddParameter("application/json", "{\r\n    \"name\": \"" + runePage.name + "\"," +
                    "\r\n    \"primaryStyleId\": " + runePage.primaryStyleId + "," +
                    "\r\n    \"selectedPerkIds\": [\r\n        " + runePage.selectedPerkIds[0] + "," +
                    "\r\n        " + runePage.selectedPerkIds[1] + "," +
                    "\r\n        " + runePage.selectedPerkIds[2] + "," +
                    "\r\n        " + runePage.selectedPerkIds[3] + "," +
                    "\r\n        " + runePage.selectedPerkIds[4] + "," +
                    "\r\n        " + runePage.selectedPerkIds[5] + "," +
                    "\r\n        " + runePage.selectedPerkIds[6] + "," +
                    "\r\n        " + runePage.selectedPerkIds[7] + "," +
                    "\r\n        " + runePage.selectedPerkIds[8] + "\r\n    ]," +
                    "\r\n    \"subStyleId\": " + runePage.subStyleId + "\r\n}",
                    ParameterType.RequestBody);

                IRestResponse restResponse = client.Execute(request);
                Console.WriteLine(restResponse.StatusCode);
                Console.WriteLine(restResponse.Content);
            }
            else
            {
                MessageBox.Show("Make sure that you are signed into your league client before you attempt to send your rune page", "League not open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
