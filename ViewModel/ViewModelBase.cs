using System.ComponentModel;

namespace WPF_demo.ViewModel {
	internal class ViewModelBase : INotifyPropertyChanged {
		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged(string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}