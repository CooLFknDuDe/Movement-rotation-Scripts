using UnityEngine;

namespace MyGameForMED3
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour
    {
        public Rigidbody Rigidbody {  get; private set; }
        public Transform MainCameraTransform { get; private set; }
        public PlayerInput Input {  get; private set; }

        private PlayerMovementStateMachine movementStateMachine;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();

            Input = GetComponent<PlayerInput>();

            movementStateMachine = new PlayerMovementStateMachine(this);

            MainCameraTransform = Camera.main.transform;

        }

        private void Start()
        {
            Input = GetComponent<PlayerInput>();
            movementStateMachine.ChangeState(movementStateMachine.IdlingState);
        }

        private void Update()
        {
            movementStateMachine.HandleInput();

            movementStateMachine.Update();
        }

        private void FixedUpdate()
        {
            movementStateMachine.PhysicsUpdate();
        }

    }
}
