using System;
using DogukanKarabiyik.PlatformRunner.Managers;
using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed = 5f;
        [SerializeField] private float horizontalSpeed = 5f;
        
        private Rigidbody _rb;
        private Animator _animator;
        
        private Action _playerState;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
        }
        
        private void FixedUpdate()
        {
            _playerState?.Invoke();
        }
        
        private void GamePlayState()
        {
            Move();
        }

        private void Move()
        {
            _rb.velocity = Vector3.forward * forwardSpeed;
                
                if (Input.GetMouseButton(0))
                    _rb.velocity = Vector3.forward * forwardSpeed +
                                   (new Vector3(InputManager.Delta.x, 0, 0) * horizontalSpeed);
        }

        private void StopMovement()
        {
            _rb.velocity = Vector3.zero;
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
            SetStartingAnimation();
            _playerState = GamePlayState;
        }

        private void EndLineReachedBroadcast()
        {
            _playerState = null;
            StopMovement();
            SetEndingAnimation();
        }
        
        private void OnEnable()
        {
            StaticGameManager.OnLevelStart += StartBroadcast;
            StaticGameManager.OnEndLineReached += EndLineReachedBroadcast;
        }

        private void OnDisable()
        {
            StaticGameManager.OnLevelStart -= StartBroadcast;
            StaticGameManager.OnEndLineReached -= EndLineReachedBroadcast;
        }
    }
}