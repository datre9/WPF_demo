using System.Windows;
using WPF_demo.Store;
using WPF_demo.ViewModel;

namespace WPF_demo {
	public partial class App : Application {

		protected override void OnStartup(StartupEventArgs e) {
			NavigationStore navigationStore = new NavigationStore();
			ProbandStore probandStore = new ProbandStore();

			navigationStore.CurrentViewModel = new NewProbandViewModel(navigationStore, probandStore);

			MainWindow = new MainWindow() {
				DataContext = new MainWindowViewModel(navigationStore)
			};
			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}