using System;
using UnityEngine;

namespace Game {
    internal class PlayerJump : IDisposable, IUpdateListener {
        public Action OnPlayerJump;

        private IJumpInputListener jumpInputListener;
        private IPlayerView playerView;
        private IMainAppUpdater mainAppUpdater;

        private bool isJumping;
        public PlayerJump(IJumpInputListener jumpListener, IPlayerView view, IMainAppUpdater updater) {
            jumpInputListener = jumpListener;
            mainAppUpdater = updater;
            playerView = view;

            mainAppUpdater.AddListener(this);
            jumpInputListener.OnJumpInputPressed += OnJumpInputPressed;
            jumpInputListener.OnJumpInputReleased += OnJumpInputReleased;
        }

        private void OnJumpInputPressed() {

            if (isJumping || !CheckGround()) return;
            isJumping = true;
            Jump();
            OnPlayerJump?.Invoke();
        }
        private void OnJumpInputReleased() {
            BreakJump();
        }

        private void Jump() {
            playerView.Rigidbody.AddForce(Vector2.up * playerView.JumpGO.JumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        private void BreakJump() {
            if (playerView.Rigidbody.velocity.y > 0)
                playerView.Rigidbody.velocity = new Vector2(playerView.Rigidbody.velocity.x, playerView.Rigidbody.velocity.y * 0.2f);
            isJumping = false;
        }
        private bool CheckGround() {
            var hit = Physics2D.OverlapCircle(playerView.Transform.position + (Vector3)playerView.JumpGO.GroundCheckOffset, 0.1f, playerView.JumpGO.GroundMask);
            if (hit != null && Mathf.Abs(playerView.Rigidbody.velocity.y) < 0.1f)
                return true;
            return false;
        }
        public void Dispose() {
            mainAppUpdater.RemoveListener(this);
            jumpInputListener.OnJumpInputPressed -= OnJumpInputPressed;
            jumpInputListener.OnJumpInputReleased -= OnJumpInputReleased;
        }

        public void OnUpdate(float deltaTime) {
            /*if (isJumping)
                Jump();*/
        }

        public void OnFixedUpdate(float fixedDeltaTime) {
            throw new NotImplementedException();
        }
    }
}