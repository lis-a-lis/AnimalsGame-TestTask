using UnityEngine;

namespace _Project.Code.UI.ActionBar
{
    public interface IActionBarSlotView
    {
        public void UpdateView(Sprite animalIcon, Sprite backgroundForm, Color backgroundColor);
        public void Clear();
    }
}