using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private StorageUI _storageUI;
    [SerializeField] private Field[] _fields;
    [SerializeField] private UIZone[] _zones;
    [SerializeField] private Pointer _pointer;

    private Storage _storage;

    private void Awake()
    {
        _storage = new Storage();
        Cursor.visible = false;

        foreach(UIZone zone in _zones)
        {
            zone.Construct(UpdatePointer);
        }
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

    private void UpdatePointer(bool value)
    {
        _pointer.gameObject.SetActive(value);
    }
}
