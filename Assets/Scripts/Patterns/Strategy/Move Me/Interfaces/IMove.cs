using System;

namespace Patterns.Strategy.Move_Me.Interfaces
{
    public interface IMove
    {
        public event Action onFinishMovement;
        public void Move();
    }
}