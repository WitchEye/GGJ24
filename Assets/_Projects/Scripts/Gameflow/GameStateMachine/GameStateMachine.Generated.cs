using JvLib.StateMachine;

namespace Project.StateMachines
{
    ///////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////
    // This code is generated. Your changes will be reverted on regeneration
    // Use GameStateMachine.cs
    ///////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////
    public partial class GameStateMachine : StateMachine<GameStates, GameState, GameStateMachine>
    {
        protected virtual void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            AddState<InitState>(GameStates.Init);
            AddState<MainMenuState>(GameStates.MainMenu);
            AddState<GameplayState>(GameStates.Gameplay);
            AddState<InitGameState>(GameStates.InitGame);
            AddState<GameOverState>(GameStates.GameOver);
            AddState<CharacterSelectState>(GameStates.CharacterSelect);

            CreateTransition(GameStates.Init, GameStates.MainMenu);
            CreateTransition(GameStates.InitGame, GameStates.Gameplay);
            CreateTransition(GameStates.Gameplay, GameStates.GameOver);
            CreateTransition(GameStates.GameOver, GameStates.MainMenu);
            CreateTransition(GameStates.MainMenu, GameStates.CharacterSelect);
            CreateTransition(GameStates.CharacterSelect, GameStates.InitGame);
            CreateTransition(GameStates.CharacterSelect, GameStates.MainMenu);


            SetStartState(GameStates.Init);

            EnterStartState();
        }
    }

    public enum GameStates
    {
        Init,
        MainMenu,
        Gameplay,
        InitGame,
        GameOver,
        CharacterSelect,
    }
}
