using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.PlatformRunner.Environment.Flags;

namespace DogukanKarabiyik.PlatformRunner.Environment.Walls {

    public class PaintWall : MonoBehaviour {

        [SerializeField]
        private Material material;

        private GameObject wallFlag;

        public bool isPainted { get; private set; }


        private void Awake() {

            wallFlag = GameObject.FindGameObjectWithTag("WallFlag");
            GetComponent<MeshRenderer>().enabled = false;
        }

        private void Update() {
            
            if (wallFlag.GetComponent<FlagChecker>().isVisible)
                GetComponent<MeshRenderer>().enabled = true;
        }

        private void OnMouseOver() {

            GetComponent<MeshRenderer>().material = material;
            isPainted = true;
        }
    }
}


