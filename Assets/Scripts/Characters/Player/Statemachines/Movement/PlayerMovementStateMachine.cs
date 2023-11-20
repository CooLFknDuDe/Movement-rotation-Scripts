namespace MyGameForMED3
{
    public class PlayerMovementStateMachine : StateMachine
    {
      public Player Player { get; set; }
      public PlayerIdlingState IdlingState { get; set; } 

      public PlayerWalkingState WalkingState { get; set; } 
    
      public PlayerRunningState RunningState { get; set; } 

      public PlayerSprintingState SprintingState { get; set; }   

      public PlayerMovementStateMachine(Player player)
      {
            Player = player;

            IdlingState = new PlayerIdlingState(this);

            WalkingState = new PlayerWalkingState(this);
            RunningState = new PlayerRunningState(this);
            SprintingState = new PlayerSprintingState(this);
      }
    }
}
