using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Patterns.Strategy.MiniGames.GuessWho
{
    public class AnimalCardService : MonoBehaviour
    {
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
            _animalImage.sprite = _defaultSprite;
            _uiAnimator.Show(_animalImage, _fadeTime);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void ShowCard()
        {
            int id = Random.Range(0, _animalSprites.Length);
            _animalImage.sprite = _animalSprites[id];
            _uiAnimator.Show(_animalImage, _fadeTime);
            _shakeButton.interactable = true;
            GameSignalService.SendHiddenAnimal(id);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void HideCard()
        {
            if(_animalImage.sprite == _defaultSprite) return;
            float time = _fadeTime / 4;
            _uiAnimator.Hide(_animalImage, time);
            Invoke(nameof(ResetAnimalCard), time);
        }
        //---------------------------------------------------------------------------------------------------------------
        private async void SetSprite()
        {
            HideCard();
            _shakeButton.interactable = false;
            GameSignalService.ShakeCards();
            await ShakeDice();
            _uiAnimator.Hide(_animalImage, _fadeTime);
            Invoke(nameof(ShowCard), _fadeTime);
        }
        //---------------------------------------------------------------------------------------------------------------
        private async Task ShakeDice()
        {
            _uiAnimator.Shake(_shakeButton.transform, _shakeTime);
            await Task.Delay(Mathf.RoundToInt(_shakeTime * 1000));
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}