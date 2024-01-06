using System;
using Patterns.Strategy.Animals;
using UnityEngine.UI;

namespace Patterns.Strategy.MiniGames.GuessWho
{
    public static class GameSignalService
    {
        public static event Action<AnimalBase> OnAnimalSelected;
        public static event Action OnShakeCards;
        public static event Action<int> OnButtonPressed;
        public static event Action<int> OnAnimalCoocked;
        //---------------------------------------------------------------------------------------------------------------
        public static void SelectAnimal(AnimalBase animal)
        {
            OnAnimalSelected?.Invoke(animal);
        }
        //---------------------------------------------------------------------------------------------------------------
        public static void ShakeCards()
        {
            OnShakeCards?.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------------
        public static void ButtonPressed(int id)
        {
            OnButtonPressed?.Invoke(id);
        }
        //---------------------------------------------------------------------------------------------------------------
        public static void SendHiddenAnimal(int id)
        {
            OnAnimalCoocked?.Invoke(id);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}