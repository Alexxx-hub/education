using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Strategy.MiniGames.GuessWho
{
    public class UIAnimator
    {
        private const int Vibrato = 20;
        private readonly Vector3 Strength = new (7, 7, 0);
        private const float Randomness = 120F;

        //---------------------------------------------------------------------------------------------------------------
        public void Shake(Transform transform, float duration)
        {
            transform.DOShakePosition(duration, Strength, Vibrato, Randomness, false, false, ShakeRandomnessMode.Harmonic);
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Show(Image image, float time)
        {
            image.DOFade(1, time);
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Hide(Image image, float time)
        {
            image.DOFade(0, time);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}