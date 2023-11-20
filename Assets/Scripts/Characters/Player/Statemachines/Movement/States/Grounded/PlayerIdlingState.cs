using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyGameForMED3
{
    public class PlayerIdlingState : PlayerMovementState
    {
        public PlayerIdlingState(PlayerMovementStateMachine PlayerMovementStateMachine) : base(PlayerMovementStateMachine)
        {
        }

        #region IState Methods
        public override void Enter()
        {
            base.Enter();

            speedModifier = 0f;

            ResetVelocity();
        }

        public override void Update()
        {
            base.Update();

            if(movementInput == Vector2.zero)
            {
                return;
            }
            onMove();
        }

        private void onMove()
        {
            if (ShouldWalk)
            {
                StateMachine.ChangeState(StateMachine.WalkingState);

                return;
            }
            StateMachine.ChangeState(StateMachine.RunningState);
        }

        
        
    }
    #endregion
}
