using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private Transform _spawnPoint;
    [field: SerializeField] public LevelConfig LevelConfig { get; private set; }
    [field: SerializeField] public MenuConfig MenuConfig { get; private set; }
    [SerializeField] private HUD _hud;
    
    private BaseCooker _cooker;
    
    public BurgerBuilder BurgerBuilder { get; private set; }
    //---------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        BurgerBuilder = new BurgerBuilder(LevelConfig.BurgerElements, LevelConfig.Pan.Prefab, _offset, _spawnPoint.position);
        _hud.Construct(this);
    }
    //---------------------------------------------------------------------------------------------------------------
    private void OnEnable()
    {
        _hud.OrderPanel.orderAccepted += CookBurger;
    }
    //---------------------------------------------------------------------------------------------------------------
    private void OnDisable()
    {
        _hud.OrderPanel.orderAccepted -= CookBurger;
    }
    //---------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BurgerBase burger = _cooker.Cook();
        }
    }
    //---------------------------------------------------------------------------------------------------------------
    public void GetCooker(BaseCooker cooker)
    {
        _cooker = cooker;
    }
    //---------------------------------------------------------------------------------------------------------------
    public void CookBurger()
    {
        BurgerBase burger = _cooker.Cook();
        _hud.UpdateMoneyTextBox(burger.Price);
    }
    //---------------------------------------------------------------------------------------------------------------
}