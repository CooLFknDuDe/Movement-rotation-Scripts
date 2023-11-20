using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyGameForMED3
{
    public class PlayerWalkingState : PlayerMovementState
    {
        public PlayerWalkingState(PlayerMovementStateMachine PlayerMovementStateMachine) : base(PlayerMovementStateMachine)
        {
        }

        #region IState Methods
        public override void Enter()
        {
            base.Enter();

            speedModifier = 0.255f;
        }
        #endregion

        #region Reusable Methods
        protected override void AddInputActionsCallBacks()
        {
            base.AddInputActionsCallBacks();
            StateMachine.Player.Input.PlayerActions.Movement.canceled += OnMovementCancled;
        }

        protected override void RemoveInputActionsCallBacks()
        {
            base.RemoveInputActionsCallBacks();

            StateMachine.Player.Input.PlayerActions.Movement.canceled -= OnMovementCancled;
        }
        #endregion

        #region Input Methods
        protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            base.OnWalkToggleStarted(context);
            StateMachine.ChangeState(StateMachine.RunningState);
        }
        protected void OnMovementCancled(InputAction.CallbackContext context)
        {
            StateMachine.ChangeState(StateMachine.IdlingState);
        }

        #endregion

    }
}
