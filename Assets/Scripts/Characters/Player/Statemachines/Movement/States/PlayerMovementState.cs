using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyGameForMED3
{
    public class PlayerMovementState : IState
    {
        protected PlayerMovementStateMachine StateMachine;

        protected Vector2 movementInput;

        protected float baseSpeed = 5f;
        protected float speedModifier = 1f;

        protected Vector3 CurrentTargetRotation;
        protected Vector3 TimeToReachTargetRotation;
        protected Vector3 DampedTargetRotationCurrentVelocity;
        protected Vector3 DampedTargetRotationPassedTime;

        protected bool ShouldWalk;
        public PlayerMovementState(PlayerMovementStateMachine PlayerMovementStateMachine)
        {
            StateMachine = PlayerMovementStateMachine;

            InitializeData();
        }

        private void InitializeData()
        {
            TimeToReachTargetRotation.y = 0.14f;
        }

        public virtual void Enter()
        {
                Debug.Log("State: " + GetType().Name);

            AddInputActionsCallBacks();
        }

        public virtual void Exit()
        {
            RemoveInputActionsCallBacks();
        }


        public virtual void HandleInput()
        {
            readMovementInput();
        }

        public virtual void Update()
        {
        }

        public virtual void PhysicsUpdate()
        {
            Move();
        }

        #region Main Methods
        private void readMovementInput()
        {
            movementInput = StateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
        }

        private void Move()
        {
            if (movementInput == Vector2.zero || speedModifier == 0f) 
            {
                return;
            }
            Vector3 movementDirection = GetMovementInputDirection();

            float targetRotationYAngle = Rotate(movementDirection);

            Vector3 targetRotationDirection = GetTargetRotationDirection(targetRotationYAngle);

            float movementSpeed = GetMovementSpeed();

            Vector3 CurrentPlayerHorizontalVelocity = GetPlayerHorizontalVelocity();

            StateMachine.Player.Rigidbody.AddForce(targetRotationDirection  * movementSpeed - CurrentPlayerHorizontalVelocity, ForceMode.VelocityChange);
        }

        private float Rotate(Vector3 direction)
        {
            float directionAngle = UpdateTargetRotation(direction);

            RotateTowardsTargetRotation();

            return directionAngle;
        }

        protected float UpdateTargetRotation(Vector3 direction, bool ShouldConsiderCameraRotation = true)
        {
            float directionAngle = GetDirectionAngle(direction);

            if (ShouldConsiderCameraRotation) 
            {
                directionAngle = AddCameraRotationToAngle(directionAngle);
            }

            if (directionAngle != CurrentTargetRotation.y)
            {
                UpdateTargetRotationData(directionAngle);
            }

            return directionAngle;
        }

        private void UpdateTargetRotationData(float TargetAngle)
        {
            CurrentTargetRotation.y = TargetAngle;

            DampedTargetRotationPassedTime.y = 0f;
        }

        private float AddCameraRotationToAngle(float Angle)
        {
            Angle += StateMachine.Player.MainCameraTransform.eulerAngles.y;

            if (Angle > 360f)
            {
                Angle -= 360f;
            }

            return Angle;
        }

        private static float GetDirectionAngle(Vector3 direction)
        {
            float directionAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            if (directionAngle < 0f)
            {
                directionAngle += 360f;
            }

            return directionAngle;
        }

        protected Vector3 GetPlayerHorizontalVelocity()
        {
            Vector3 playerHorizontalVelocity = StateMachine.Player.Rigidbody.velocity;

            playerHorizontalVelocity.y = 0f;
            return playerHorizontalVelocity;
        }

        #endregion
        protected Vector3 GetMovementInputDirection()
        {
            return new Vector3(movementInput.x, 0f, movementInput.y);
        }
        protected float GetMovementSpeed()
        {
            return baseSpeed * speedModifier;
        }
        private void RotateTowardsTargetRotation()
        {
            float CurrentYAngle = StateMachine.Player.Rigidbody.rotation.eulerAngles.y;

            if (CurrentYAngle == CurrentTargetRotation.y)
            {
                return;
            }

            float smoothedYAngle = Mathf.SmoothDampAngle(CurrentYAngle, CurrentTargetRotation.y, ref DampedTargetRotationCurrentVelocity.y, TimeToReachTargetRotation.y - DampedTargetRotationPassedTime.y);

            DampedTargetRotationPassedTime.y += Time.deltaTime;

            Quaternion TargetRotation = Quaternion.Euler(0f, smoothedYAngle, 0f);

            StateMachine.Player.Rigidbody.MoveRotation(TargetRotation);
        }
        protected Vector3 GetTargetRotationDirection(float targetAngle)
        {
            return Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }

        protected void ResetVelocity()
        {
            StateMachine.Player.Rigidbody.velocity = Vector3.zero;
        }
        protected virtual void AddInputActionsCallBacks()
        {
            StateMachine.Player.Input.PlayerActions.WalkToggle.started += OnWalkToggleStarted;
        }


        protected virtual void RemoveInputActionsCallBacks()
        {
            StateMachine.Player.Input.PlayerActions.WalkToggle.started -= OnWalkToggleStarted;
        }

        #region Input Methods
        protected virtual void OnWalkToggleStarted(InputAction.CallbackContext context)
        {
            ShouldWalk = !ShouldWalk;
        }

        #endregion
    }
}
