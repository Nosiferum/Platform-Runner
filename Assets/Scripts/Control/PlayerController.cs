using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Control {

    public class PlayerController : MonoBehaviour {

        [SerializeField]
        private float runnigSpeed = 5f;

        [SerializeField]
        private float movingSpeed = 5f;

        public Animator animator { get; set; }
        public bool isMoving { get; set; } = true;

        private void Awake() {

            animator = GetComponent<Animator>();
        }

        private void Update() {

            if (isMoving) {

                transform.Translate(Vector3.forward * runnigSpeed * Time.deltaTime);

                if (Input.GetKey(KeyCode.Mouse0))
                    transform.Translate(Vector3.right * movingSpeed * Time.deltaTime);

                else if (Input.GetKey(KeyCode.Mouse1))
                    transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
            }                                    
        }
    }
}


