using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace Project.Gameplay
{
    public partial class GameplayServiceManager // Highscores
    {
        public List<HighscoreEntry> DailyHighscores { get; private set; }
        public List<HighscoreEntry> AllTimeHighscores { get; private set; }
        private DateTime _dailyDate;

        public void RefreshHighscores()
        {
            DailyHighscores ??= new List<HighscoreEntry>();
            AllTimeHighscores ??= new List<HighscoreEntry>();

            ReadHighscores();
        }
        
        public void AddHighscore(string pName, int pScore)
        {
            DailyHighscores ??= new List<HighscoreEntry>();
            AllTimeHighscores ??= new List<HighscoreEntry>();
            bool writeFlag = false;

            if (_dailyDate != DateTime.Today)
            {
                DailyHighscores = new List<HighscoreEntry>();
                _dailyDate = DateTime.Today;
            }
            
            if (DailyHighscores.Min(e => e.Score) < pScore || DailyHighscores.Count < 10)
            {
                DailyHighscores.Add(new HighscoreEntry(pName, pScore));
                DailyHighscores = DailyHighscores.OrderByDescending(e => e.Score).ToList();
                if (DailyHighscores.Count > 10)
                    DailyHighscores.RemoveAt(DailyHighscores.Count - 1);
                writeFlag = true;
            }

            if (AllTimeHighscores.Min(e => e.Score) < pScore || AllTimeHighscores.Count < 10)
            {
                AllTimeHighscores.Add(new HighscoreEntry(pName, pScore));
                AllTimeHighscores = AllTimeHighscores.OrderByDescending(e => e.Score).ToList();
                if (AllTimeHighscores.Count > 10)
                    AllTimeHighscores.RemoveAt(AllTimeHighscores.Count - 1);
                writeFlag = true;
            }

            if (writeFlag) WriteHighscores();
        }

        private void WriteHighscores()
        {
            PlayerPrefs.SetString(nameof(_dailyDate), _dailyDate.ToString(CultureInfo.InvariantCulture));
            PlayerPrefs.SetString(nameof(DailyHighscores), JsonConvert.SerializeObject(DailyHighscores));
            PlayerPrefs.SetString(nameof(AllTimeHighscores), JsonConvert.SerializeObject(AllTimeHighscores));
            PlayerPrefs.Save();
        }

        private void ReadHighscores()
        {
            _dailyDate = DateTime.Today;
            
            string dateString = PlayerPrefs.GetString(nameof(_dailyDate), string.Empty);
            string dailyString = PlayerPrefs.GetString(nameof(DailyHighscores), string.Empty);
            string allTimeString = PlayerPrefs.GetString(nameof(AllTimeHighscores), string.Empty);

            if (!DateTime.TryParse(dateString, out DateTime dateTime))
                dateTime = DateTime.MinValue;
                
            if (dateTime == _dailyDate)
            {
                if (!string.IsNullOrWhiteSpace(dailyString))
                    DailyHighscores = JsonConvert.DeserializeObject<List<HighscoreEntry>>(dailyString);
            }
            else
            {
                DailyHighscores = new List<HighscoreEntry>();
                PlayerPrefs.DeleteKey(nameof(DailyHighscores));
                PlayerPrefs.Save();
            }
            
            if (!string.IsNullOrWhiteSpace(allTimeString))
                AllTimeHighscores = JsonConvert.DeserializeObject<List<HighscoreEntry>>(allTimeString);
        }
    }
}
