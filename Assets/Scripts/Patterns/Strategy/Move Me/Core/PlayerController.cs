using Patterns.Strategy.Move_Me.Behaviours;
using Patterns.Strategy.Move_Me.Units;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Core
{
    public class PlayerController : MonoBehaviour
    {
        private string[] _commands;
        private UnitBase _selectedUnit;
        private PlayerInputService _playerInputService;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            _playerInputService.OnMove += SendCommandMove;
            _playerInputService.OnPatrol += SendCommandPatrol;
            _playerInputService.OnFollow += SendCommandFollow;
            UnitSignalsService.OnUnitSelected += GetSelectedUnit;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            _playerInputService.OnMove -= SendCommandMove;
            _playerInputService.OnPatrol -= SendCommandPatrol;
            _playerInputService.OnFollow -= SendCommandFollow;
            UnitSignalsService.OnUnitSelected -= GetSelectedUnit;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _playerInputService = new PlayerInputService();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Update()
        {
            _playerInputService.Select();
            _playerInputService.SwitchBehaviour();
            _playerInputService.Move();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void GetSelectedUnit(UnitBase unit, string[] commands)
        {
            _commands = commands;
            _selectedUnit = unit;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SendCommandMove(Vector3 point)
        {
            if(_selectedUnit == null) return;
            
            foreach (var command in _commands)
            {
                if (command == "move")
                {
                    _selectedUnit.SetMoveBehaviour(new MoveToPoint(point));
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SendCommandPatrol()
        {
            if(_selectedUnit == null) return;
            
            foreach (var command in _commands)
            {
                if (command == "patrol")
                {
                    _selectedUnit.SetMoveBehaviour(new Patrol());
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SendCommandFollow()
        {
            if(_selectedUnit == null) return;
            
            foreach (var command in _commands)
            {
                if (command == "follow")
                {
                    _selectedUnit.SetMoveBehaviour(new Follow());
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}