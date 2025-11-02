using System;
using WPF_demo.Store;
using WPF_demo.ViewModel;

namespace WPF_demo.Command {
	internal class NavigateBmiChartCommand : CommandBase {
		private readonly NavigationStore _navigationStore;
		private readonly ProbandStore _probandStore;

		public NavigateBmiChartCommand(NavigationStore navigationStore, ProbandStore probandStore) {
			_navigationStore = navigationStore;
			_probandStore = probandStore;
		}

		public override void Execute(object? parameter) {
			_navigationStore.CurrentViewModel = new BmiChartViewModel(_navigationStore, _probandStore);
		}
	}
}