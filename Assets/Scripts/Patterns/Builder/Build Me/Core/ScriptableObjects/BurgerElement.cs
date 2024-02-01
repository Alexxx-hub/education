using UnityEngine;

[CreateAssetMenu(fileName = "Builder", menuName = "Burger/New Burger Element")]
public class BurgerElement : ScriptableObject
{
    public string name;
    public int price;
    public GameObject prefab;
}