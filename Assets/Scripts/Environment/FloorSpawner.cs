using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Environment {

    public class FloorSpawner : MonoBehaviour {

        [SerializeField]
        private GameObject floor;

        private const float initialZSpawnPos = 3.5f;
        private Vector3 spawnPos = new Vector3(0, 0, initialZSpawnPos);
        private const int floorCount = 6;

        private void Awake() {
            
            for (int i = 0; i < floorCount; i++) {

                SpawnFloor();
            }
        }

        public void SpawnFloor() {

            GameObject floorGO = Instantiate(floor, spawnPos, Quaternion.identity);
            spawnPos = floorGO.transform.GetChild(1).transform.position;
        }

    }
}


