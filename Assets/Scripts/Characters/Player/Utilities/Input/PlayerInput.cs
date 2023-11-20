using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameForMED3
{
    public class PlayerInput : MonoBehaviour
    {
        public PlayerInputActions InputActions {  get; private set; }
        public PlayerInputActions.PlayerActions PlayerActions {  get; private set; }

        private void Awake()
        {
            InputActions = new PlayerInputActions();

            PlayerActions = InputActions.Player;
        }

        private void OnEnable()
        {
            //InputActions.Disable();
            InputActions.Enable();
            //try {InputActions.Enable(); }
            //catch (Exception e) { Debug.Log($"{e.Message} and {e.Source}"); }
        }
        private void OnDisable()
        {
            InputActions.Disable();
        }
    }
}
