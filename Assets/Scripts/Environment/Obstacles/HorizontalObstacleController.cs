using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Environment.Obstacles {

    public class HorizontalObstacleController : MonoBehaviour {

        [SerializeField]
        private float movingSpeed = 5f;

        [SerializeField]
        Transform start;

        [SerializeField]
        Transform destination;

        private bool isReached = false;

        private void Start() {

            transform.position = start.position;
        }

        private void Update() {

            if (!isReached) {

                transform.Translate(Vector3.right * movingSpeed * Time.deltaTime);

                if (transform.position.x >= destination.position.x)
                    isReached = true;
                
            }

            else {

                transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);

                if (transform.position.x <= start.position.x)
                    isReached = false;
            }               
        }
    }
}

   
