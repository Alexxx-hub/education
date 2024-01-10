﻿using System;
using Patterns.Strategy.Move_Me.Units;
using UnityEngine;
using ISelectable = Patterns.Strategy.Move_Me.Interfaces.ISelectable;

namespace Patterns.Strategy.Move_Me.Core
{
    public class PlayerInputService : MonoBehaviour
    {
        public event Action<Vector3> OnMove;
        public event Action OnPatrol;
        public event Action<UnitSelectable> OnFollow;

        private MoveCommands _currentCommand;

        public MoveCommands CurrentCommand => _currentCommand;
        //---------------------------------------------------------------------------------------------------------------
        private void Update()
        {
            Select();
            Deselect();
            SwitchBehaviour();
            Move();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Move()
        {
            if (Input.GetMouseButtonDown(1))
            {
                switch (CurrentCommand)
                {
                    case MoveCommands.Move:
                        OnMove?.Invoke(GetMovePoint());
                        break;
                    case MoveCommands.Patrol:
                        OnPatrol?.Invoke();
                        break;
                    case MoveCommands.Follow:
                        OnFollow?.Invoke(GetTarget());
                        break;
                    default: OnMove?.Invoke(GetMovePoint());   
                        break;
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Select()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    ISelectable unit = hit.collider.GetComponent<ISelectable>();

                    if (unit != null)
                    {
                        unit.Select();
                    }
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private UnitSelectable GetTarget()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                ISelectable unit = hit.collider.GetComponent<ISelectable>();

                if (unit != null)
                {
                    return unit as UnitSelectable;
                }
            }

            return null;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Deselect()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UnitSignalsService.DeselectUnit();
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SwitchBehaviour()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _currentCommand = MoveCommands.Move;
                Debug.Log("Current command: MOVE");
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                _currentCommand = MoveCommands.Patrol;
                Debug.Log("Current command: PATROL");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                _currentCommand = MoveCommands.Follow;
                Debug.Log("Current command: FOLLOW");
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private Vector3 GetMovePoint()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider)
            {
                return hit.point;
            }
            
            return Vector3.zero;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}