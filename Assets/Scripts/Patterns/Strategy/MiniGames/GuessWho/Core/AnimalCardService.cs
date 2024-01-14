using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Patterns.Strategy.MiniGames.GuessWho.Core
{
    public class AnimalCardService : MonoBehaviour
    {
        // set parameters for animation
        [SerializeField] private float _fadeTime;
        [SerializeField] private float _shakeTime;
        
        [SerializeField] private Sprite _defaultSprite;
        [SerializeField] private Sprite[] _animalSprites;
        [SerializeField] private Button _shakeButton;

        private Image _animalImage;
        private UIAnimator _uiAnimator;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            _shakeButton.onClick.AddListener(SetSprite);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            _shakeButton.onClick.RemoveListener(SetSprite);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _animalImage = GetComponent<Image>();
            _animalImage.sprite = _defaultSprite;
            _uiAnimator = new UIAnimator();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void ResetAnimalCard()
        {
            // show default card image
            _animalImage.sprite = _defaultSprite;
            _uiAnimator.Show(_animalImage, _fadeTime);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void ShowCard()
        {
            // select random card id
            int id = Random.Range(0, _animalSprites.Length);
            
            _animalImage.sprite = _animalSprites[id];
            _uiAnimator.Show(_animalImage, _fadeTime);
            
            // user can select random card again
            _shakeButton.interactable = true;
            GameSignalService.SendHiddenAnimal(id);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void HideCard()
        {
            if(_animalImage.sprite == _defaultSprite) return;
            
            // set time to hide animation
            float time = _fadeTime / 4;
            _uiAnimator.Hide(_animalImage, time);
            Invoke(nameof(ResetAnimalCard), time);
        }
        //---------------------------------------------------------------------------------------------------------------
        private async void SetSprite()
        {
            // return default card image before shaking
            HideCard();
            _shakeButton.interactable = false;
            GameSignalService.ShakeCards();
            
            // play animation of choosing random card
            await ShakeDice();
            _uiAnimator.Hide(_animalImage, _fadeTime);
            Invoke(nameof(ShowCard), _fadeTime);
        }
        //---------------------------------------------------------------------------------------------------------------
        private async Task ShakeDice()
        {
            _uiAnimator.Shake(_shakeButton.transform, _shakeTime);
            
            // set time for shaking in ms
            await Task.Delay(Mathf.RoundToInt(_shakeTime * 1000));
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}