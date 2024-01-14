using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Strategy.MiniGames.GuessWho.Core
{
    public class CloseApplicationButton : MonoBehaviour
    {
        private Button _button;
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Application.Quit);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}