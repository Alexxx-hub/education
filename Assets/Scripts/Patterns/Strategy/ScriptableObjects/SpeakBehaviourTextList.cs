using UnityEngine;

namespace Patterns.Strategy.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Strategy", menuName = "Speak/New SpeakList")]
    public class SpeakBehaviourTextList : ScriptableObject
    {
        [SerializeField] private string[] _texts;

        public string[] Texts => _texts;
    }
}