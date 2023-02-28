using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Environment.Floor {

    public class RotatingPlatformController : MonoBehaviour {

        [SerializeField]
        private float rotatingSpeed = 5f;

        private void Update() {

            transform.Rotate(Vector3.forward * (rotatingSpeed * Time.deltaTime));
        }
    }
}

    
