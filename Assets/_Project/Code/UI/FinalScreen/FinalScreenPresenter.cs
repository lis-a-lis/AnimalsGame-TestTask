using _Project.Code.Infrastructure.Root;

namespace _Project.Code.UI.FinalScreen
{
    public class FinalScreenPresenter
    {
        private readonly FinalScreenView _view;
        private readonly IGameResultNotifier _notifier;

        public FinalScreenPresenter(FinalScreenView view, IGameResultNotifier notifier)
        {
            _view = view;
            _notifier = notifier;

            _notifier.Won += OnPlayerWon;
            _notifier.Lost += OnPlayerLost;
        }

        private void OnPlayerLost(string message)
        {
            ShowFinalScreen(message);
        }

        private void OnPlayerWon(string message)
        {
            ShowFinalScreen(message);
        }

        private void ShowFinalScreen(string message)
        {
            _view.UpdateView(message);

            _view.Show();
        }
    }
}