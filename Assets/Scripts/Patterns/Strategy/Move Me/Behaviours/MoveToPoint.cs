using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Behaviours
{
    public class MoveToPoint : IMove
    {
        public Vector3 targetPoint;
        
        private float _speed;
        private Transform _uniTransform;
        //---------------------------------------------------------------------------------------------------------------
        public MoveToPoint(Transform unit, Vector3 target, float speed)
        {
            _speed = speed;
            targetPoint = target;
            _uniTransform = unit;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Move()
        {
            float playerDistanceToFloor = _uniTransform.position.y - targetPoint.y;
            targetPoint.y += playerDistanceToFloor;
            
            // move to point;
            if (Vector3.Distance(_uniTransform.position, targetPoint) > 0.1f)
            {
                //transform.Translate(_targetPoint * Time.deltaTime * speed);
                _uniTransform.position =  Vector3.MoveTowards(_uniTransform.position, targetPoint, _speed * Time.deltaTime);
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}