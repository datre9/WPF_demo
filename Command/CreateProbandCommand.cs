using System.Windows;
using WPF_demo.Model;
using WPF_demo.Store;
using WPF_demo.ViewModel;

namespace WPF_demo.Command {
	internal class CreateProbandCommand : CommandBase {
		private readonly NewProbandViewModel _viewModel;
		private readonly NavigationStore _navigationStore;
		private readonly ProbandStore _probandStore;

		public CreateProbandCommand(NewProbandViewModel viewModel, NavigationStore navigationStore, ProbandStore probandStore) {
			_viewModel = viewModel;
			_navigationStore = navigationStore;
			_probandStore = probandStore;
		}

		public override void Execute(object? parameter) {
			string? message = ValidateInput();
			if (!string.IsNullOrWhiteSpace(message)) {
				MessageBox.Show(message, "Validační Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			var firstName = _viewModel.FirstName ?? string.Empty;
			var lastName = _viewModel.LastName ?? string.Empty;
			var isMale = _viewModel.IsMale;
			var dob = _viewModel.DateOfBirth ?? DateTime.MinValue;
			var measurement = _viewModel.DateOfMeasurement ?? DateTime.Today;
			var weight = _viewModel.WeightKg;
			var height = _viewModel.HeightCm;
			var notes = _viewModel.Notes;

			var proband = new Proband(firstName, lastName, isMale, dob, measurement, weight, height, notes);

			_probandStore.CurrentProband = proband;

			_navigationStore.CurrentViewModel = new ViewModel.BmiChartViewModel(_navigationStore, _probandStore);
		}

		private string? ValidateInput() {
			string? message = null;

			if (string.IsNullOrWhiteSpace(_viewModel.FirstName)) {
				message += "Zadejte křestní jméno\n";
			}

			if (string.IsNullOrWhiteSpace(_viewModel.LastName)) {
				message += "Zadejte příjmení\n";
			}

			if (!_viewModel.DateOfBirth.HasValue || _viewModel.DateOfBirth > DateTime.Now) {
				message += "Zadejte platné datum narození\n";
			}

			if (!_viewModel.DateOfMeasurement.HasValue || _viewModel.DateOfMeasurement > DateTime.Now) {
				message += "Zadejte platné datum měření\n";
			}

			if ((_viewModel.HeightCm <= 30.0 && _viewModel.HeightCm >= 200.0) || _viewModel.HeightCm == 0.0) {
				message += "Zadejte výšku v rozmezí 30–200 cm\n";
			}

			if ((_viewModel.WeightKg <= 1.5 && _viewModel.WeightKg >= 200.0) || _viewModel.WeightKg == 0.0) {
				message += "Zadejte váhu v rozmezí 1,5–200 kg\n";
			}

			return message;
		}
	}
}