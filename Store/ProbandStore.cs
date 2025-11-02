namespace WPF_demo.Store {
	public class ProbandStore {
		private Model.Proband? _currentProband;
		public Model.Proband? CurrentProband {
			get => _currentProband;
			set {
				if (!ReferenceEquals(_currentProband, value)) {
					_currentProband = value;
					CurrentProbandChanged?.Invoke();
				}
			}
		}

		public event System.Action? CurrentProbandChanged;
	}
}	