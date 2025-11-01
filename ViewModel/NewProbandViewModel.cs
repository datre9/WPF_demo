using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_demo.Command;
using WPF_demo.Store;

namespace WPF_demo.ViewModel {
	public class NewProbandViewModel : ViewModelBase{

		public ICommand NavigateBmiChartCommand { get; }

		public NewProbandViewModel(NavigationStore navigationStore) {
			NavigateBmiChartCommand = new NavigateBmiChartCommand(navigationStore);
		}
	}
}