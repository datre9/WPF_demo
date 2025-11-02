using System;
using WPF_demo.Store;
using WPF_demo.ViewModel;

namespace WPF_demo.Command {
	internal class NavigateNewProbandCommand : CommandBase {
		private readonly NavigationStore _navigationStore;
		private readonly ProbandStore _probandStore;

		public NavigateNewProbandCommand(NavigationStore navigationStore, ProbandStore probandStore) {
			_navigationStore = navigationStore;
			_probandStore = probandStore;
		}

		public override void Execute(object? parameter) {
			_navigationStore.CurrentViewModel = new NewProbandViewModel(_navigationStore, _probandStore);
		}
	}
}