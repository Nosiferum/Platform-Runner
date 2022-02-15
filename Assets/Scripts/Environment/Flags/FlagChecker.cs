using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.PlatformRunner.Control;

namespace DogukanKarabiyik.PlatformRunner.Environment.Flags {

    public class FlagChecker : MonoBehaviour {

        public bool isVisible { get; private set; } = false;

        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player") {

                var playerController = other.GetComponent<PlayerController>();

                playerController.isMoving = false;
                playerController.animator.SetBool("isMoving", false);
                isVisible = true;
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