using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace WPF_demo.View.UserControls {
	public partial class BmiChart : UserControl {
		private INotifyPropertyChanged? _vmNotifier;

		public BmiChart() {
			InitializeComponent();

			Series = new ISeries[]
			{
				new LineSeries<ObservablePoint>
				{
					Name = "97. percentil",
					Fill = null,
					GeometrySize = 0,
					Values = perc97
				},
				new LineSeries<ObservablePoint>
				{
					Name = "90. percentil",
					Fill = null,
					GeometrySize = 0,
					Values = perc90
				},
				new LineSeries<ObservablePoint>
				{
					Name = "75. percentil",
					Fill = null,
					GeometrySize = 0,
					Values = perc75
				},
				new LineSeries<ObservablePoint>
				{
					Name = "50. percentil",
					Fill = null,
					GeometrySize = 0,
					Values = perc50
				},
				new LineSeries<ObservablePoint>
				{
					Name = "25. percentil",
					Fill = null,
					GeometrySize = 0,
					Values = perc25
				},
				new LineSeries<ObservablePoint>
				{
					Name = "10. percentil",
					Fill = null,
					GeometrySize = 0,
					Values = perc10
				},
				new LineSeries<ObservablePoint>
				{
					Name = "3. percentil",
					Fill = null,
					GeometrySize = 0,
					Values = perc3
				},
			};

			// set the chart series initially
			Chart.Series = Series;

			// react to DataContext changes so we can add the proband BMI point when the viewmodel is assigned
			this.DataContextChanged += BmiChart_DataContextChanged;
		}

		// TODO: data pouze chalpcu, pridat data pro dívky
		public ISeries[] Series { get; set; }

		private void BmiChart_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e) {
			// unsubscribe old vm propertychanged
			if (_vmNotifier != null) {
				_vmNotifier.PropertyChanged -= Vm_PropertyChanged;
				_vmNotifier = null;
			}

			if (e.NewValue is ViewModel.BmiChartViewModel vm) {
				_vmNotifier = vm as INotifyPropertyChanged;
				if (_vmNotifier != null) {
					_vmNotifier.PropertyChanged += Vm_PropertyChanged;
				}

				// build chart right now using current vm state
				ApplyVmToChart(vm);
			} else {
				Chart.Series = Series;
			}
		}

		private void Vm_PropertyChanged(object? sender, PropertyChangedEventArgs e) {
			if (sender is ViewModel.BmiChartViewModel vm && (e.PropertyName == nameof(ViewModel.BmiChartViewModel.BmiPoint) || string.IsNullOrEmpty(e.PropertyName))) {
				// update chart when BmiPoint changes
				ApplyVmToChart(vm);
			}
		}

		private void ApplyVmToChart(ViewModel.BmiChartViewModel vm) {
			if (vm.BmiPoint != null && vm.BmiPoint.Length > 0) {
				var seriesList = new List<ISeries>(Series);

				// prefer the VM FullName for the legend
				var probandName = string.IsNullOrWhiteSpace(vm.FullName) ? "Proband BMI" : vm.FullName;

				seriesList.Add(new LineSeries<ObservablePoint>
				{
					Name = $"Proband: {probandName}",
					Fill = null,
					GeometrySize = 10, // visible marker
					Values = vm.BmiPoint
				});

				Chart.Series = seriesList.ToArray();
			} else {
				Chart.Series = Series;
			}
		}

		public ObservablePoint[] perc3 { get; set; } = new ObservablePoint[]
		{
			new ObservablePoint(0.0, 11.4),
new ObservablePoint(0.2, 12.4),
new ObservablePoint(0.4, 13.4),
new ObservablePoint(0.6, 14.0),
new ObservablePoint(0.8, 14.4),
new ObservablePoint(1.0, 14.5),
new ObservablePoint(1.2, 14.5),
new ObservablePoint(1.4, 14.3),
new ObservablePoint(1.6, 14.2),
new ObservablePoint(1.8, 14.0),
new ObservablePoint(2.0, 13.9),
new ObservablePoint(2.2, 13.7),
new ObservablePoint(2.4, 13.7),
new ObservablePoint(2.6, 13.6),
new ObservablePoint(2.8, 13.5),
new ObservablePoint(3.0, 13.5),
new ObservablePoint(3.5, 13.4),
new ObservablePoint(4.0, 13.3),
new ObservablePoint(4.5, 13.2),
new ObservablePoint(5.0, 13.1),
new ObservablePoint(5.5, 13.0),
new ObservablePoint(6.0, 13.1),
new ObservablePoint(7.0, 13.1),
new ObservablePoint(8.0, 13.2),
new ObservablePoint(9.0, 13.5),
new ObservablePoint(10.0, 13.7),
new ObservablePoint(11.0, 14.1),
new ObservablePoint(12.0, 14.5),
new ObservablePoint(13.0, 15.0),
new ObservablePoint(14.0, 15.7),
new ObservablePoint(15.0, 16.4),
new ObservablePoint(16.0, 17.1),
new ObservablePoint(17.0, 17.6),
new ObservablePoint(18.0, 18.2),
		};

		public ObservablePoint[] perc10 { get; set; } = new ObservablePoint[]
{
			new ObservablePoint(0.0, 12.2),
new ObservablePoint(0.2, 13.2),
new ObservablePoint(0.4, 14.2),
new ObservablePoint(0.6, 14.9),
new ObservablePoint(0.8, 15.3),
new ObservablePoint(1.0, 15.4),
new ObservablePoint(1.2, 15.3),
new ObservablePoint(1.4, 15.1),
new ObservablePoint(1.6, 15.0),
new ObservablePoint(1.8, 14.8),
new ObservablePoint(2.0, 14.6),
new ObservablePoint(2.2, 14.5),
new ObservablePoint(2.4, 14.4),
new ObservablePoint(2.6, 14.3),
new ObservablePoint(2.8, 14.2),
new ObservablePoint(3.0, 14.2),
new ObservablePoint(3.5, 14.0),
new ObservablePoint(4.0, 13.9),
new ObservablePoint(4.5, 13.8),
new ObservablePoint(5.0, 13.8),
new ObservablePoint(5.5, 13.7),
new ObservablePoint(6.0, 13.7),
new ObservablePoint(7.0, 13.8),
new ObservablePoint(8.0, 13.9),
new ObservablePoint(9.0, 14.2),
new ObservablePoint(10.0, 14.5),
new ObservablePoint(11.0, 14.9),
new ObservablePoint(12.0, 15.4),
new ObservablePoint(13.0, 15.9),
new ObservablePoint(14.0, 16.6),
new ObservablePoint(15.0, 17.3),
new ObservablePoint(16.0, 18.0),
new ObservablePoint(17.0, 18.6),
new ObservablePoint(18.0, 19.1),
};

		public ObservablePoint[] perc25 { get; set; } = new ObservablePoint[]
{
			new ObservablePoint(0.0, 13.0),
new ObservablePoint(0.2, 14.1),
new ObservablePoint(0.4, 15.1),
new ObservablePoint(0.6, 15.8),
new ObservablePoint(0.8, 16.2),
new ObservablePoint(1.0, 16.3),
new ObservablePoint(1.2, 16.2),
new ObservablePoint(1.4, 16.0),
new ObservablePoint(1.6, 15.8),
new ObservablePoint(1.8, 15.6),
new ObservablePoint(2.0, 15.5),
new ObservablePoint(2.2, 15.3),
new ObservablePoint(2.4, 15.2),
new ObservablePoint(2.6, 15.1),
new ObservablePoint(2.8, 15.0),
new ObservablePoint(3.0, 14.9),
new ObservablePoint(3.5, 14.8),
new ObservablePoint(4.0, 14.7),
new ObservablePoint(4.5, 14.6),
new ObservablePoint(5.0, 14.5),
new ObservablePoint(5.5, 14.4),
new ObservablePoint(6.0, 14.5),
new ObservablePoint(7.0, 14.6),
new ObservablePoint(8.0, 14.8),
new ObservablePoint(9.0, 15.1),
new ObservablePoint(10.0, 15.5),
new ObservablePoint(11.0, 15.9),
new ObservablePoint(12.0, 16.4),
new ObservablePoint(13.0, 17.0),
new ObservablePoint(14.0, 17.7),
new ObservablePoint(15.0, 18.4),
new ObservablePoint(16.0, 19.1),
new ObservablePoint(17.0, 19.7),
new ObservablePoint(18.0, 20.3),
};

		public ObservablePoint[] perc50 { get; set; } = new ObservablePoint[]
{
			new ObservablePoint(0.0, 13.9),
new ObservablePoint(0.2, 15.1),
new ObservablePoint(0.4, 16.2),
new ObservablePoint(0.6, 17.0),
new ObservablePoint(0.8, 17.4),
new ObservablePoint(1.0, 17.5),
new ObservablePoint(1.2, 17.3),
new ObservablePoint(1.4, 17.1),
new ObservablePoint(1.6, 16.9),
new ObservablePoint(1.8, 16.7),
new ObservablePoint(2.0, 16.5),
new ObservablePoint(2.2, 16.3),
new ObservablePoint(2.4, 16.2),
new ObservablePoint(2.6, 16.0),
new ObservablePoint(2.8, 16.0),
new ObservablePoint(3.0, 15.9),
new ObservablePoint(3.5, 15.7),
new ObservablePoint(4.0, 15.6),
new ObservablePoint(4.5, 15.5),
new ObservablePoint(5.0, 15.4),
new ObservablePoint(5.5, 15.4),
new ObservablePoint(6.0, 15.4),
new ObservablePoint(7.0, 15.6),
new ObservablePoint(8.0, 15.9),
new ObservablePoint(9.0, 16.3),
new ObservablePoint(10.0, 16.7),
new ObservablePoint(11.0, 17.2),
new ObservablePoint(12.0, 17.8),
new ObservablePoint(13.0, 18.4),
new ObservablePoint(14.0, 19.1),
new ObservablePoint(15.0, 19.8),
new ObservablePoint(16.0, 20.5),
new ObservablePoint(17.0, 21.1),
new ObservablePoint(18.0, 21.7),
};

		public ObservablePoint[] perc75 { get; set; } = new ObservablePoint[]
{
			new ObservablePoint(0.0, 15.0),
new ObservablePoint(0.2, 16.3),
new ObservablePoint(0.4, 17.4),
new ObservablePoint(0.6, 18.2),
new ObservablePoint(0.8, 18.6),
new ObservablePoint(1.0, 18.7),
new ObservablePoint(1.2, 18.6),
new ObservablePoint(1.4, 18.3),
new ObservablePoint(1.6, 18.1),
new ObservablePoint(1.8, 17.8),
new ObservablePoint(2.0, 17.6),
new ObservablePoint(2.2, 17.4),
new ObservablePoint(2.4, 17.2),
new ObservablePoint(2.6, 17.1),
new ObservablePoint(2.8, 17.0),
new ObservablePoint(3.0, 16.9),
new ObservablePoint(3.5, 16.7),
new ObservablePoint(4.0, 16.6),
new ObservablePoint(4.5, 16.5),
new ObservablePoint(5.0, 16.4),
new ObservablePoint(5.5, 16.4),
new ObservablePoint(6.0, 16.5),
new ObservablePoint(7.0, 16.8),
new ObservablePoint(8.0, 17.2),
new ObservablePoint(9.0, 17.7),
new ObservablePoint(10.0, 18.3),
new ObservablePoint(11.0, 18.9),
new ObservablePoint(12.0, 19.5),
new ObservablePoint(13.0, 20.1),
new ObservablePoint(14.0, 20.9),
new ObservablePoint(15.0, 21.5),
new ObservablePoint(16.0, 22.3),
new ObservablePoint(17.0, 22.9),
new ObservablePoint(18.0, 23.5),
};

		public ObservablePoint[] perc90 { get; set; } = new ObservablePoint[]
{
			new ObservablePoint(0.0, 16.0),
new ObservablePoint(0.2, 17.4),
new ObservablePoint(0.4, 18.6),
new ObservablePoint(0.6, 19.4),
new ObservablePoint(0.8, 19.8),
new ObservablePoint(1.0, 19.9),
new ObservablePoint(1.2, 19.8),
new ObservablePoint(1.4, 19.5),
new ObservablePoint(1.6, 19.2),
new ObservablePoint(1.8, 18.9),
new ObservablePoint(2.0, 18.7),
new ObservablePoint(2.2, 18.5),
new ObservablePoint(2.4, 18.3),
new ObservablePoint(2.6, 18.2),
new ObservablePoint(2.8, 18.0),
new ObservablePoint(3.0, 17.9),
new ObservablePoint(3.5, 17.7),
new ObservablePoint(4.0, 17.6),
new ObservablePoint(4.5, 17.5),
new ObservablePoint(5.0, 17.5),
new ObservablePoint(5.5, 17.5),
new ObservablePoint(6.0, 17.6),
new ObservablePoint(7.0, 18.0),
new ObservablePoint(8.0, 18.6),
new ObservablePoint(9.0, 19.3),
new ObservablePoint(10.0, 20.1),
new ObservablePoint(11.0, 20.8),
new ObservablePoint(12.0, 21.5),
new ObservablePoint(13.0, 22.1),
new ObservablePoint(14.0, 22.9),
new ObservablePoint(15.0, 23.5),
new ObservablePoint(16.0, 24.2),
new ObservablePoint(17.0, 24.8),
new ObservablePoint(18.0, 25.4),
};

		public ObservablePoint[] perc97 { get; set; } = new ObservablePoint[]
{
			new ObservablePoint(0.0, 17.1),
new ObservablePoint(0.2, 18.6),
new ObservablePoint(0.4, 19.8),
new ObservablePoint(0.6, 20.7),
new ObservablePoint(0.8, 21.1),
new ObservablePoint(1.0, 21.2),
new ObservablePoint(1.2, 21.1),
new ObservablePoint(1.4, 20.8),
new ObservablePoint(1.6, 20.4),
new ObservablePoint(1.8, 20.1),
new ObservablePoint(2.0, 19.9),
new ObservablePoint(2.2, 19.6),
new ObservablePoint(2.4, 19.4),
new ObservablePoint(2.6, 19.3),
new ObservablePoint(2.8, 19.2),
new ObservablePoint(3.0, 19.1),
new ObservablePoint(3.5, 18.8),
new ObservablePoint(4.0, 18.7),
new ObservablePoint(4.5, 18.6),
new ObservablePoint(5.0, 18.7),
new ObservablePoint(5.5, 18.7),
new ObservablePoint(6.0, 18.9),
new ObservablePoint(7.0, 19.5),
new ObservablePoint(8.0, 20.3),
new ObservablePoint(9.0, 21.3),
new ObservablePoint(10.0, 22.3),
new ObservablePoint(11.0, 23.3),
new ObservablePoint(12.0, 24.1),
new ObservablePoint(13.0, 24.7),
new ObservablePoint(14.0, 25.4),
new ObservablePoint(15.0, 25.9),
new ObservablePoint(16.0, 26.6),
new ObservablePoint(17.0, 27.1),
new ObservablePoint(18.0, 27.7),
};
	}
}