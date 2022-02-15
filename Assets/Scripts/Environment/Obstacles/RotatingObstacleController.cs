using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Environment.Obstacles {

    public class RotatingObstacleController : MonoBehaviour {

        [SerializeField]
        private float rotatingSpeed = 5f;

        private Transform rotatingStickTransform;

        private void Awake() {

            rotatingStickTransform = transform.GetChild(1).transform;
        }

        private void Update() {

            rotatingStickTransform.Rotate(Vector3.up * rotatingSpeed * Time.deltaTime);          
        }
    }

}

