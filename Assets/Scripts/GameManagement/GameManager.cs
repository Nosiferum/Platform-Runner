using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.PlatformRunner.Control;
using System.Linq;
using DogukanKarabiyik.PlatformRunner.Environment.Walls;
using TMPro;

namespace DogukanKarabiyik.PlatformRunner.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] rankingTextArray;
        [SerializeField] private TextMeshProUGUI percentageText;

        private EnemyController[] _enemies;
        private PlayerController _player;
        private Dictionary<string, float> _rankingDict = new Dictionary<string, float>();
        private PaintWall[] _paintableWalls;
        private int _paintedWalls = 0;
        
        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
            _enemies = FindObjectsOfType<EnemyController>();
            _paintableWalls = FindObjectsOfType<PaintWall>();
        }

        private void Start()
        {
            AddEntitiesToRankingDictionary();
        }

        private void Update()
        {
            RestartGame();
            QuitGame();

            CalculateRanking();
        }

        private void AddEntitiesToRankingDictionary()
        {
            _rankingDict.Add(_player.gameObject.name, 0);

            for (int i = 0; i < _enemies.Length; i++)
                _rankingDict.Add(_enemies[i].gameObject.name, 0);
        }

        private void CalculateRanking()
        {
            _rankingDict[_player.gameObject.name] = _player.transform.position.z;

            for (int i = 0; i < _enemies.Length; i++)
                _rankingDict[_enemies[i].gameObject.name] = _enemies[i].transform.position.z;

            var sortedDict = from playerAndEnemies in _rankingDict
                orderby playerAndEnemies.Value descending
                select playerAndEnemies;

            int rank = 1;
            int j = 0;

            foreach (var pair in sortedDict)
                rankingTextArray[j++].text = $"Rank{rank++}: {pair.Key}";
        }

        private void CalculatePaintPercentage()
        {
            int total = _paintableWalls.Length;
            _paintedWalls++;

            float percentage = (float)_paintedWalls / total * 100;

            percentageText.text = $"{percentage:N0}%";
        }

        private void RestartGame()
        {
            if (Input.GetKeyDown(KeyCode.R))
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        private void QuitGame()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
        
        private void OnEnable()
        {
            foreach (PaintWall paintableWall in _paintableWalls)
                paintableWall.OnWallPainted += CalculatePaintPercentage;
        }

        private void OnDisable()
        {
            foreach (PaintWall paintableWall in _paintableWalls)
                paintableWall.OnWallPainted -= CalculatePaintPercentage;
        }
    }
}