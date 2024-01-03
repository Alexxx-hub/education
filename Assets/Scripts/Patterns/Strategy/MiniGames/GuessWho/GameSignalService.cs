using System;
using Patterns.Strategy.Animals;
using UnityEngine.UI;

namespace Patterns.Strategy.MiniGames.GuessWho
{
    public static class GameSignalService
    {
        public static event Action<AnimalBase> OnAnimalSelected;
        public static event Action<Button> OnButtonSelected;
        //---------------------------------------------------------------------------------------------------------------
        public static void SelectAnimal(AnimalBase animal)
        {
            OnAnimalSelected?.Invoke(animal);
        }
        //---------------------------------------------------------------------------------------------------------------
        public static void SetButton(Button button)
        {
            OnButtonSelected?.Invoke(button);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}