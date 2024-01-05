using Patterns.Strategy.Animals;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Strategy.MiniGames.GuessWho
{
    public class AnimalCardService : MonoBehaviour
    {
        [SerializeField] private Sprite _defaultSprite;

        //private Sprite _cureSprite;
        private Image _animalImage;
        private AnimalBase _selectedAnimal;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            GameSignalService.OnAnimalSelected += SetSprite;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            GameSignalService.OnAnimalSelected -= SetSprite;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _animalImage = GetComponent<Image>();
            _animalImage.sprite = _defaultSprite;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SetSprite(AnimalBase animalBase)
        {
            _selectedAnimal = animalBase;
            _animalImage.sprite = _selectedAnimal.Sprite;

            //TODO add smooth animation transition
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}