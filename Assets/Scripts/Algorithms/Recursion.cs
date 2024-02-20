using UnityEngine;

public class Recursion : MonoBehaviour
{
    public int factorialNumber;

    private void Start()
    {
        ShowFactorial(factorialNumber);
    }

    private void ShowFactorial(int number)
    {
        Debug.Log($"Factorial {factorialNumber} : {Factorial(number)}");
    }

    private int Factorial(int number)
    {
        if (number == 1)
            return 1;
        else
            return number * Factorial(number - 1);
    }
}
