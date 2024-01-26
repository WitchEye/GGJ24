namespace Project.StateMachines
{
    ///////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////
    // This code is generated. Your changes will be reverted on regeneration
    // Use CharacterSelectState.cs
    ///////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////
    public partial class CharacterSelectState
    {
        protected void TransitionToInitGameState()
        {
            StateMachine.TransitionTo(GameStates.InitGame);
        }
        protected void TransitionToMainMenuState()
        {
            StateMachine.TransitionTo(GameStates.MainMenu);
        }
    }
}
