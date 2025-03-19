using Unity.Netcode;
using UnityEngine;

namespace HelloWorld
{
    public class HelloWorldPlayer : NetworkBehaviour
    {
        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

        private float moveSpeed = 5f;

        public override void OnNetworkSpawn()
        {
            Position.OnValueChanged += OnStateChanged;

            if (IsOwner)
            {
                // Only the owner should be controlling the player.
                // Remove any automatic movement here.
            }
        }

        public override void OnNetworkDespawn()
        {
            Position.OnValueChanged -= OnStateChanged;
        }

        void OnStateChanged(Vector3 previous, Vector3 current)
        {
            // Sync the position across the network
            if (Position.Value != previous)
            {
                transform.position = Position.Value;
            }
        }

        void Update()
        {
            if (!IsOwner) return;  // Only the owner controls the player.

            // Detect movement using arrow keys or WASD.
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            // Move the player based on input
            Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;

            // Update the player's position
            transform.Translate(movement);

            // Sync the new position to the network
            Position.Value = transform.position;
        }
    }
}
