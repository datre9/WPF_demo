using WPF_demo.ViewModel;

namespace WPF_demo.Store {
	public class NavigationStore {
		private ViewModelBase? _currentViewModel;
		public ViewModelBase? CurrentViewModel {
			get => _currentViewModel;
			set {
				if (_currentViewModel == value) return;
				_currentViewModel = value;
				CurrentViewModelChanged?.Invoke();
			}
		}

		public event Action? CurrentViewModelChanged;
	}
}