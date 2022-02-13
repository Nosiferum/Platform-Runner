using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.PlatformRunner.Control;

namespace DogukanKarabiyik.PlatformRunner.Environment.Obstacles {

    public class ObstacleBehaviour : MonoBehaviour {

        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player")            
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);

            if (other.tag == "Enemy")
                other.transform.position = other.GetComponent<EnemyController>().start.position;
        }      
    }
}
