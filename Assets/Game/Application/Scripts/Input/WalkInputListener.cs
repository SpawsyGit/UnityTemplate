using System;
using UnityEngine;

namespace Game {
    internal class WalkInputListener : InputUpdateListener, IWalkInputListener {
        public event Action<float, float> OnWalkInput;

        private float horizontal = 0f;
        private float vertical = 0f;
        public WalkInputListener(IMainAppUpdater updater) : base(updater) { }

        protected override void ListenForInput() {
            horizontal = 0f;
            vertical = 0f;
            if (Input.GetButton("Horizontal")) {
                horizontal = Input.GetAxis("Horizontal");
                horizontal = ConvertToDiscrete(horizontal);
            }

            if (Input.GetButton("Vertical")) {
                vertical = Input.GetAxis("Vertical");
                vertical = ConvertToDiscrete(vertical);
            }
            OnWalkInput?.Invoke(horizontal, vertical);
        }
        private int ConvertToDiscrete(float value) {
            if (value > 0) return Mathf.CeilToInt(value);
            return value < 0 ? Mathf.FloorToInt(value) : 0;
        }
    }

    internal interface IWalkInputListener {
        event Action<float, float> OnWalkInput;
    }
}