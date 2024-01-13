using System;
using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Behaviours
{
    public class Follow : IMove
    {
        public event Action onFinishMovement;
        public event Action onResumeMovement;

        private bool _isResumed;
        private float _speed;
        private Vector3 _targetNormalizedPosition;
        private Transform _target;
        private Transform _uniTransform;

        public Transform Target
        {
            set => _target = value;
        }
        //---------------------------------------------------------------------------------------------------------------
        public Follow(Transform uniTransform, Transform target, float speed)
        {
            _speed = speed;
            _target = target;
            _uniTransform = uniTransform;
            _isResumed = true;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Move()
        {
            Vector3 unitPosition = _uniTransform.position;

            RotateToDirection(NormalizeTargetPosition(_target.position));
            
            // move to point;
            if (Vector3.Distance(unitPosition, _target.position) > .5f)
            {
                _uniTransform.position =  Vector3.MoveTowards(unitPosition, _target.position, _speed * Time.deltaTime);
                
                if (!_isResumed)
                {
                    _isResumed = true;
                    onResumeMovement?.Invoke();
                }
            }
            else
            {
                onFinishMovement?.Invoke();
                _isResumed = false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void RotateToDirection( Vector3 unitPosition)
        {
            _uniTransform.LookAt(unitPosition);
        }
        //---------------------------------------------------------------------------------------------------------------
        private Vector3 NormalizeTargetPosition(Vector3 unitPosition)
        {
            float playerDistanceToFloor = unitPosition.y - _target.position.y;
            _targetNormalizedPosition =
                new Vector3(unitPosition.x, unitPosition.y + playerDistanceToFloor, unitPosition.z);
            return _targetNormalizedPosition;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}