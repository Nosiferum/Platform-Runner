using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DogukanKarabiyik.PlatformRunner.Control {

    public class EnemyController : MonoBehaviour {

        [SerializeField]
        private Transform destination;

        [field: SerializeField]
        public Transform start { get; private set; }

        private NavMeshAgent navMeshAgent;

        public Animator animator { get; set; }
        public bool isMoving { get; set; } = true;

        private void Awake() {

            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }


        private void Start() {

            navMeshAgent.speed = Random.Range(3, 7);
            navMeshAgent.acceleration = Random.Range(3, 6);
        }

        private void Update() {

            if (isMoving)
            navMeshAgent.destination = destination.position;
        }
    }
}

    
