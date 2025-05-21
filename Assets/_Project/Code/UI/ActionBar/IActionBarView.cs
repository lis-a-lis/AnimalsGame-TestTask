using UnityEngine;

namespace _Project.Code.UI.ActionBar
{
    public interface IActionBarView
    {
        public void SetIcon(Sprite icon, int position);
        public void ClearIcon(int position);
    }
}