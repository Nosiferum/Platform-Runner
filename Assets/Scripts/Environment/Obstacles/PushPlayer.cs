using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.PlatformRunner.Control;

namespace DogukanKarabiyik.PlatformRunner.Environment.Obstacles {

    public class PushPlayer : MonoBehaviour {

        [SerializeField]
        private float pushingForce = 5f;

        private void OnTriggerStay(Collider other) {

            if (other.CompareTag("Player")) 
                other.attachedRigidbody.AddForce(Vector3.back * pushingForce, ForceMode.Impulse);           
        }
    }
}




    
