using UnityEngine;
using UnityEngine.UI;

public delegate void CollectCrop(string id, float value);

public class Field : Interactable
{
    public CollectCrop collectCrop;
    public GameObject statusBar;
    public Image statusBarImage; 

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

        ShowStastucBar();
    }

    public void Work(CropType cropType)
    {
        CropType = cropType;
        _machine.Proceed();
    }

    private void ShowStastucBar()
    {
        if (_isActive)
            statusBar.SetActive(true);
        else if (!_isActive && statusBar.activeInHierarchy)
            statusBar.SetActive(false);
    }
}
