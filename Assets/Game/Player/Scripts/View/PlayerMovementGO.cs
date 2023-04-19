using UnityEngine;

namespace Game {
    public class PlayerMovementGO : MonoBehaviour {
        [SerializeField] private AnimationCurve accelerationCurve;
        [SerializeField] private float speed = 750f;

        public AnimationCurve AccelerationCurve => accelerationCurve;
        public float Speed => speed;
    }
}