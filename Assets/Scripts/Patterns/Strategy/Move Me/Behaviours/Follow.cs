using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Behaviours
{
    public class Follow : IMove
    {
        public Transform target;
        //---------------------------------------------------------------------------------------------------------------
        public Follow(){}
        //---------------------------------------------------------------------------------------------------------------
        public Follow(Transform t)
        {
            target = t;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Move(Transform transform, float speed)
        {
            // Follow
            Debug.Log("FOLLOW");
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}