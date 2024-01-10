using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Behaviours
{
    public class Follow : IMove
    {
        public Transform target;
        
        private float _speed;
        private Transform _unit;
        //---------------------------------------------------------------------------------------------------------------
        public Follow(Transform unit, Transform target, float speed)
        {
            _speed = speed;
            this.target = target;
            _unit = unit;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Move()
        {
            // move to point;
            if (Vector3.Distance(_unit.position, target.position) > 0.65f)
            {
                //transform.Translate(_targetPoint * Time.deltaTime * speed);
                _unit.position =  Vector3.MoveTowards(_unit.position, target.position, _speed * Time.deltaTime);
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}