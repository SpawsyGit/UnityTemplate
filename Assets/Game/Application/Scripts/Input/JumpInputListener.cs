using System;
using UnityEngine;

namespace Game {
    internal class JumpInputListener : InputUpdateListener, IJumpInputListener {
        public event Action OnJumpInputPressed;
        public event Action OnJumpInputReleased;
        private bool isPressed;
        public JumpInputListener(IMainAppUpdater updater) : base(updater) {
        }

        protected override void ListenForInput() {
            if (Input.GetButton("Jump")) {
                if (!isPressed) {
                    isPressed = true;
                    OnJumpInputPressed?.Invoke();
                }
            } else if (isPressed) {
                isPressed = false;
                OnJumpInputReleased?.Invoke();
            }
        }
    }
    internal interface IJumpInputListener {
        event Action OnJumpInputPressed;
        event Action OnJumpInputReleased;
    }
}