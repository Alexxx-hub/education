using UnityEngine;

public class LevelService : MonoBehaviour
{
    public int[] settings;
    
    private Burger _burger;
    private BurgerBuilder _burgerBuilder;
    //---------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        _burgerBuilder = GetComponent<BurgerBuilder>();
    }
    //---------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _burger = _burgerBuilder
                .Build(settings);
        }
    }
    //---------------------------------------------------------------------------------------------------------------
}