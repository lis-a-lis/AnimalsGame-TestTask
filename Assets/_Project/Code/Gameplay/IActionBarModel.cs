using System;
using _Project.Code.AnimalsBehaviour;

namespace _Project.Code.Gameplay
{
    public interface IActionBarModel
    {
        public int SlotsAmount { get; }
        
        public event Action Filled;
        public event Action<int, AnimalData> AnimalAdded;
        public event Action<int> AnimalRemoved;

        public void AddAnimal(Animal animal);
    }
}