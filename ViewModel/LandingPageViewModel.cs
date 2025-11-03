using System.Windows.Input;
using WPF_demo.Command;
using WPF_demo.Store;

namespace WPF_demo.ViewModel {
	class LandingPageViewModel : ViewModelBase {
		public ICommand NavigateNewProbandCommand { get; }

		public LandingPageViewModel(NavigationStore navigationStore, ProbandStore probandStore) {
			NavigateNewProbandCommand = new NavigateNewProbandCommand(navigationStore, probandStore);
		}
	}
}