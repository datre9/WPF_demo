using System;
using System.Windows.Input;
using WPF_demo.Command;
using WPF_demo.Store;

namespace WPF_demo.ViewModel {
	public class BmiChartViewModel : ViewModelBase {
		public ICommand NavigateNewProbandCommand { get; }

		public BmiChartViewModel(NavigationStore navigationStore) {
			NavigateNewProbandCommand = new NavigateNewProbandCommand(navigationStore);
		}
	}
}