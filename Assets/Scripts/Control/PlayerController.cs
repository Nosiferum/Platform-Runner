using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Control {

    public class PlayerController : MonoBehaviour {

        [SerializeField]
        private float speed = 5f;

        private Rigidbody rigidbody;

        private void Awake() {

            rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }
    }
}


