using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Environment.Floor {

    public class FloorSpawner : MonoBehaviour {

        [SerializeField]
        private GameObject floor;

        private const float InitialZSpawnPos = 3.5f;
        private Vector3 _spawnPos = new Vector3(0, 0, InitialZSpawnPos);
        private const int FloorCount = 6;

        private void Awake() {
            
            for (int i = 0; i < FloorCount; i++) 
                SpawnFloor();            
        }

        public void SpawnFloor() {

            GameObject floorGO = Instantiate(floor, _spawnPos, Quaternion.identity);
            _spawnPos = floorGO.transform.GetChild(1).transform.position;
        }

    }
}


