using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.PlatformRunner.Control;

namespace DogukanKarabiyik.PlatformRunner.Environment.Obstacles {

    public class ObstacleBehaviour : MonoBehaviour {

        private void OnTriggerEnter(Collider other) {

            if (other.CompareTag("Player"))            
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);

            if (other.CompareTag("Enemy"))
                other.transform.position = other.GetComponent<EnemyController>().StartPos.position;
        }      
    }
}
