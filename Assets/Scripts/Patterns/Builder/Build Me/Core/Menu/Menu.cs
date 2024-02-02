using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private MenuConfig _menuConfig;
    [SerializeField] private Transform _contentArea;
    //---------------------------------------------------------------------------------------------------------------
    public void Construct(BurgerBuilder builder, LevelService levelService)
    {
        foreach (var item in _menuConfig.MenuItems)
        {
            MenuItem t = Instantiate(item, _contentArea, false).GetComponent<MenuItem>();
            t.Construct(builder);
            t.OnItemChoosed += levelService.GetCooker;
        }
    }
    //---------------------------------------------------------------------------------------------------------------
}