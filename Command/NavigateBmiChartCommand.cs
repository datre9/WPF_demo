using System;
using WPF_demo.Store;
using WPF_demo.ViewModel;

namespace WPF_demo.Command {
	internal class NavigateBmiChartCommand : CommandBase {
		private readonly NavigationStore _navigationStore;

		public NavigateBmiChartCommand(NavigationStore navigationStore) {
			_navigationStore = navigationStore;
		}

		public override void Execute(object? parameter) {
			_navigationStore.CurrentViewModel = new BmiChartViewModel(_navigationStore);
		}
	}
}