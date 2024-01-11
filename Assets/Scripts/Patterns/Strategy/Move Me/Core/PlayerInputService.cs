using System;
using Patterns.Strategy.Move_Me.Units;
using UnityEngine;
using ISelectable = Patterns.Strategy.Move_Me.Interfaces.ISelectable;

namespace Patterns.Strategy.Move_Me.Core
{
    public class PlayerInputService : MonoBehaviour
    {
        public event Action<Vector3> OnMove;
        public event Action<Vector3[]> OnPatrol;
        public event Action<UnitSelectable> OnFollow;
        
        private int _currentPathPoint;
        private Vector3[] _path;
        private MoveCommands _currentCommand;

        public MoveCommands CurrentCommand => _currentCommand;
        //---------------------------------------------------------------------------------------------------------------
        private void Start()
        {
            _path = new Vector3[5];
            ResetPath();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Update()
        {
            Select();
            Deselect();
            SwitchBehaviour();
            MoveTo();

            if (_currentCommand == MoveCommands.Patrol && Input.GetKeyUp(KeyCode.LeftShift))
            {
                GetPath();
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void MoveTo()
        {
            if (Input.GetMouseButtonDown(1))
            {
                switch (CurrentCommand)
                {
                    case MoveCommands.Move:
                        OnMove?.Invoke(GetMovePoint());
                        break;
                    case MoveCommands.Patrol:
                        BuildPath();
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
        private void BuildPath()
        {
            if (Input.GetKey(KeyCode.LeftShift) && _path[^1] == Vector3.zero)
            {
                _path[_currentPathPoint++] = GetMovePoint();
            }
            else
            {
                if (_path[0] == Vector3.zero)
                {
                    return;
                }
                
                GetPath();
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
        private void GetPath()
        {
            if (_path[0] == Vector3.zero)
            {
                return;
            }
            
            Vector3[] path = new Vector3[_currentPathPoint];
                
            for (int i = 0; i < path.Length; i++)
            {
                path[i] = _path[i];
            }
            
            OnPatrol?.Invoke(path);
            ResetPath();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void ResetPath()
        {
            for (int i = 0; i < _path.Length; i++)
            {
                _path[i] = Vector3.zero;
            }
            _currentPathPoint = 0;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}