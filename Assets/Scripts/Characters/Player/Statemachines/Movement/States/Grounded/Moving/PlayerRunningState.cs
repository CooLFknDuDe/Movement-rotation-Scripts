using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameForMED3
{
    public class PlayerRunningState : PlayerMovementState
    {
        public PlayerRunningState(PlayerMovementStateMachine PlayerMovementStateMachine) : base(PlayerMovementStateMachine)
        {
        }
    }
}
