using System;
using System.Collections.Generic;

namespace Patterns.Strategy.MiniGames.GuessWho
{
    public static class GameSignalService
    {
        public static event Action<Dictionary<string, Action>, string> OnAnimalSelected;
        //---------------------------------------------------------------------------------------------------------------
        public static void SelectAnimal(Dictionary<string, Action> animalBehaviour, string behaviourResault)
        {
            OnAnimalSelected?.Invoke(animalBehaviour, behaviourResault);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}