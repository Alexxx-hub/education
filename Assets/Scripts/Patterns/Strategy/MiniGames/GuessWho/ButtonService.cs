using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Strategy.MiniGames.GuessWho
{
    public class ButtonService : MonoBehaviour
    {
        public int id;
        
        private Button _button;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            _button.onClick.AddListener(ButtonPressed);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            _button.onClick.RemoveListener(ButtonPressed);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void ButtonPressed()
        {
            GameSignalService.ButtonPressed(id);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}