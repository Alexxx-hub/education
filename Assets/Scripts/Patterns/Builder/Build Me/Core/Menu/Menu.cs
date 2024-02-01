using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private MenuConfig _menuConfig;
    [SerializeField] private Transform _contentArea;

    public void Construct(BurgerBuilder builder)
    {
        CreateItems(builder);
    }
    
    private void CreateItems(BurgerBuilder builder)
    {
        foreach (var item in _menuConfig.MenuItems)
        {
            MenuItem t = Instantiate(item, _contentArea, false).GetComponent<MenuItem>();
            t.Construct(builder);
        }
    }
}