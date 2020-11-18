using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Farsight
{
    class LCUInterface
    {
        public LCUInterface(mainScreen mainScreen)
        {
            Console.WriteLine(GetProcessListScript());
            Console.WriteLine(GetClientPort(GetProcessListScript()));
            Console.WriteLine(GetRemotingAuthToken(GetProcessListScript()));

            string clientLocationInfo = GetProcessListScript();
            SetSummonerOnLoad(mainScreen, GetClientPort(clientLocationInfo), GetRemotingAuthToken(clientLocationInfo));
        }

        private static void SetSummonerOnLoad(mainScreen mainScreen, string port, string key)
        {
            RestClient restClient = new RestClient();

            restClient.BaseUrl = new Uri("https://127.0.0.1:" + port + "/lol-summoner/v1/current-summoner");
            restClient.RemoteCertificateValidationCallback = (sender, certifacate, chain, ssPolicyErrors) => true; //Disable SSL Certifacation

            RestRequest restRequest = new RestRequest(Method.GET);

            restClient.Authenticator = new HttpBasicAuthenticator("riot", key);

            IRestResponse restResponse = restClient.Execute(restRequest);

            Console.WriteLine("Status Code: " + (int)restResponse.StatusCode);
            Console.WriteLine("Status message " + restResponse.Content);

            if ((int)restResponse.StatusCode == 200)
            {
                GetLolSummonerV1CurrentSummoner lol_Summoner = new GetLolSummonerV1CurrentSummoner();
                lol_Summoner = JsonConvert.DeserializeObject<GetLolSummonerV1CurrentSummoner>(restResponse.Content);

                PopulateUser(mainScreen, lol_Summoner.displayName);
            }
            else
            {
                MessageBox.Show("Bad LCU Request, make sure League is open", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static async void PopulateUser(mainScreen mainScreen, string summonerName)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + summonerName + "?api_key=" + JSONParser.APIKEY);

            if (response != null)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                User user = new User();
                user = JsonConvert.DeserializeObject<User>(jsonString);
                mainScreen.setSummoner(user);
            }
        }

        public static bool IsLCUActive()
        {
            Process[] processes = Process.GetProcessesByName("LeagueClientUx");
            if (processes.Length != 0)
            {
                return true;
            }
            return false;
        }

        public static void IsLCUActive(mainScreen mainScreen)
        {
            Process[] processes = Process.GetProcessesByName("LeagueClientUx");
            if (processes.Length != 0)
            {
                mainScreen.clientStatusLabel.ForeColor = Color.LimeGreen;
                mainScreen.clientStatusLabel.Text = "Client Online";
                return;
            }

            mainScreen.clientStatusLabel.ForeColor = Color.OrangeRed;
            mainScreen.clientStatusLabel.Text = "Client Offline";
        }

        public static string[] GetClientAccessInfo()
        {
            string[] info = null;

            if (IsLCUActive())
            {
                info = new string[2];
                info[0] = GetClientPort(GetProcessListScript());
                info[1] = GetRemotingAuthToken(GetProcessListScript());
            }

            return info;
        }

        public static string GetProcessListScript()
        {
            string output = "";

            Process process = new System.Diagnostics.Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C wmic PROCESS WHERE name='LeagueClientUx.exe' GET commandline";

            process.StartInfo = startInfo;
            process.Start();
            output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }

        public static string GetClientPort(string input)
        {
            string appPortPattern = @"--app-port=[0-9]*";

            Regex regex = new Regex(appPortPattern);
            Match match = regex.Match(input);
            string resultString = match.Value;

            return resultString.Substring(resultString.IndexOf("=") + 1);
        }

        public static string GetRemotingAuthToken(string input)
        {
            string remotingAuthTokenPattern = @"--remoting-auth-token=[\w-_]*";

            Regex regex = new Regex(remotingAuthTokenPattern);
            Match match = regex.Match(input);
            string resultString = match.Value;

            return resultString.Substring(resultString.IndexOf("=") + 1);
        }
    }
}
