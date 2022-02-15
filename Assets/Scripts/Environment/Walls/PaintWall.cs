using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.PlatformRunner.Environment.Flags;

namespace DogukanKarabiyik.PlatformRunner.Environment.Walls {

    public class PaintWall : MonoBehaviour {

        [SerializeField]
        private Material material;

        private GameObject wallFlag;
        private bool isActivatedOnce = false;

        public bool isPainted { get; private set; }

        private void Awake() {

            wallFlag = GameObject.FindGameObjectWithTag("WallFlag");
            GetComponent<MeshRenderer>().enabled = false;
        }

        private void Update() {
            
            if (!isActivatedOnce) {

                if (wallFlag.GetComponent<FlagChecker>().isVisible) {

                    transform.parent.transform.position = wallFlag.GetComponent<FlagChecker>().wallSpawnPos;
                    GetComponent<MeshRenderer>().enabled = true;
                }
            }                  
        }

        private void OnMouseOver() {

            GetComponent<MeshRenderer>().material = material;
            isPainted = true;
        }
    }
}


