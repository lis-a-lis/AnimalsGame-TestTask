using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Random = UnityEngine.Random;
using _Project.Code.AnimalsBehaviour;

namespace _Project.Code.Generation
{
    public class ContentGenerator : MonoBehaviour
    {
        [SerializeField] private float _delayBetweenGenerations;
        [SerializeField] private float _spawnPointPositionOffset;
        [SerializeField] private bool _isSpawnPointStatic;
    
        private int[] _generationSequence;

        public void Generate(GeneratedContentConfiguration configuration, int amountOfInstances,
            Action<Animal> onInstanced, Action onComplete)
        {
            RunGeneration(configuration, amountOfInstances, onInstanced, onComplete);
        }

        private void RunGeneration(GeneratedContentConfiguration configuration, int amountOfInstances,
            Action<Animal> onInstanced, Action onComplete)
        {
            Func<Vector3> instanceSpawnPosition;

            if (_isSpawnPointStatic)
                instanceSpawnPosition = GetStaticSpawnPointPosition;
            else
                instanceSpawnPosition = GetRandomSpawnPointPosition;
            
            GenerateContentAsync(configuration, instanceSpawnPosition, onInstanced, onComplete, amountOfInstances).Forget();
        }

        private Vector3 GetStaticSpawnPointPosition() => transform.position;
        
        private Vector3 GetRandomSpawnPointPosition() => 
            transform.position
            + Vector3.right
            * Random.Range(-_spawnPointPositionOffset, _spawnPointPositionOffset);
        
        private async UniTaskVoid GenerateContentAsync(
            GeneratedContentConfiguration contentConfiguration,
            Func<Vector3> instanceSpawnPosition,
            Action<Animal> onInstanced,
            Action onComplete,
            int amountOfInstances = -1)
        {
            Animal[] prefabs = contentConfiguration.GetAnimalPrefabs();

            int sequenceLength = amountOfInstances == -1 ?
                contentConfiguration.AmountOfAnimalsPerGeneration : amountOfInstances;
            
            InitializeGenerationSequence(sequenceLength,
                contentConfiguration.AnimalsMultiplicityFactor,
                prefabs.Length);

            await UniTask.WaitForEndOfFrame();

            foreach (int prefabIndex in _generationSequence)
            {
                Animal instance = CreateInstance(prefabs[prefabIndex], instanceSpawnPosition.Invoke());
                
                onInstanced?.Invoke(instance);
                
                await UniTask.WaitForSeconds(_delayBetweenGenerations);
            }
            
            onComplete?.Invoke();
        }


        // при усложнении логики создания животных можно вынести ее в отдельную фабрику,
        // заинжектив в этот класс в качестве зависимости
        private Animal CreateInstance(Animal prefab, Vector3 position)
        {
            return Instantiate(prefab, position, Quaternion.identity);
        }
        
        private void InitializeGenerationSequence(int sequenceLength, int animalsMultiplicityFactor, int prefabAmount)
        {
            _generationSequence = new int[sequenceLength];

            Debug.Log(_generationSequence.Length);
            
            int prefabIndex = 0;

            for (int i = 0; i < sequenceLength / animalsMultiplicityFactor; i++)
            {
                for (int j = 0; j < animalsMultiplicityFactor; j++)
                    _generationSequence[i * animalsMultiplicityFactor + j] = prefabIndex;

                prefabIndex++;
                
                if (prefabIndex == prefabAmount)
                    prefabIndex = 0;
            }
            
            Shuffle(ref _generationSequence);
        }
        
        private void Shuffle(ref int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
    }
}
