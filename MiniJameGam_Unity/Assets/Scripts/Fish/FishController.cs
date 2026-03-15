using MiniJameGam.Fish.Behaviour;
using UnityEngine;

namespace MiniJameGam.Fish
{
    public class FishController : MonoBehaviour, IFish
    {
        [SerializeField] private Player.PlayerController _player;

        [SerializeField] private FishDataSO _fishData;
        [SerializeField] private SpriteRenderer _renderer;

        [SerializeField] private Rigidbody2D _rb;
        
        private IFishBehaviour _behaviour;

        private void Awake()
        {
            _renderer.sprite = _fishData.Image;
            _behaviour = _fishData.Behaviour.Clone(this, _player);
        }

        private void Update()
        {
            _behaviour.Update();
        }

        private void FixedUpdate()
        {
            _behaviour.FixedUpdate();
            HandleRotation();
        }

        public void MoveTowards(Vector2 finalPosition, float speed)
        {
            var direction = (finalPosition - (Vector2)transform.position).normalized;
            var force = direction * speed;

            _rb.AddForce(force, ForceMode2D.Force);
            var vel = _rb.linearVelocity;
            if (vel.magnitude > speed)
            {
                _rb.linearVelocity = vel.normalized * speed;
            }
        }
        
        private void HandleRotation()
        {
            Vector2 vel = _rb.linearVelocity;
            if (vel.sqrMagnitude > 0.01f)
            {
                _renderer.flipX = vel.x > 0f;
                float targetAngle = Mathf.Atan2(vel.y, Mathf.Abs(vel.x)) * Mathf.Rad2Deg;
                if (vel.x < 0f) targetAngle = -targetAngle;
                float smoothed = Mathf.LerpAngle(_rb.rotation, targetAngle, 4 * Time.fixedDeltaTime);
                _rb.MoveRotation(smoothed);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_fishData != null)
            {
                _fishData.OnValidateEvent -= OnValidate; 
                _fishData.OnValidateEvent += OnValidate; 

                _renderer.sprite = _fishData.Image;
                _renderer.transform.rotation = Quaternion.Euler(0, 0, _fishData.SpriteRotation);
            }
        }
#endif
    }
}