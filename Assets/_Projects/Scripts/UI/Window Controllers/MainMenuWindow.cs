using JvLib.Services;
using JvLib.Windows;
using Project.Gameplay;
using TMPro;
using UnityEngine;

namespace Project.UI.Windows
{
    public class MainMenuWindow : Window, IOnWindowShow
    {
        [SerializeField] private TMP_Text[] _DailyHighscores;
        [SerializeField] private TMP_Text[] _AllTimeHighscores;

        private const string EMPTY_SCORE_ENTRY = "... - ";
        
        public void OnWindowShow(object context)
        {
            Svc.Gameplay.RefreshHighscores();
            for (int i = 0; i < _DailyHighscores.Length; i++)
            {
                _DailyHighscores[i].SetText(Svc.Gameplay.DailyHighscores.Count <= i
                    ? $"{(i + 1).ToString()}. {EMPTY_SCORE_ENTRY}"
                    : ParseHighscoreToString(i, Svc.Gameplay.DailyHighscores[i]));
            }
            
            for (int i = 0; i < _AllTimeHighscores.Length; i++)
            {
                _AllTimeHighscores[i].SetText(Svc.Gameplay.AllTimeHighscores.Count <= i
                    ? $"{(i + 1).ToString()}. {EMPTY_SCORE_ENTRY}"
                    : ParseHighscoreToString(i + 1, Svc.Gameplay.AllTimeHighscores[i]));
            }
        }

        private static string ParseHighscoreToString(int pPlace, HighscoreEntry pEntry) =>
            $"{pPlace.ToString()}. {pEntry.Name} - {pEntry.Score.ToString()}";
    }
}