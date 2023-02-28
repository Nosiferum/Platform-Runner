using System;
using System.Collections;
using System.Collections.Generic;
using DogukanKarabiyik.PlatformRunner.Managers;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace DogukanKarabiyik.PlatformRunner.Control
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform destination;
        [field: SerializeField] public Transform StartPos { get; private set; }

        public Action OnEndReached;
        
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        
        private Action AIState;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }
        
        private void Start()
        {
            _navMeshAgent.speed = Random.Range(3, 7);
            _navMeshAgent.acceleration = Random.Range(3, 6);
        }

        private void Update()
        {
            AIState?.Invoke();
        }

        private void MoveToDestination()
        {
            _navMeshAgent.destination = destination.position;
        }
        
        private void SetStartingAnimation()
        {
            _animator.SetBool("isMoving", true);
        }

        private void SetEndingAnimation()
        {
            _animator.SetBool("isMoving", false);
        }
        
        private void StartBroadcast()
        {
            AIState = MoveToDestination;
            SetStartingAnimation();
        }

        private void EndLineReachedBroadcast()
        {
            AIState = null;
            SetEndingAnimation();
        }

        private void OnEnable()
        {
            StaticGameManager.OnLevelStart += StartBroadcast;
            OnEndReached += EndLineReachedBroadcast;
        }
        
        private void OnDisable()
        {
            StaticGameManager.OnLevelStart -= StartBroadcast;
            OnEndReached -= EndLineReachedBroadcast;
        }
    }
}