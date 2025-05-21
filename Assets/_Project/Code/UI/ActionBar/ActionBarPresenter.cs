using System.Collections.Generic;
using UnityEngine;
using _Project.Code.Gameplay;
using _Project.Code.AnimalsBehaviour;
using _Project.Code.Infrastructure.Services.UI;
using _Project.Code.Infrastructure.Services.AssetsManagement;

namespace _Project.Code.UI.ActionBar
{
    public class ActionBarPresenter
    {
        private readonly IActionBarSlotsFactory _slotsFactory;
        private readonly IAnimalsDatabase _database;
        private readonly IActionBarModel _model;
        private List<IActionBarSlotView> _views;

        public ActionBarPresenter(
            IActionBarModel model,
            IActionBarSlotsFactory slotsFactory,
            IAnimalsDatabase database)
        {
            _model = model;
            _database = database;
            _slotsFactory = slotsFactory;
            _views = new List<IActionBarSlotView>();
        }

        public void Run()
        {
            _model.AnimalAdded += OnAnimalAdded;
            _model.AnimalRemoved += OnAnimalRemoved;

            CreateSlotViews();
        }

        public void Stop()
        {
            _model.AnimalAdded -= OnAnimalAdded;
            _model.AnimalRemoved -= OnAnimalRemoved;
        }

        private void CreateSlotViews()
        {
            for (int i = 0; i < _model.SlotsAmount; i++)
                _views.Add(_slotsFactory.CreateSlotView());
        }

        private void OnAnimalAdded(int index, AnimalData data)
        {
            Sprite animalSprite = _database.GetAnimalSprite(data.type); 
            Sprite animalFormSprite = _database.GetFormSprite(data.form); 
            Color animalColor = _database.GetColor(data.color);
            
            _views[index].UpdateView(animalSprite, animalFormSprite, animalColor);
        }

        private void OnAnimalRemoved(int index)
        {
            _views[index].Clear();
        }
    }
}