using UnityEngine;

[CreateAssetMenu(fileName = "Builder", menuName = "Menu/New Menu Config")]
public class MenuConfig : ScriptableObject
{
    [SerializeField] private GameObject[] _menuItems;

    public GameObject[] MenuItems => _menuItems;
}