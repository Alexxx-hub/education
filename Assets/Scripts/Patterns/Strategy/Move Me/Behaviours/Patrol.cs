using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Behaviours
{
    public class Patrol : IMove
    {
        public Vector3[] points;
        //---------------------------------------------------------------------------------------------------------------
        public Patrol(){}
        //---------------------------------------------------------------------------------------------------------------
        public Patrol(Vector3[] v)
        {
            points = v;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Move(Transform transform, float speed)
        {
            // Patrol
            Debug.Log("PATROL");
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}