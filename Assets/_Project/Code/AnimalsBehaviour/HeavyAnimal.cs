using UnityEngine;

namespace _Project.Code.AnimalsBehaviour
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeavyAnimal : Animal
    {
        [SerializeField] private float _gravityAcceleration;
        
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.linearVelocity =
                new Vector2(_rigidbody.linearVelocity.x, _rigidbody.linearVelocity.y + _gravityAcceleration);
        }
    }
}