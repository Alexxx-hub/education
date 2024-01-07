using System;
using Patterns.Strategy.Move_Me.Units;

namespace Patterns.Strategy.Move_Me.Core
{
    public static class UnitSignalsService
    {
        public static event Action<UnitBase, string[]> OnUnitSelected;
        //---------------------------------------------------------------------------------------------------------------
        public static void SendSelectedUnit(UnitBase unit, string[] commands)
        {
            OnUnitSelected?.Invoke(unit, commands);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}