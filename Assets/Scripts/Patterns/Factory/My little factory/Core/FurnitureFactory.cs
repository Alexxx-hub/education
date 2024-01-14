using Patterns.Factory.My_little_factory.Core.Services;
using Patterns.Factory.My_little_factory.Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Factory.My_little_factory.Core
{
    public class FurnitureFactory : MonoBehaviour
    { 
        [SerializeField] private Button _createChairButton;
        [SerializeField] private Button _createSofaButton;
        [SerializeField] private Button _createTableButton;
        
        private ControlPanelService _controlPanelService;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            _controlPanelService.OnFurnitureChoose += CreateFurniture;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            _controlPanelService.OnFurnitureChoose -= CreateFurniture;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _controlPanelService = new ControlPanelService(_createChairButton, _createSofaButton, _createTableButton);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void CreateFurniture(FurnitureCreator furnitureCreator)
        {
            furnitureCreator.CreateFurniture();
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}