using UnityEngine;

namespace Game {
    public interface IPlayerView {
        Transform Transform { get; }
        Rigidbody2D Rigidbody { get; }
        PlayerJumpGO JumpGO { get; }
        PlayerMovementGO MovementGO { get; }
    }
}