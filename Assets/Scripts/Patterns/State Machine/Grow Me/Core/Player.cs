using UnityEngine;

public class Player : MonoBehaviour
{
    public int currentTool;
    public int currentCrop;
    public CropType[] crops;

    private Camera _mainCamera;
    private Field _currentField;

    private void Awake()
    {
        //_currentTool = 0;
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            var rayhit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Input.mousePosition));
            if (!rayhit)
            {
                return;
            }

            _currentField = rayhit.transform.GetComponent<Field>();
            if (_currentField.stage != currentTool) return;

            _currentField.Work(crops[currentCrop]);

        }
    }

    public void SetTool(int id)
    {
        currentTool = id;
    }

    public void SetCrop(int id)
    {
        currentCrop = id;
    }
}
