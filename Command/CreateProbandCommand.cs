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
			// Basic parsing/validation - adjust as needed.
			var firstName = _viewModel.FirstName ?? string.Empty;
			var lastName = _viewModel.LastName ?? string.Empty;
			var isMale = _viewModel.IsMale;
			var dob = _viewModel.DateOfBirth ?? DateTime.MinValue;
			var weight = _viewModel.WeightKg;
			var height = _viewModel.HeightCm;
			var notes = _viewModel.Notes;

			var proband = new Proband(firstName, lastName, isMale, dob, weight, height, notes);

			_probandStore.CurrentProband = proband;

			// Navigate to BMI chart and pass store
			_navigationStore.CurrentViewModel = new ViewModel.BmiChartViewModel(_navigationStore, _probandStore);
		}
	}
}