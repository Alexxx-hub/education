using Patterns.Strategy.Move_Me.Behaviours;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Patterns.Strategy.Move_Me.Units
{
    public class Turtle : UnitBase
    {
        [SerializeField] private Transform[] _zonePoints;
        
        private Vector3[] _zonePointsPositions;
        private MoveToPoint _moveToPointBehaviour;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            _moveBehaviour.onFinishMovement += UpdateMovementPoint;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            _moveBehaviour.onFinishMovement -= UpdateMovementPoint;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _zonePointsPositions = new Vector3[_zonePoints.Length];
            
            for (int i = 0; i < _zonePointsPositions.Length; i++)
            {
                _zonePointsPositions[i] = _zonePoints[i].position;
            }

            _moveToPointBehaviour = new MoveToPoint(transform, GetRandomPoint(_zonePointsPositions), _speed);
            
            SetMoveBehaviour(_moveToPointBehaviour);
            _hasCommandMove = false;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Start()
        {
            transform.position = GetRandomPoint(_zonePointsPositions);
            _hasCommandMove = true;
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
        private Vector3 GetRandomPoint(Vector3[] zone)
        {
            float randomX = Random.Range(Mathf.Min(zone[0].x, zone[1].x, zone[2].x, zone[3].x), Mathf.Max(zone[0].x, zone[1].x, zone[2].x, zone[3].x));
            float randomZ = Random.Range(Mathf.Min(zone[0].z, zone[1].z, zone[2].z, zone[3].z), Mathf.Max(zone[0].z, zone[1].z, zone[2].z, zone[3].z));
            
            return new Vector3(randomX, zone[0].y, randomZ);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void UpdateMovementPoint()
        {
            _moveToPointBehaviour.TargetPoint = GetRandomPoint(_zonePointsPositions);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}