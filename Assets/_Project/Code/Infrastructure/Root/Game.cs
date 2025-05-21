using System;
using _Project.Code.Gameplay;
using _Project.Code.UI.Rebuild;
using _Project.Code.Generation;
using _Project.Code.Infrastructure.Services.AssetsManagement;
using _Project.Code.Infrastructure.Services.PlayerInput;
using _Project.Code.Infrastructure.Services.UI;
using _Project.Code.UI.ActionBar;
using _Project.Code.UI.FinalScreen;
using UnityEngine;

namespace _Project.Code.Infrastructure.Root
{
    public class Game : MonoBehaviour, IGameResultNotifier
    {
        [SerializeField] private Transform _actionBarContainer;
        [SerializeField] private FinalScreenView _finalScreen;
        [SerializeField] private RebuildButtonView _rebuildButtonView;
        
        private PlayerInputHandler _playerInputHandler;
        private IActionBarModel _actionBar;
        private GameField _gameField;
        private FinalScreenPresenter _presenter;
        
        public event Action<string> Won;
        public event Action<string> Lost;
        
        public void Run()
        {
            _actionBar = new ActionBarModel();
            
            ActionBarPresenter actionBarPresenter = new ActionBarPresenter(
                _actionBar,
                new ActionBarSlotsFactory(new AssetsProvider(), _actionBarContainer),
                new AnimalsDatabase(new AssetsProvider()));
            
            actionBarPresenter.Run();
            
            _presenter = new FinalScreenPresenter(_finalScreen, this);

            _gameField = FindFirstObjectByType<GameField>();
            _playerInputHandler = FindFirstObjectByType<PlayerInputHandler>();
            _playerInputHandler.Initialize(_actionBar);
            
            _gameField.Filled += OnGameFieldFilled;
            _gameField.Empty += OnGameFieldEmpty;
            _actionBar.Filled += OnActionBarFilled;
            _rebuildButtonView.Clicked += OnRebuildButtonClicked;
            
            _playerInputHandler.DisablePickHandling();
            _gameField.Fill();
        }

        private void OnDestroy()
        {
            _gameField.Filled -= OnGameFieldFilled;
            _gameField.Empty -= OnGameFieldEmpty;
            _actionBar.Filled -= OnActionBarFilled;
            _rebuildButtonView.Clicked -= OnRebuildButtonClicked;
        }

        private void OnGameFieldEmpty()
        {
            _playerInputHandler.DisablePickHandling();
            
            Won?.Invoke("Победа");
        }

        private void OnActionBarFilled()
        {
            _playerInputHandler.DisablePickHandling();
            
            Lost?.Invoke("Поражение");
        }

        private void OnRebuildButtonClicked()
        {
            _gameField.Rebuild();
        }
        
        private void OnGameFieldFilled()
        {
            _playerInputHandler.EnablePickHandling();
        }

    }
}