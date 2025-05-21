using System;
using _Project.Code.Gameplay;
using _Project.Code.Generation;
using UnityEngine;

namespace _Project.Code.Infrastructure.Services.PlayerInput
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private AnimalPicker _animalPicker;
        [SerializeField] private GameField _gameField;
        
        private IActionBarModel _actionBar;
        
        private bool _isEnable;

        public void Initialize(IActionBarModel actionBarModel)
        {
            _actionBar = actionBarModel;
        }
        
        public void EnablePickHandling()
        {
            _isEnable = true;
        }
        
        public void DisablePickHandling()
        {
            _isEnable = false;
        }
        
        private void Update()
        {
            if (!_isEnable)
                return;
            
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

                if (_animalPicker.TryPickAnimal(out var animal, mouseWorldPosition))
                {
                    _actionBar.AddAnimal(animal);
                    _gameField.RemoveAnimal();
                    animal.gameObject.SetActive(false);
                }
            }
        }
    }
}