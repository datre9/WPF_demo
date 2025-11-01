using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System.Windows.Controls;

namespace WPF_demo.View.UserControls {
	public partial class chart : UserControl {
		public chart() {
			InitializeComponent();

			Series = new ISeries[]
			{
				new LineSeries<double> { Name = "Mary", Values = new double[] { 5, 10, 8, 4 } },
				new LineSeries<double> { Name = "Ana", Values = new double[] { 4, 7, 3, 8 } }
			};

			DataContext = this;
		}

		public ISeries[] Series { get; set; }

		public ObservablePoint[] Values { get; set; } = [
		new(0, 4),
		new(1, 3),
		new(3, 8),
		new(18, 6),
		new(20, 12)
		];
	}
}