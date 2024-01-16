using UnityEngine;

namespace Algorithms
{
    public class BinarySearch : MonoBehaviour
    {
        public int arraySize;
        public int hiddenNumber;

        private int[] _sortedArray;
        //--------------------------------------------------------------------------------------------------------------
        private void Start()
        {
            _sortedArray = new int[arraySize];
            
            for (int i = 0; i < arraySize; i++)
            {
                _sortedArray[i] = i;
            }
            ReturnValue(Search(_sortedArray, hiddenNumber));
        }
        //--------------------------------------------------------------------------------------------------------------
        private int Search(int[] array, int number)
        {
            var low = 0;
            var high = array.Length - 1;
            var mid = 0;
            var guess = -1;

            while (low <= high)
            {
                mid = (low + high) / 2;
                guess = _sortedArray[mid];
                if (guess == number)
                    return mid;
                if (guess > number)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }
        //--------------------------------------------------------------------------------------------------------------
        private void ReturnValue(int value)
        {
            if (value == -1)
            {
                Debug.Log("Value not found");
                return;
            }
            Debug.Log(value);
        }
        //--------------------------------------------------------------------------------------------------------------
    }
}
