using Game.UI;
using UnityEngine;
using Zenject;

namespace Game {
    public class MainGameInstaller : MonoInstaller {
        [SerializeField] private UIController uiController;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private LevelGO levelSettings;
        private UIController uiControllerInstance;
        public override void InstallBindings() {
            BindInput();
            BindPlayer();
            BindLevel();
            BindUIController();
            BuildUi();
        }

        private void BindPlayer() {
            var playerInstance = Container.InstantiatePrefabForComponent<PlayerGO>(playerPrefab);
            Container.Bind<IPlayerView>().FromInstance(playerInstance).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MainPlayer>().AsSingle().NonLazy();
        }
        private void BindInput() {
            Container.BindInterfacesAndSelfTo<AttackInputListener>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JumpInputListener>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WalkInputListener>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle().NonLazy();
        }

        private void BindLevel() {
            Container.Bind<LevelGO>().FromInstance(levelSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<LevelFacade>().AsSingle().NonLazy();
        }
        private void BindUIController() {
            uiControllerInstance = Container.InstantiatePrefabForComponent<UIController>(uiController);
            Container.Bind<IUIController>().FromInstance(uiControllerInstance);
        }

        private void BuildUi() {
            uiControllerInstance.BuildUI(Container);
        }
    }
}