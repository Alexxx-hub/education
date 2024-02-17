using UnityEngine;

[CreateAssetMenu(fileName = "CropType", menuName = "Grow Me/Add new crop type")]
public class CropType : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public float CountPerUnit { get; private set; }
    [field: SerializeField] public float WaterPerUnit { get; private set; }
    [field: SerializeField] public float TimeToGrow { get; private set; }
}
