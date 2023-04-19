using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class LevelGO : MonoBehaviour {
        [SerializeField] Transform playerSpawnPoint;

        public Transform PlayerSpawnPoint => playerSpawnPoint;
    }
}