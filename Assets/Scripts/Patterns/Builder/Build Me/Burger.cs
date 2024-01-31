using UnityEngine;

public class Burger : MonoBehaviour
{
    private GameObject[] _elements;
    //---------------------------------------------------------------------------------------------------------------
    public void SetupBurger(GameObject[] elements)
    {
        _elements = elements;

        foreach (var element in _elements)
        {
            element.transform.SetParent(transform);
        }
    }
    //---------------------------------------------------------------------------------------------------------------
    public void GetBurger()
    {
        
    }
    //---------------------------------------------------------------------------------------------------------------
}
