using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DogukanKarabiyik.PlatformRunner.Control;
using DogukanKarabiyik.PlatformRunner.Managers;

namespace DogukanKarabiyik.PlatformRunner.Environment.Flags
{
    public class FlagChecker : MonoBehaviour
    {
        public Vector3 WallSpawnPos { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                WallSpawnPos = other.transform.position + new Vector3(0.7f, 0.1f, 0.76f) + new Vector3(0, 0, 10);
                
                StaticGameManager.EndLineReached();
            }

            else if (other.CompareTag("Enemy"))
            {
                var enemyController = other.GetComponent<EnemyController>();

                enemyController.OnEndReached?.Invoke();
            }
        }
    }
}