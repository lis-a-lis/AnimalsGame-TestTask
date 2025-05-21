using System.Collections.Generic;
using _Project.Code.AnimalsBehaviour;
using UnityEngine;

namespace _Project.Code.Generation
{
    [CreateAssetMenu(menuName = "Create GeneratedContentConfiguration", fileName = "GeneratedContentConfiguration", order = 0)]
    public class GeneratedContentConfiguration : ScriptableObject
    {
        [SerializeField] private int _animalsMultiplicityFactor = 3;
        [SerializeField] private int _amountOfAnimalsPerGeneration;
        [SerializeField] private List<Animal> _animalPrefabs = new List<Animal>();
        
        public int AnimalsMultiplicityFactor => _animalsMultiplicityFactor;
        
        public int AmountOfAnimalsPerGeneration => _amountOfAnimalsPerGeneration;

        private void OnValidate()
        {
            if (_amountOfAnimalsPerGeneration == 0)
                return;
            
            if (_amountOfAnimalsPerGeneration % _animalsMultiplicityFactor != 0)
                Debug.LogWarning($"Amount of Animals per generation must be divisible by {_animalsMultiplicityFactor}");
        }

        public Animal[] GetAnimalPrefabs()
        {
            if (_animalPrefabs.Count == 0)
                throw new System.Exception("No animals prefab defined");
            
            return _animalPrefabs.ToArray();
        }
    }
}