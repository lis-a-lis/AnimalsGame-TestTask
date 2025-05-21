using System;
using System.Collections.Generic;
using _Project.Code.AnimalsBehaviour;
using UnityEngine;

namespace _Project.Code.Generation
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private GeneratedContentConfiguration _generatedContentConfiguration;
        [SerializeField] private ContentGenerator _contentGenerator;
        
        private List<Animal> _animals;
        private int _remainingAnimalsAmount;

        public event Action Filled;
        public event Action Empty; 

        public void Clear()
        {
            foreach (Animal animal in _animals)  
                Destroy(animal.gameObject);
            
            _animals.Clear();
        }

        public void RemoveAnimal()
        {
            _remainingAnimalsAmount--;
            
            if (_remainingAnimalsAmount == 0)
                Empty?.Invoke();
        }

        public void Fill()
        {
            _animals = new List<Animal>();

            _remainingAnimalsAmount = _generatedContentConfiguration.AmountOfAnimalsPerGeneration;
            
            _contentGenerator.Generate(
                _generatedContentConfiguration,
                _generatedContentConfiguration.AmountOfAnimalsPerGeneration,
                animal => _animals.Add(animal),
                () => Filled?.Invoke());
        }

        public void Rebuild()
        {
            Clear();
            
            _contentGenerator.Generate(
                _generatedContentConfiguration,
                _remainingAnimalsAmount,
                animal => _animals.Add(animal),
                () => Filled?.Invoke());
        }
    }
}