using System;
using System.Windows.Input;
using System.ComponentModel;
using LiveChartsCore.Defaults;
using WPF_demo.Command;
using WPF_demo.Store;

namespace WPF_demo.ViewModel {
	public class BmiChartViewModel : ViewModelBase {
		public ICommand NavigateNewProbandCommand { get; }
		private readonly ProbandStore _probandStore;

		public Model.Proband? CurrentProband => _probandStore.CurrentProband;

		// BMI point to plot on the chart (x = age in years, y = BMI)
		public ObservablePoint[] BmiPoint { get; private set; } = Array.Empty<ObservablePoint>();

		// Text with all proband information to show in the textbox
		public string InfoText { get; private set; } = string.Empty;

		// Expose name separately so the view can bind directly and we can guarantee it's updated
		public string FullName { get; private set; } = string.Empty;

		public BmiChartViewModel(NavigationStore navigationStore, ProbandStore probandStore) {
			_probandStore = probandStore;
			NavigateNewProbandCommand = new NavigateNewProbandCommand(navigationStore, probandStore);

			// initial build (if available)
			UpdateFromProband(_probandStore.CurrentProband);

			// react to future changes
			_probandStore.CurrentProbandChanged += OnStoreCurrentProbandChanged;
		}

		private void OnStoreCurrentProbandChanged() {
			UpdateFromProband(_probandStore.CurrentProband);
		}

		private void UpdateFromProband(Model.Proband? p) {
			if (p == null) {
				BmiPoint = Array.Empty<ObservablePoint>();
				InfoText = string.Empty;
				FullName = string.Empty;
				OnPropertyChanged(nameof(BmiPoint));
				OnPropertyChanged(nameof(InfoText));
				OnPropertyChanged(nameof(FullName));
				return;
			}

			var ageYears = (DateTime.Today - p.DateOfBirth).TotalDays / 365.25;
			var heightM = p.HeightCm / 100.0;
			double bmi = (heightM > 0 && p.WeightKg > 0) ? p.WeightKg / (heightM * heightM) : 0.0;

			BmiPoint = new[] { new ObservablePoint(ageYears, bmi) };

			// use safe fallbacks for name parts so the InfoText never shows an empty name line
			var first = string.IsNullOrWhiteSpace(p.FirstName) ? "<unknown>" : p.FirstName.Trim();
			var last = string.IsNullOrWhiteSpace(p.LastName) ? string.Empty : p.LastName.Trim();
			var fullName = (first + " " + last).Trim();

			FullName = fullName;

			InfoText =
				$"Name: {fullName}\n" +
				$"Sex: {(p.IsMale ? "Male" : "Female")}\n" +
				$"DOB: {p.DateOfBirth:yyyy-MM-dd}\n" +
				$"Age: {ageYears:F1} years\n" +
				$"Weight: {p.WeightKg:F1} kg\n" +
				$"Height: {p.HeightCm:F1} cm\n" +
				$"BMI: {bmi:F1}\n" +
				$"Notes: {p.Notes ?? string.Empty}";

			OnPropertyChanged(nameof(BmiPoint));
			OnPropertyChanged(nameof(InfoText));
			OnPropertyChanged(nameof(FullName));
		}
	}
}