﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blue_Ward
{
    public partial class newMatchHistoryWindow : Form
    {
        private HttpClient client = new HttpClient();
        private matchHistory matchHistory = new matchHistory();
        private matchData matchData = new matchData();
        private List<matchData> allMatchData = new List<matchData>();
        private List<championMastery> championMasteryList = new List<championMastery>();
        Champion champion = new Champion();
        private mainScreen temp = new mainScreen();
        private string apiKey = "RGAPI-23deb3ef-cf46-4d60-9cc3-6e8824a9f7bb";

        public newMatchHistoryWindow(string accountID, Champion champion, mainScreen theMainScreen)
        {
            InitializeComponent();
            this.champion = champion;
            createMatchHistory(accountID);
            temp = theMainScreen;
        }

        public async void createMatchHistory(string accountID)
        {
            await PopulateMatchHistory(accountID);
        }
        private void matchHistoryButton_Click(object sender, EventArgs e)
        {
            createSelectedMatchHistory();           //Finds history for selected match & all champion masteries for all participants
        }

        public async Task createChampionMasteryHistory(string ID, int index)
        {
            await PopulateChampionMasteryHistory(ID, index);
        }

        public async void createSelectedMatchHistory()
        {
            await PopulateSelectedMatchHistory();
        }

        public async Task PopulateMatchHistory(string accountID)
        {
            HttpResponseMessage response = await client.GetAsync("https://na1.api.riotgames.com/lol/match/v4/matchlists/by-account/" + accountID + "?api_key=" + apiKey);

            if (response != null)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                matchHistory = JsonConvert.DeserializeObject<matchHistory>(jsonString);
                for (int i = 0; i < 100; i++)
                {
                    string temp = "";
                    champion.keys.TryGetValue(matchHistory.matches[i].champion, out temp);
                    matchHistory.matches[i].championName = temp;
                }
            }
        }

        public async Task PopulateChampionMasteryHistory(string ID, int index)
        {
            Thread.Sleep(150);
            HttpResponseMessage response = await client.GetAsync("https://na1.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/" + ID + "?api_key=" + apiKey);
            if (response != null)
            {
                championMastery temp1 = new championMastery();
                string jsonString = await response.Content.ReadAsStringAsync();
                temp1.championMasteries = JsonConvert.DeserializeObject<List<championMastery.ChampionMasteryDTO>>(jsonString);
                this.championMasteryList.Add(temp1);
                this.championMasteryList[index].summonerName = matchData.participantIdentities[index].player.summonerName;      //Uses participant data to insert summoner name into mastery list 
            }
            for (int i = 0; i < this.championMasteryList[index].championMasteries.Count; i++)                           //This adds champion names to all champion IDs in mastery.
            {
                int temp2 = Convert.ToInt32(this.championMasteryList[index].championMasteries[i].championId);
                champion.keys.TryGetValue(temp2, out string temp3);
                this.championMasteryList[index].championMasteries[i].championName = temp3;
            }
        }

        public async Task PopulateSelectedMatchHistory()
        {
            for (int k = 0; k < 5; k++)
            {
                Thread.Sleep(100);
                HttpResponseMessage response = await client.GetAsync("https://na1.api.riotgames.com/lol/match/v4/matches/" + matchHistory.matches[k].gameId + "?api_key=" + apiKey);

                if (response != null)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    matchData = JsonConvert.DeserializeObject<matchData>(jsonString);
                    for (int i = 0; i < 10; i++)
                    {
                        string temp = "";
                        champion.keys.TryGetValue(matchData.participants[i].championId, out temp);
                        matchData.participants[i].championName = temp;
                        matchData.participants[i].summonerName = matchData.participantIdentities[i].player.summonerName;
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        await createChampionMasteryHistory(matchData.participantIdentities[i].player.summonerId, i); //Finds champion mastery data for all 10 participants in a game
                    }

                    allMatchData.Add(matchData);
                }
            }
            temp.setData(matchHistory, allMatchData, championMasteryList);
        }
    }
}