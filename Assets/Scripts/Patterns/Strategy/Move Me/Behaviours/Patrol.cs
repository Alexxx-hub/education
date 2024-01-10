using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Behaviours
{
    public class Patrol : IMove
    {
        public Vector3[] path;

        private int _currentPoint;
        private float _speed;
        private Transform _uniTransform;
        //---------------------------------------------------------------------------------------------------------------
        public Patrol(Transform uniTransform, Vector3[] path, float speed)
        {
            _uniTransform = uniTransform;
            this.path = path;
            _speed = speed;
            _currentPoint = 0;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Move()
        {
            float playerDistanceToFloor = _uniTransform.position.y - path[_currentPoint].y;
            path[_currentPoint].y += playerDistanceToFloor;
            
            // move to point;
            if (Vector3.Distance(_uniTransform.position, path[_currentPoint]) > 0.1f)
            {
                //transform.Translate(_targetPoint * Time.deltaTime * speed);
                _uniTransform.position =  Vector3.MoveTowards(_uniTransform.position, path[_currentPoint], _speed * Time.deltaTime);
            }
            else
            {
                _currentPoint++;
                if (_currentPoint >= path.Length)
                {
                    _currentPoint = 0;
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}