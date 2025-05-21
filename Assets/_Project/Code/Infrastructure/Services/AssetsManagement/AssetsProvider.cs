using UnityEngine;

namespace _Project.Code.Infrastructure.Services.AssetsManagement
{
    public class AssetsProvider : IAssetsProvider
    {
        public TPrefab LoadPrefab<TPrefab>(string path) where TPrefab : MonoBehaviour
        {
            TPrefab prefab = Resources.Load<TPrefab>(path);
            
            return prefab;
        }

        public TScriptableObject LoadScriptableObject<TScriptableObject>(string path) where TScriptableObject : ScriptableObject
        {
            return Resources.Load<TScriptableObject>(path);
        }
    }
}