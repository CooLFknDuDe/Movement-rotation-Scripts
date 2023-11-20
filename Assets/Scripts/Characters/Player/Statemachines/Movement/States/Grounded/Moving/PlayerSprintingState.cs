using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameForMED3
{
    public class PlayerSprintingState : PlayerMovementState
    {
        public PlayerSprintingState(PlayerMovementStateMachine PlayerMovementStateMachine) : base(PlayerMovementStateMachine)
        {
        }

        #region Istate Methods
        public override void Enter()
        {
            base.Enter();

            speedModifier = 1f;
        }
        #endregion


    }
}
