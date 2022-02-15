using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.PlatformRunner.Control;

namespace DogukanKarabiyik.PlatformRunner.Environment.Flags {

    public class FlagChecker : MonoBehaviour {

        public bool isVisible { get; private set; } = false;
        public Vector3 wallSpawnPos { get; private set; }

        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player") {

                var playerController = other.GetComponent<PlayerController>();

                playerController.isMoving = false;
                playerController.animator.SetBool("isMoving", false);
                isVisible = true;

                wallSpawnPos = other.transform.position + new Vector3(0.7f, 0.1f, 0.76f) + new Vector3(0, 0, 10);
            }

            else if (other.tag == "Enemy") {

                var enemyController = other.GetComponent<EnemyController>();

                enemyController.isMoving = false;
                enemyController.animator.SetBool("isMoving", false);
            }
        }

        private void OnTriggerExit(Collider other) {

            if (other.tag == "Player") {

                var playerController = other.GetComponent<PlayerController>();

                playerController.animator.SetBool("isMoving", true);
                playerController.isMoving = true;
                isVisible = false;

            }

            else if (other.tag == "Enemy") {

                var enemyController = other.GetComponent<EnemyController>();
              
                enemyController.animator.SetBool("isMoving", true);
                enemyController.isMoving = true;
            }
        }
    }
}
