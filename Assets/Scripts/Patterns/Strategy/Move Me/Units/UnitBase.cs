using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Units
{
    public abstract class UnitBase : MonoBehaviour
    {
        [SerializeField] protected float _speed;
        
        protected bool _hasCommandMove;
        protected IMove _moveBehaviour;
        //---------------------------------------------------------------------------------------------------------------
        public void SetMoveBehaviour(IMove moveBehaviour)
        {
            _moveBehaviour = moveBehaviour;
            _hasCommandMove = true;
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void SetPatrolBehaviour(IMove moveBehaviour)
        {
            _moveBehaviour = moveBehaviour;
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void Move(Transform transform, float speed)
        {
            _moveBehaviour.Move(transform, speed);
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void Patrol(Transform transform, float speed)
        {
            _moveBehaviour.Move(transform, speed);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}