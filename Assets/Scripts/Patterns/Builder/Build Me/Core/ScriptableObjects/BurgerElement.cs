using UnityEngine;

[CreateAssetMenu(fileName = "Builder", menuName = "Burger/New Burger Element")]
public class BurgerElement : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _prefab;

    public string Name => _name;
    public int Price => _price;
    public GameObject Prefab => _prefab;
}