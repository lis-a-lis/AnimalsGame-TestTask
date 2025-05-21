using _Project.Code.Gameplay;
using _Project.Code.UI.ActionBar;

namespace _Project.Code.Infrastructure.Services.UI
{
    public interface IActionBarSlotsFactory
    {
        public IActionBarSlotView CreateSlotView();
    }
}