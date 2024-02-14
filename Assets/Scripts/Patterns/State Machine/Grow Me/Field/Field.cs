using UnityEngine;

public class Field : Interactable
{
    [SerializeField] private int _square;

    private int _timeToWatering;
    private int _timeToPlantint;
    private int _toolID;
    private CropType _cropType;
    private StateMachine _machine;

    private void Start()
    {
        _machine = new StateMachine();
        _machine.AddState(new IdleState(_machine));
        _machine.AddState(new PlantState(_machine));
        _machine.SetState<PlantState>();
    }

    private void Update()
    {
        _machine.Update();
    }

}
