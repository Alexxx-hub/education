using System;
using Patterns.Strategy.Move_Me.Units;

namespace Patterns.Strategy.Move_Me.Core
{
    public static class UnitSignalsService
    {
        public static event Action<UnitSelectable> OnUnitSelected;
        public static event Action OnUnitDeselected;
        //---------------------------------------------------------------------------------------------------------------
        public static void SendSelectedUnit(UnitSelectable unit)
        {
            OnUnitSelected?.Invoke(unit);
        }
        //---------------------------------------------------------------------------------------------------------------
        public static void DeselectUnit()
        {
            OnUnitDeselected?.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}