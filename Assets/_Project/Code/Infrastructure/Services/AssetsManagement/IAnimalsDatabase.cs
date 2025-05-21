using _Project.Code.AnimalsBehaviour;
using UnityEngine;

namespace _Project.Code.Infrastructure.Services.AssetsManagement
{
    public interface IAnimalsDatabase
    {
        public Sprite GetAnimalSprite(AnimalType typeId);
        public Sprite GetFormSprite(AnimalForm formId);
        public Color GetColor(AnimalColor colorId);
    }
}