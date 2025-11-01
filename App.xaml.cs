using System.Windows;
using WPF_demo.ViewModel;

namespace WPF_demo {
	public partial class App : Application {

		protected override void OnStartup(StartupEventArgs e) {
			MainWindow = new MainWindow() {
				DataContext = new MainWindowViewModel()
			};
			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}