using UnityEngine;

namespace Game {
    public class PlayerGO : MonoBehaviour, IPlayerView {
        [SerializeField] Transform playerTransform;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] PlayerJumpGO playerJumpGO;
        [SerializeField] PlayerMovementGO playerMovementGO;
        public Transform Transform => playerTransform;

        public Rigidbody2D Rigidbody => rb;

        public PlayerJumpGO JumpGO => playerJumpGO;

        public PlayerMovementGO MovementGO => playerMovementGO;
    }
}