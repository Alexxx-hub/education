using Patterns.Strategy.Move_Me.Behaviours;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Units
{
    public class Human : UnitSelectable
    {
        private Animator _animator;

        private MoveToPoint _moveToPointBehaviour;
        private Follow _followBehaviour;
        private Patrol _patrolBehaviour;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            _moveBehaviour.onFinishMovement += WaitCommandState;
            _followBehaviour.onResumeMovement += ResumeMovement;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            _moveBehaviour.onFinishMovement -= WaitCommandState;
            _followBehaviour.onResumeMovement -= ResumeMovement;
        }
        //---------------------------------------------------------------------------------------------------------------
        protected override void Awake()
        {
            base.Awake();
            
            Transform unitTransform = transform;
            _moveToPointBehaviour = new MoveToPoint(unitTransform, pointToMove, _speed);
            _followBehaviour = new Follow(unitTransform, target, _speed);
            _patrolBehaviour = new Patrol(unitTransform, path, _speed);
            
            SetMoveBehaviour(_moveToPointBehaviour);
            _hasCommandMove = false;
            
            _commands = new Dictionary<string, Action>()
            {
                {"move", MoveToPoint},
                {"follow", Follow},
                {"patrol", Patrol}
            };
            _animator = GetComponent<Animator>();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Update()
        {
            if (_hasCommandMove)
            { 
                Move();
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void MoveToPoint()
        {
            _moveBehaviour.onFinishMovement -= WaitCommandState;
            _moveToPointBehaviour.TargetPoint = pointToMove;
            SetMoveBehaviour(_moveToPointBehaviour);
            _moveBehaviour.onFinishMovement += WaitCommandState;
            _animator.SetInteger("state", 1);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Follow()
        {
            _moveBehaviour.onFinishMovement -= WaitCommandState;
            _followBehaviour.Target = target;
            SetMoveBehaviour(_followBehaviour);
            _moveBehaviour.onFinishMovement += WaitCommandState;

            _animator.SetInteger("state", 1);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Patrol()
        {
            _patrolBehaviour.Path = path;
            SetMoveBehaviour(_patrolBehaviour);
            _animator.SetInteger("state", 1);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void WaitCommandState()
        {
            _animator.SetInteger("state", 0);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void ResumeMovement()
        {
            _animator.SetInteger("state", 1);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}   