using UnityEngine;

public class BurgerBuilder : MonoBehaviour
{
    public float offset;
    public GameObject panPrefab;
    public Transform spawnPoint;
    
    public BurgerElement[] burgerElements;
    //---------------------------------------------------------------------------------------------------------------
    public Burger Build(int[] elements)
    {
        Burger burger = new GameObject("New Burger").AddComponent<Burger>();
        GameObject[] currentElements = new GameObject[elements.Length + 2];

        Vector3 spawnPos = spawnPoint.position;
        
        currentElements[0] = Instantiate(panPrefab, spawnPos, Quaternion.identity);
        
        for (int i = 0; i < elements.Length; i++)
        {
            spawnPos.y += offset;
            currentElements[i + 1] = CreateNewElement(elements[i], spawnPos);
        }
        
        spawnPos.y += offset;
        currentElements[^1] = Instantiate(panPrefab, spawnPos, Quaternion.identity);
        
        burger.SetupBurger(currentElements);
        
        return burger;
    }
    //---------------------------------------------------------------------------------------------------------------
    private GameObject CreateNewElement(int id, Vector3 spawnPosition)
    {
        return Instantiate(burgerElements[id].prefab, spawnPosition, Quaternion.identity);
    }
    //---------------------------------------------------------------------------------------------------------------
}