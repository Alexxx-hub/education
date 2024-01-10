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
        protected void SetMoveBehaviour(IMove moveBehaviour)
        {
            _moveBehaviour = moveBehaviour;
            _hasCommandMove = true;
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void Move()
        {
            _moveBehaviour.Move();
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}