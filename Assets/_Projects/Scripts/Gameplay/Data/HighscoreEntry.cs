namespace Project.Gameplay
{
    public struct HighscoreEntry
    {
        public string Name { get; private set; }
        public int Score { get; private set; }

        public HighscoreEntry(string pName, int pScore)
        {
            Name = pName;
            Score = pScore;
        }
    }
}
