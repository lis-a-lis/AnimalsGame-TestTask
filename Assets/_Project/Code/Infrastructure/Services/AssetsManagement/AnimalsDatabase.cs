using System;
using System.Collections.Generic;
using _Project.Code.AnimalsBehaviour;
using UnityEngine;

namespace _Project.Code.Infrastructure.Services.AssetsManagement
{
    [Serializable]
    public class AnimalsDatabaseTableCellColor
    {
        public AnimalColor id;
        public Color color;
    }
    
    [Serializable]
    public class AnimalsDatabaseTableCellIcon
    {
        public AnimalType id;
        public Sprite icon;
    }

    [Serializable]
    public class AnimalsDatabaseTableCellForm
    {
        public AnimalForm id;
        public Sprite icon;
    }

    public class AnimalsDatabase : IAnimalsDatabase
    {
        private const string PathToTable = "Database/Table";

        private readonly Dictionary<AnimalType, Sprite> _icons;
        private readonly Dictionary<AnimalForm, Sprite> _forms;
        private readonly Dictionary<AnimalColor, Color> _colors;

        private AnimalsDatabaseTable _table;

        public AnimalsDatabase(IAssetsProvider assetsProvider)
        {
            _table = assetsProvider.LoadScriptableObject<AnimalsDatabaseTable>(PathToTable);

            _icons = new Dictionary<AnimalType, Sprite>();
            _forms = new Dictionary<AnimalForm, Sprite>();
            _colors = new Dictionary<AnimalColor, Color>();

            foreach (var cell in _table.icons)
                _icons.Add(cell.id, cell.icon);

            foreach (var cell in _table.forms)
                _forms.Add(cell.id, cell.icon);

            foreach (var cell in _table.colors)
                _colors.Add(cell.id, cell.color);
        }

        public Sprite GetAnimalSprite(AnimalType typeId)
        {
            return _icons[typeId];
        }

        public Sprite GetFormSprite(AnimalForm formId)
        {
            return _forms[formId];
        }

        public Color GetColor(AnimalColor colorId)
        {
            return _colors[colorId];
        }
    }
}