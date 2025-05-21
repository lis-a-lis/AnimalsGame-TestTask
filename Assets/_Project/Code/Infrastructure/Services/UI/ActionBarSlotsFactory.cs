using UnityEngine;
using _Project.Code.UI.ActionBar;
using _Project.Code.Infrastructure.Services.AssetsManagement;

namespace _Project.Code.Infrastructure.Services.UI
{
    public class ActionBarSlotsFactory : IActionBarSlotsFactory
    {
        private readonly Transform _slotsParent;
        private readonly ActionBarSlotView _prefab;

        public ActionBarSlotsFactory(IAssetsProvider assetsProvider, Transform slotsParent)
        {
            _slotsParent = slotsParent;
            _prefab = assetsProvider.LoadPrefab<ActionBarSlotView>(UIPrefabPaths.PathToPrefab);
        }
        
        public IActionBarSlotView CreateSlotView() =>
            Object.Instantiate(_prefab, _slotsParent);
    }
}