using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.UI.ActionBar
{
    public class ActionBarSlotView : MonoBehaviour, IActionBarSlotView
    {
        [SerializeField] private Sprite _default;
        [SerializeField] private Image _animal;
        [SerializeField] private Image _backgroundForm;
        [SerializeField] private Image _backgroundColored;
        
        public void UpdateView(Sprite animalIcon, Sprite backgroundForm, Color backgroundColor)
        {
            _animal.sprite = animalIcon;
            _backgroundForm.sprite = backgroundForm;
            _backgroundColored.sprite = backgroundForm;
            _backgroundColored.color = backgroundColor;
        }

        public void Clear()
        {
            _animal.sprite = _default;
            _backgroundForm.sprite = _default;
            _backgroundColored.sprite = _default;
            _backgroundColored.color = new Color(0, 0, 0, 0);
        }
    }
}