﻿using Patterns.Strategy.Move_Me.Behaviours;
using System;
using System.Collections.Generic;
using Patterns.Strategy.Move_Me.Core;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Units
{
    public class Human : UnitSelectable
    {
        //---------------------------------------------------------------------------------------------------------------
        protected override void Awake()
        {
            base.Awake();
            _commands = new Dictionary<string, Action>()
            {
                {"move", MoveToPoint},
                {"follow", Follow},
                {"patrol", Patrol}
            };
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
            if (_currentCommand == MoveCommands.Move)
            {
                MoveToPoint moveToPoint = _moveBehaviour as MoveToPoint;
                moveToPoint.targetPoint = pointToMove;
                Debug.Log("Updated");
                return;
            }
            SetMoveBehaviour(new MoveToPoint(transform, pointToMove, _speed));
            _currentCommand = MoveCommands.Move;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Follow()
        {
            if (_currentCommand == MoveCommands.Follow)
            {
                Follow moveToPoint = _moveBehaviour as Follow;
                moveToPoint.target = target;
                return;
            }
            SetMoveBehaviour(new Follow(transform, target, _speed));
            _currentCommand = MoveCommands.Follow;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Patrol()
        {
            if (_currentCommand == MoveCommands.Patrol)
            {
                return;
            }
            SetMoveBehaviour(new Patrol(transform, ));
            _currentCommand = MoveCommands.Patrol;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}   