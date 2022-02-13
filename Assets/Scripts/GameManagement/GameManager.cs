using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.PlatformRunner.Control;
using System.Linq;
using DogukanKarabiyik.PlatformRunner.Environment;

namespace DogukanKarabiyik.PlatformRunner.GameManagement {

    public class GameManager : MonoBehaviour {
        
        private EnemyController[] enemies;      
        private PlayerController player;
        private Dictionary<string, float> rankingDict = new Dictionary<string, float>();
        private PaintWall[] paintableWalls;
        
        private void Awake() {

            player = FindObjectOfType<PlayerController>();
            enemies = FindObjectsOfType<EnemyController>();
            paintableWalls = FindObjectsOfType<PaintWall>();
        }

        private void Start() {

            AddEntitiesToRankingDictionary();
        }

        private void Update() {

            CalculateRanking();
            CalculatePaintPercentage();
        }

        private void AddEntitiesToRankingDictionary() {

            rankingDict.Add(player.gameObject.name, 0);

            for (int i = 0; i < enemies.Length; i++)
                rankingDict.Add(enemies[i].gameObject.name, 0);
        }

        private void CalculateRanking() {

            rankingDict[player.gameObject.name] = player.transform.position.z;

            for (int i = 0; i < enemies.Length; i++)
                rankingDict[enemies[i].gameObject.name] = enemies[i].transform.position.z;

            var sortedDict = from entry in rankingDict orderby entry.Value descending select entry;
            
            int rank = 1;

            foreach (var pair in sortedDict)
                Debug.Log("Rank: " + rank++ + " Name: " + pair.Key);
        }

        private void CalculatePaintPercentage() {

            int total = paintableWalls.Length;
            int paintedWalls = 0;

            foreach (var wall in paintableWalls)
                if (wall.isPainted)
                    paintedWalls++;

            float percentage = (float) paintedWalls / total * 100;

            Debug.Log(percentage);
                        
        }
    }
}


