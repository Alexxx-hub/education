using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    public int arraySize;
    public int range;

    private int[] _array;

    private void Start()
    {
        _array = GetRandomArray(arraySize);
        ShowArray(_array);
        Sort(ref _array);
        ShowArray(_array);
    }

    private int[] GetRandomArray(int size)
    {
        int[] array = new int[size];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Random.Range(0, range);
        }

        return array;
    }

    private void ShowArray(int[] array)
    {

        string reault = "";

        for (int i = 0; i < array.Length; i++)
        {
            reault += array[i].ToString() + " : ";
        }

        Debug.Log(reault);
    }

    private void Sort(ref int[] array)
    {
        for (int i = 0;i < array.Length;i++)
        {
            int min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if(array[j] < array[min])
                {
                    min = j;
                }
            }

            int t = array[min];
            array[min] = array[i];
            array[i] = t;
        }
    }
}
