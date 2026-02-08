using MiniJameGam.InputReader;
using UnityEngine;
using Zenject;

namespace MiniJameGam.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private Rigidbody2D _rb;

        [Header("Config")] 
        [SerializeField] private float _speed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _rotationSpeed;

        [Inject] private IInputReader _inputReader;

        private void Reset()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleMovement()
        {
            var force = new Vector2(_inputReader.GetHorizontalInput(), _inputReader.GetVerticalInput()) * _speed;

            _rb.AddForce(force, ForceMode2D.Impulse);
            Vector2 vel = _rb.linearVelocity;
            if (vel.magnitude > _maxSpeed)
            {
                _rb.linearVelocity = vel.normalized * _maxSpeed;
            }
        }
        
        private void HandleRotation()
        {
            Vector2 vel = _rb.linearVelocity;
            if (vel.sqrMagnitude > 0.1f) // avoid jitter when nearly still
            {
                float targetAngle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
                float smoothed = Mathf.LerpAngle(_rb.rotation, targetAngle, _rotationSpeed * Time.fixedDeltaTime);
                _rb.MoveRotation(smoothed);
            }
        }
    }
}