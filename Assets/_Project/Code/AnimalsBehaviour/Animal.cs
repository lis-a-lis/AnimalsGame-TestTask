using System;
using UnityEngine;

namespace _Project.Code.AnimalsBehaviour
{
    public class Animal : MonoBehaviour
    {
        [SerializeField] private AnimalType _type;
        [SerializeField] private AnimalForm _form;
        [SerializeField] private AnimalColor _color;
        
        public AnimalData Data => new AnimalData(_type, _form, _color);
        
        public AnimalType Type => _type;
        public AnimalForm Form => _form;
        public AnimalColor Color => _color;

        public void Pick()
        {
            
        }
    }

    public enum AnimalType
    {
        Sheep,
        Fox,
        Bear,
        Penguin,
        Bird,
        Panda,
    }

    public enum AnimalForm
    {
        Circle,
        Triangle,
        Rectangle,
        RoundedRectangle,
    }

    public enum AnimalColor
    {
        Gray,
        
    }

}
