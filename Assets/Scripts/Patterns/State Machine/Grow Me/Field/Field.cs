using UnityEngine;

public class Field : Interactable
{
    [HideInInspector] public int stage;
    [field: SerializeField] public int Square {  get; private set; }
     

    private CropType _cropType;
    private StateMachine _machine;

    private void Start()
    {
        _machine = new StateMachine();
        _machine.AddState("idle", new IdleState(_machine, this));
        _machine.AddState("plant", new PlantState(_machine, this));
        _machine.SetState("plant");
    }

    private void Update()
    {
       
    }

    public void Work()
    {
        _machine.Update();
    }

}
