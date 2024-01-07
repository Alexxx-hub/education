using UnityEngine;

namespace Patterns.Strategy.Move_Me.Interfaces
{
    public interface IMove
    {
        public void Move(Transform gameObject, float speed);
    }
}