using System;
using UnityEngine;
namespace Game {
    internal class AttackInputListener : InputUpdateListener, IAttackInputListener {
        public event Action OnAttackInput;

        private const KeyCode attackButton = KeyCode.E;
        public AttackInputListener(IMainAppUpdater updater) : base(updater) {
        }

        protected override void ListenForInput() {
            if (Input.GetKeyDown(attackButton))
                OnAttackInput?.Invoke();
        }
    }
    internal interface IAttackInputListener {
        event Action OnAttackInput;
    }
}