using System;
using System.Collections.Generic;
using _Project.Code.AnimalsBehaviour;

namespace _Project.Code.Gameplay
{
    public class ActionBarModel : IActionBarModel
    {
        private const int RequiredDuplicatesAmount = 3;
        private const int MaxCollectedAnimalsAmount = 7;
        
        private readonly List<Animal> _collectedAnimals = new List<Animal>();

        public int SlotsAmount => MaxCollectedAnimalsAmount;
        
        public event Action Filled;
        public event Action<int, AnimalData> AnimalAdded;
        public event Action<int> AnimalRemoved;
        
        public void AddAnimal(Animal animal)
        {
            _collectedAnimals.Add(animal);
            
            AnimalAdded?.Invoke(_collectedAnimals.Count - 1, animal.Data);

            if (IsDuplicatesContains(out List<int> duplicateIndexes))
            {
                foreach (var duplicateIndex in duplicateIndexes)
                {
                    _collectedAnimals[duplicateIndex] = null;
                    
                    AnimalRemoved?.Invoke(duplicateIndex);
                }

                for (int i = 0; i < duplicateIndexes.Count; i++)
                {
                    _collectedAnimals.Remove(null);
                }
            }
            
            if (_collectedAnimals.Count == MaxCollectedAnimalsAmount)
                Filled?.Invoke();
        }
        
        private bool IsDuplicatesContains(out List<int> duplicates)
        {
            duplicates = new List<int>();
            
            Animal lastAnimal = _collectedAnimals[^1];
            duplicates.Add(_collectedAnimals.Count - 1);

            int duplicatesAmount = 1;
            
            for (int i = 0; i < _collectedAnimals.Count - 1; i++)
            {
                if (_collectedAnimals[i].Type == lastAnimal.Type
                    && _collectedAnimals[i].Form == lastAnimal.Form
                    && _collectedAnimals[i].Color == lastAnimal.Color)
                {
                    duplicatesAmount++;
                    duplicates.Add(i);
                }
            }

            return duplicatesAmount == RequiredDuplicatesAmount;
        }
    }
}