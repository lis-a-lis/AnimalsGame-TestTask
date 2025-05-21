using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.UI.Rebuild
{
    [RequireComponent(typeof(Button))]
    public class RebuildButtonView : MonoBehaviour
    {
        private Button _button;

        public event Action Clicked; 

        public void OnClickButtonHandle()
        {
            Debug.Log("Button clicked");
            
            Clicked?.Invoke();
        }
    }
}