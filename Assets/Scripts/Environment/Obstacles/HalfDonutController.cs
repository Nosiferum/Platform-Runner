using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Environment.Obstacles {

    public class HalfDonutController : MonoBehaviour {

        [SerializeField]
        private float movingSpeed = 5f;

        private const float MaxXvalue = 0.1375f;
        private const float MinXValue = -0.1413f;

        private bool _isReached = false;
        private Transform _movingStickTransform;

        private void Awake() {

            _movingStickTransform = transform.GetChild(0).GetChild(0).transform;
            _movingStickTransform.localPosition = Vector3.zero;           
        }

        private void Update() {

            if (!_isReached) {

                _movingStickTransform.Translate(Vector3.left * (movingSpeed * Time.deltaTime));

                if (_movingStickTransform.localPosition.x <= MinXValue)
                    _isReached = true;
            }

            else {

                _movingStickTransform.Translate(Vector3.right * (movingSpeed * Time.deltaTime));

                if (_movingStickTransform.localPosition.x >= MaxXvalue)
                    _isReached = false;
            }           
        }
    }
}
    
