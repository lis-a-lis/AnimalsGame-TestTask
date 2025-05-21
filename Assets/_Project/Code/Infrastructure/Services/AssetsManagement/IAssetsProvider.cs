using UnityEngine;

namespace _Project.Code.Infrastructure.Services.AssetsManagement
{
    public interface IAssetsProvider
    {
        public TPrefab LoadPrefab<TPrefab>(string path) where TPrefab : MonoBehaviour;
        public TScriptableObject LoadScriptableObject<TScriptableObject>(string path) where TScriptableObject : ScriptableObject;
    }
}