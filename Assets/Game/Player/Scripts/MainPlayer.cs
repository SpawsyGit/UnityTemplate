using System;
using UnityEngine;
using Zenject;

namespace Game {
    internal class MainPlayer : IDisposable, IPlayer {
        private IPlayerView pView;

        private PlayerMovement pMovement;
        private PlayerJump pJump;

        private IMainAppUpdater mainAppUpdater;

        public IPlayerView PlayerView => pView;
        public Vector2 Position => PlayerView.Transform.position;

        [Inject]
        public MainPlayer(IPlayerView view, PlayerInput pInput, IMainAppUpdater updater) {
            mainAppUpdater = updater;
            pView = view;
            pMovement = new PlayerMovement(pInput.WalkInputListener, pView, mainAppUpdater);
            pJump = new PlayerJump(pInput.JumpInputListener, pView, mainAppUpdater);
        }
        public void Dispose() {
            pMovement.Dispose();
            pJump.Dispose();
        }
    }

    internal interface IPlayer {
        IPlayerView PlayerView { get; }
        Vector2 Position { get; }
    }
}