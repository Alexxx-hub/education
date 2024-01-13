using System;
using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Behaviours
{
    public class MoveToPoint : IMove
    {
        public event Action onFinishMovement;
        
        private bool _isRotated;
        private float _speed;
        private Vector3 _targetPoint;
        private Transform _uniTransform;

        public Vector3 TargetPoint
        {
            set
            {
                _targetPoint = value;
                _isRotated = false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        public MoveToPoint(Transform unit, Vector3 target, float speed)
        {
            _speed = speed;
            _targetPoint = target;
            _uniTransform = unit;
            _isRotated = false;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Move()
        {
            Vector3 unitPosition = _uniTransform.position;
            
            float playerDistanceToFloor = unitPosition.y - _targetPoint.y;
            _targetPoint.y += playerDistanceToFloor;
            
            if (!_isRotated)
            {
                RotateToDirection(unitPosition);
            }
            
            // move to point;
            if (Vector3.Distance(unitPosition, _targetPoint) > 0.1f)
            {
                _uniTransform.position =  Vector3.MoveTowards(unitPosition, _targetPoint, _speed * Time.deltaTime);
            }
            else
            {
                onFinishMovement?.Invoke();
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void RotateToDirection( Vector3 unitPosition)
        {
            Vector3 direction = (_targetPoint - unitPosition).normalized;
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
            _uniTransform.rotation = Quaternion.Euler(0, 90 - angle, 0);
            _isRotated = true;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}