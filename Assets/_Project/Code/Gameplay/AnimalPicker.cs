using UnityEngine;
using _Project.Code.AnimalsBehaviour;

namespace _Project.Code.Gameplay
{
    public class AnimalPicker : MonoBehaviour
    {
        public bool TryPickAnimal(out Animal animal, Vector2 pickPosition)
        {
            animal = null;
            
            RaycastHit2D hit = Physics2D.Raycast(pickPosition, Vector2.zero);
            
            if (hit.collider == null)
                return false;

            return hit.collider.TryGetComponent(out animal);
        }
    }
}