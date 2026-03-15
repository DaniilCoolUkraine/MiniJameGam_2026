using System;
using MiniJameGam.Player;
using UnityEngine;

namespace MiniJameGam.Fish.Behaviour
{
    [Serializable]
    public class AvoidPlayerFishBehaviour : IFishBehaviour
    {
        [SerializeField] private float _avoidanceRadius;
        [SerializeField] private int _idleSpeed;
        [SerializeField] private int _runSpeed;
        [SerializeField] private float _idleUpdateTime;
        [SerializeField] private float _idleWanderRadius;

        public float AvoidanceRadius => _avoidanceRadius;
        public float IdleWanderRadius => _idleWanderRadius;

        private IFish _fish;
        private IPlayer _player;

        private Vector2 _finalPosition;
        private bool _isRunning;
        private float _idleTimer;

        public IFishBehaviour Clone(IFish fish, IPlayer player)
        {
            return new AvoidPlayerFishBehaviour()
            {
                _fish = fish,
                _player = player,

                _avoidanceRadius = _avoidanceRadius,
                _idleSpeed = _idleSpeed,
                _runSpeed = _runSpeed,
                _idleUpdateTime = _idleUpdateTime,
                _idleWanderRadius = _idleWanderRadius
            };
        }

        public void Update()
        {
            // calculate distance and suggest location where to move at 
            var distance = Vector2.Distance(_fish.transform.position, _player.transform.position);
            if (distance < _avoidanceRadius)
            {
                _isRunning = true;
                var direction = (_fish.transform.position - _player.transform.position).normalized;
                _finalPosition = _fish.transform.position + direction * _avoidanceRadius;
            }
            else
            {
                _isRunning = false;
                _idleTimer -= Time.deltaTime;
                if (_idleTimer <= 0f)
                {
                    _idleTimer = _idleUpdateTime;
                    var randomDir = UnityEngine.Random.insideUnitCircle.normalized;
                    _finalPosition = (Vector2)_fish.transform.position + randomDir * _idleWanderRadius;
                }
            }
        }

        public void FixedUpdate()
        {
            var distance = Vector2.Distance(_fish.transform.position, _finalPosition);
            if (distance < 0.2f)
                return;

            _fish.MoveTowards(_finalPosition, _isRunning ? _runSpeed : _idleSpeed);
        }
    }
}