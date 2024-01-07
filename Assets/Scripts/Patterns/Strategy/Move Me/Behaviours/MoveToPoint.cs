using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Behaviours
{
    public class MoveToPoint : IMove
    {
        private Vector3 _targetPoint;
        //---------------------------------------------------------------------------------------------------------------
        public MoveToPoint(Vector3 v)
        {
            _targetPoint = v;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Move(Transform transform, float speed)
        {
            float playerDistanceToFloor = transform.position.y - _targetPoint.y;
            _targetPoint.y += playerDistanceToFloor;
            
            // move to point;
            if (Vector3.Distance(transform.position, _targetPoint) > 0.1f)
            { 
                //transform.Translate(_targetPoint * Time.deltaTime * speed);
                transform.position =  Vector3.MoveTowards(transform.position, _targetPoint, speed * Time.deltaTime);
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}