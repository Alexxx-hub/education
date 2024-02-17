using UnityEngine;

public delegate void CollectCrop(string id, float value);

public class Field : Interactable
{
    public CollectCrop collectCrop;

    [HideInInspector] public int stage;
    [field: SerializeField] public int Square {  get; private set; }
    [field: SerializeField] public float WateringSpeed {  get; private set; }
    [field: SerializeField] public float PlantingSpeed {  get; private set; }
    [field: SerializeField] public float CollectingSpeed {  get; private set; }
    [field: SerializeField] public Sprite[] SpriteArray {  get; private set; }
    public CropType CropType { get; private set; } 

    private StateMachine _machine;

    private void Start()
    {
        _machine = new StateMachine();

        _machine.AddState("cleaning", new CleaningState(_machine, this));
        _machine.AddState("plant", new PlantState(_machine, this));
        _machine.AddState("watering", new WateringState(_machine, this));
        _machine.AddState("grow", new GrowState(_machine, this));
        _machine.AddState("collecting", new CollectingState(_machine, this));

        _machine.SetState("plant");
    }

    private void Update()
    {
        _machine.Update();
    }

    public void Work(CropType cropType)
    {
        CropType = cropType;
        _machine.Proceed();
    }
}
