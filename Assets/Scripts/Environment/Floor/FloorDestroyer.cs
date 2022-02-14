using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Environment.Floor {

    public class FloorDestroyer : MonoBehaviour {

        private void OnTriggerExit(Collider other) {

            if (other.tag == "Player")
                Destroy(gameObject, 3.4f);        
        }
    }
}
  
