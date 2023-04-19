using System;
using UnityEngine;

namespace Game {
    internal class PlayerMovement : IDisposable, IUpdateListener {

        public Action OnPlayerJump;

        private IWalkInputListener walkInputListener;
        private IPlayerView playerView;
        private IMainAppUpdater mainAppUpdater;

        private float timer;
        private float direction;
        private bool isMoving;
        public PlayerMovement(IWalkInputListener walkListener, IPlayerView view, IMainAppUpdater updater) {
            walkInputListener = walkListener;
            playerView = view;
            mainAppUpdater = updater;

            mainAppUpdater.AddListener(this);
            walkInputListener.OnWalkInput += OnWalkInput;
        }

        private void OnWalkInput(float x, float y) {
            if (x == 0) {
                Stop();
                return;
            }
            isMoving = true;
            direction = x;
            Move();
        }
        private void Stop() {
            playerView.Rigidbody.velocity = new Vector2(0f, playerView.Rigidbody.velocity.y);
            isMoving = false;
        }
        private void Move() {
            direction *= playerView.MovementGO.AccelerationCurve.Evaluate(timer);
            playerView.Rigidbody.velocity = new Vector2(direction * playerView.MovementGO.Speed * Time.deltaTime, playerView.Rigidbody.velocity.y);
        }
        public void Dispose() {
            mainAppUpdater.RemoveListener(this);
            walkInputListener.OnWalkInput -= OnWalkInput;
        }

        public void OnUpdate(float deltaTime) {
            if (isMoving)
                timer += Time.deltaTime;
            else if (timer > 0)
                timer = 0;
        }
    }
}