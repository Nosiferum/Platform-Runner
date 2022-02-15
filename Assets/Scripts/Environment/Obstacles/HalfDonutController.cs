using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Environment.Obstacles {

    public class HalfDonutController : MonoBehaviour {

        [SerializeField]
        private float movingSpeed = 5f;

        private float maxXvalue = 0.1375f;
        private float minXValue = -0.1413f;

        private bool isReached = false;
        private Transform movingStickTransform;

        private void Awake() {

            movingStickTransform = transform.GetChild(0).GetChild(0).transform;
            movingStickTransform.localPosition = Vector3.zero;           
        }

        private void Update() {

            if (!isReached) {

                movingStickTransform.Translate(Vector3.left * movingSpeed * Time.deltaTime);

                if (movingStickTransform.localPosition.x <= minXValue)
                    isReached = true;
            }

            else {

                movingStickTransform.Translate(Vector3.right * movingSpeed * Time.deltaTime);

                if (movingStickTransform.localPosition.x >= maxXvalue)
                    isReached = false;
            }           
        }
    }
}
    
