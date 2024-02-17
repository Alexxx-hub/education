using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private StorageUI _storageUI;
    [SerializeField] private Field[] _fields;

    private Storage _storage;

    private void Awake()
    {
        _storage = new Storage();
    }

    private void OnEnable()
    {
        foreach (Field field in _fields)
        {
            field.collectCrop += _storage.AddCrop;
            field.collectCrop += _storageUI.UpdateUI;
        }
    }

    private void OnDisable()
    {
        foreach (Field field in _fields)
        {
            field.collectCrop -= _storage.AddCrop;
            field.collectCrop -= _storageUI.UpdateUI;
        }
    }
}
