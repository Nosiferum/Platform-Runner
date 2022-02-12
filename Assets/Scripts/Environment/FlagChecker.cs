using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.PlatformRunner.Control;

namespace DogukanKarabiyik.PlatformRunner.Environment {

    public class FlagChecker : MonoBehaviour {

        private void OnTriggerEnter(Collider other) {

            if (other.tag == "Player")
                other.GetComponent<PlayerController>().isMoving = false;
        }

    }

}
