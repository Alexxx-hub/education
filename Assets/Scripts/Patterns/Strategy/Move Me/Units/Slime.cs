using Patterns.Strategy.Move_Me.Behaviours;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Units
{
    public class Slime : UnitBase
    {
        [SerializeField] private Transform[] _path;
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            Vector3[] path = new Vector3[_path.Length];

            for (int i = 0; i < path.Length; i++)
            {
                path[i] = _path[i].position;
            }
            
            SetMoveBehaviour(new Patrol(transform, path, _speed));
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Start()
        {
            transform.position = _path[0].position;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Update()
        {
            if (_hasCommandMove)
            { 
                Move();
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}