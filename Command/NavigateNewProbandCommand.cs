using System;
using WPF_demo.Store;
using WPF_demo.ViewModel;

namespace WPF_demo.Command {
	internal class NavigateNewProbandCommand : CommandBase {
		private readonly NavigationStore _navigationStore;

		public NavigateNewProbandCommand(NavigationStore navigationStore) {
			_navigationStore = navigationStore;
		}

		public override void Execute(object? parameter) {
			_navigationStore.CurrentViewModel = new NewProbandViewModel(_navigationStore);
		}
	}
}