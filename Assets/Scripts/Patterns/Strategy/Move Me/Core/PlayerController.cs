using System.Linq;
using Patterns.Strategy.Move_Me.Units;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Core
{
    public class PlayerController : MonoBehaviour
    {
        private UnitSelectable _selectedUnit;
        private PlayerInputService _playerInputService;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            _playerInputService.OnMove += SendCommandMove;
            _playerInputService.OnPatrol += SendCommandPatrol;
            _playerInputService.OnFollow += GetSelectedTarget;
            UnitSignalsService.OnUnitSelected += GetSelectedUnit;
            UnitSignalsService.OnUnitDeselected += DeselectUnit;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            _playerInputService.OnMove -= SendCommandMove;
            _playerInputService.OnPatrol -= SendCommandPatrol;
            _playerInputService.OnFollow -= GetSelectedTarget;
            UnitSignalsService.OnUnitSelected -= GetSelectedUnit;
            UnitSignalsService.OnUnitDeselected -= DeselectUnit;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _playerInputService = GetComponent<PlayerInputService>();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void GetSelectedUnit(UnitSelectable unit)
        {
            if (_selectedUnit != null)
            {
                DeselectUnit();
            }
            _selectedUnit = unit;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void GetSelectedTarget(UnitSelectable unit)
        {
            if(unit == null || unit == _selectedUnit) return;
            
            SendCommandFollow(unit.transform);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void DeselectUnit()
        {
            _selectedUnit.Deselect();
            _selectedUnit = null;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SendCommandMove(Vector3 point)
        {
            if(_selectedUnit == null || point == -Vector3.one) return;

            if (_selectedUnit.Commands.Keys.Contains("move"))
            {
                _selectedUnit.pointToMove = point;
                _selectedUnit.Commands["move"].Invoke();
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SendCommandPatrol(Vector3[] path)
        {
            if(_selectedUnit == null) return;
            
            if (_selectedUnit.Commands.Keys.Contains("patrol"))
            {
                _selectedUnit.path = path;
                _selectedUnit.Commands["patrol"].Invoke();
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SendCommandFollow(Transform t)
        {
            if(_selectedUnit == null) return;
            
            if (_selectedUnit.Commands.Keys.Contains("follow"))
            {
                _selectedUnit.target = t;
                _selectedUnit.Commands["follow"].Invoke();
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}