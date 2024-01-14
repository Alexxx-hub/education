using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Strategy.Move_Me.Core
{
    public class MovementButtonService : MonoBehaviour
    {
        [SerializeField] private Image[] _buttons;
        [SerializeField] private GameObject _tutorialPopUp;
        [SerializeField] private Color32 _selectedButtonColor;
        [SerializeField] private PlayerInputService _playerInputService;

        private int _currentID;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            _playerInputService.onCommand += SelectButton;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            _playerInputService.onCommand -= SelectButton;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _currentID = 0;
            _tutorialPopUp.SetActive(false);
            SelectButton(0);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SelectButton(int id)
        {
            _buttons[_currentID].color = Color.white;
            _buttons[id].color = _selectedButtonColor;
            _currentID = id;

            if (_currentID == 1)
            {
                _tutorialPopUp.SetActive(true);
            }
            else
            {
                _tutorialPopUp.SetActive(false);
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}