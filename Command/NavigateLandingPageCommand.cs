using WPF_demo.Store;
using WPF_demo.ViewModel;

namespace WPF_demo.Command {
	internal class NavigateLandingPageCommand : CommandBase {
		private readonly NavigationStore _navigationStore;
		private readonly ProbandStore _probandStore;

		public NavigateLandingPageCommand(NavigationStore navigationStore, ProbandStore probandStore) {
			_navigationStore = navigationStore;
			_probandStore = probandStore;
		}

		public override void Execute(object? parameter) {
			_navigationStore.CurrentViewModel = new LandingPageViewModel(_navigationStore, _probandStore);
		}
	}
}