using Zenject;

namespace Game {
    internal class PlayerInput : IPlayerInput {
        public IAttackInputListener AttackInputListener { get { return attackInputListener; } }
        public IJumpInputListener JumpInputListener { get { return jumpInputListener; } }
        public IWalkInputListener WalkInputListener { get { return walkInputListener; } }

        private IAttackInputListener attackInputListener;
        private IJumpInputListener jumpInputListener;
        private IWalkInputListener walkInputListener;
        [Inject]
        public PlayerInput(IAttackInputListener attack, IJumpInputListener jump, IWalkInputListener walk) {
            attackInputListener = attack;
            jumpInputListener = jump;
            walkInputListener = walk;
        }
    }

    internal interface IPlayerInput {
        IAttackInputListener AttackInputListener { get; }
        IJumpInputListener JumpInputListener { get; }
        IWalkInputListener WalkInputListener { get; }
    }
}