using System;
using Patterns.Strategy.Move_Me.Units;

namespace Patterns.Strategy.Move_Me.Core
{
    public static class UnitSignalsService
    {
        public static event Action<UnitSelectable, string[]> OnUnitSelected;
        public static event Action OnUnitDeselected;
        //---------------------------------------------------------------------------------------------------------------
        public static void SendSelectedUnit(UnitSelectable unit, string[] commands)
        {
            OnUnitSelected?.Invoke(unit, commands);
        }
        //---------------------------------------------------------------------------------------------------------------
        public static void DeselectUnit()
        {
            OnUnitDeselected?.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}