using System;
using WPF_demo.Store;

namespace WPF_demo.ViewModel {
	internal class MainWindowViewModel : ViewModelBase {
		private readonly NavigationStore _navigationStore;

		public ViewModelBase? CurrentViewModel => _navigationStore.CurrentViewModel;

		public MainWindowViewModel(NavigationStore navigationStore) {
			_navigationStore = navigationStore;
			_navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
		}

		private void OnCurrentViewModelChanged() {
			OnPropertyChanged(nameof(CurrentViewModel));
		}
	}
} 