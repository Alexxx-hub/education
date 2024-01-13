using System;
using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Behaviours
{
    public class Patrol : IMove
    {
        public event Action onFinishMovement;
        
        private Vector3[] _path;
        private bool _isRotated;
        private int _currentPoint;
        private float _speed;
        private Transform _uniTransform;

        public Vector3[] Path
        {
            set
            {
                _path = value;
                _currentPoint = 0;
                _isRotated = false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        public Patrol(Transform uniTransform, Vector3[] path, float speed)
        {
            _uniTransform = uniTransform;
            _path = path;
            _speed = speed;
            _currentPoint = 0;
            _isRotated = false;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Move()
        {
            Vector3 unitPosition = _uniTransform.position;
            
            float playerDistanceToFloor = unitPosition.y - _path[_currentPoint].y;
            _path[_currentPoint].y += playerDistanceToFloor;
            
            if (!_isRotated)
            {
                RotateToDirection(unitPosition);
            }

            // move to point;
            if (Vector3.Distance(unitPosition, _path[_currentPoint]) > 0.1f)
            {
                _uniTransform.position =  Vector3.MoveTowards(unitPosition, _path[_currentPoint], _speed * Time.deltaTime);
            }
            else
            {
                _currentPoint++;
                if (_currentPoint >= _path.Length)
                {
                    Array.Reverse(_path);
                    _currentPoint = 0;
                }
                _isRotated = false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void RotateToDirection( Vector3 unitPosition)
        {
            Vector3 direction = (_path[_currentPoint] - unitPosition).normalized;
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
            _uniTransform.rotation = Quaternion.Euler(0, 90 - angle, 0);
            _isRotated = true;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}