using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.PlatformRunner.Environment.Flags;
using DogukanKarabiyik.PlatformRunner.Managers;

namespace DogukanKarabiyik.PlatformRunner.Environment.Walls
{
    public class PaintWall : MonoBehaviour
    {
        [SerializeField] private Material material;

        public Action OnWallPainted;

        private GameObject _wallFlag;
        private bool _isPainted = false;

        private void Awake()
        {
            GetComponent<MeshRenderer>().enabled = false;
        }

        private void Start()
        {
            _wallFlag = GameObject.FindGameObjectWithTag("WallFlag");
        }

        private void ActivateWall()
        {
            transform.parent.transform.position = _wallFlag.GetComponent<FlagChecker>().WallSpawnPos;
            GetComponent<MeshRenderer>().enabled = true;
        }
        
        private void OnMouseEnter()
        {
            if (!_isPainted)
            {
                GetComponent<MeshRenderer>().material = material;
                OnWallPainted?.Invoke();
                _isPainted = true;
            }
        }

        private void OnEnable()
        {
            StaticGameManager.OnEndLineReached += ActivateWall;
        }

        private void OnDisable()
        {
            StaticGameManager.OnEndLineReached -= ActivateWall;
        }
    }
}