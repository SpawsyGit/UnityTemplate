using System;
using UnityEngine;
using Zenject;

namespace Game {
    internal class LevelFacade : IInitializable {
        public Action OnLevelInitialized;
        private readonly IPlayer player;
        private readonly LevelGO levelSettings;
        [Inject]
        public LevelFacade(IPlayer player, LevelGO levelSettings) {
            this.player = player;
            this.levelSettings = levelSettings;
        }
        public void Initialize() {
            OnLevelInitialized?.Invoke();
            StartLevel();
        }

        private void StartLevel() {
            SpawnPlayer(levelSettings.PlayerSpawnPoint);
        }
        private void SpawnPlayer(Transform spawnPoint) {
            player.PlayerView.Transform.position = spawnPoint.position;
        }
    }
}