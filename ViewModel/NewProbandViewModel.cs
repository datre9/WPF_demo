using System;
using System.Windows.Input;
using WPF_demo.Command;
using WPF_demo.Store;

namespace WPF_demo.ViewModel {
	public class NewProbandViewModel : ViewModelBase {
		private string? _firstName;
		private string? _lastName;
		private bool _isMale = true;
		private DateTime? _dateOfBirth;
		private double _weightKg;
		private double _heightCm;
		private string? _notes;

		public string? FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(nameof(FirstName)); } }
		public string? LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(nameof(LastName)); } }
		public bool IsMale { get => _isMale; set { _isMale = value; OnPropertyChanged(nameof(IsMale)); } }
		public DateTime? DateOfBirth { get => _dateOfBirth; set { _dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); } }
		public double WeightKg { get => _weightKg; set { _weightKg = value; OnPropertyChanged(nameof(WeightKg)); } }
		public double HeightCm { get => _heightCm; set { _heightCm = value; OnPropertyChanged(nameof(HeightCm)); } }
		public string? Notes { get => _notes; set { _notes = value; OnPropertyChanged(nameof(Notes)); } }

		public ICommand CreateProbandCommand { get; }

		public NewProbandViewModel(NavigationStore navigationStore, ProbandStore probandStore) {
			CreateProbandCommand = new CreateProbandCommand(this, navigationStore, probandStore);
		}
	}
}