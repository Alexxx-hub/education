using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Behaviours
{
    public class Patrol : IMove
    {
        private Vector3[] _path;
        private int _currentPoint;
        private float _speed;
        private Transform _uniTransform;

        public Vector3[] Path
        {
            get => _path;
            set
            {
                _path = value;
                _currentPoint = 0;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        public Patrol(Transform uniTransform, Vector3[] path, float speed)
        {
            _uniTransform = uniTransform;
            _path = path;
            _speed = speed;
            _currentPoint = 0;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Move()
        {
            float playerDistanceToFloor = _uniTransform.position.y - _path[_currentPoint].y;
            _path[_currentPoint].y += playerDistanceToFloor;
            
            // move to point;
            if (Vector3.Distance(_uniTransform.position, _path[_currentPoint]) > 0.1f)
            {
                //transform.Translate(_targetPoint * Time.deltaTime * speed);
                _uniTransform.position =  Vector3.MoveTowards(_uniTransform.position, _path[_currentPoint], _speed * Time.deltaTime);
            }
            else
            {
                _currentPoint++;
                if (_currentPoint >= _path.Length)
                {
                    _currentPoint = 0;
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}