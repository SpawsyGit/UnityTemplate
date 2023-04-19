using System;
using Zenject;

namespace Game {
    internal abstract class InputUpdateListener : IUpdateListener, IDisposable {
        private IMainAppUpdater mainAppUpdater;

        [Inject]
        protected InputUpdateListener(IMainAppUpdater updater) {
            mainAppUpdater = updater;
            mainAppUpdater.AddListener(this);
        }
        public void OnUpdate(float deltaTime) => ListenForInput();
        protected abstract void ListenForInput();

        protected virtual void OnDispose() => mainAppUpdater.RemoveListener(this);
        public void Dispose() => OnDispose();

    }
}