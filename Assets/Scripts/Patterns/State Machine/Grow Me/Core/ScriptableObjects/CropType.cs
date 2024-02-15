using UnityEngine;

[CreateAssetMenu(fileName = "CropType", menuName = "Grow Me/Add new crop type")]
public class CropType : ScriptableObject
{
    [field: SerializeField] public int ID { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int CountPerUnit { get; private set; }
    [field: SerializeField] public int WaterPerUnit { get; private set; }
    [field: SerializeField] public int TimeToGrow { get; private set; }
}
