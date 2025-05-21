using TMPro;
using UnityEngine;

namespace _Project.Code.UI.FinalScreen
{
    public class FinalScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        
        public void UpdateView(string text)
        {
            _titleText.text = text;   
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}