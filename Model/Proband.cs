namespace WPF_demo.Model {
	public class Proband {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool IsMale { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime DateOfMeasurement { get; set; }
		public double WeightKg { get; set; }
		public double HeightCm { get; set; }
		public string? Notes { get; set; }

		public Proband(string firstName, string lastName, bool isMale, DateTime dateOfBirth, DateTime dateOfMeasurement, double weightKg, double heightCm, string? notes) {
			FirstName = firstName;
			LastName = lastName;
			IsMale = isMale;
			DateOfBirth = dateOfBirth;
			DateOfMeasurement = dateOfMeasurement;
			WeightKg = weightKg;
			HeightCm = heightCm;
			Notes = notes;
		}
	}
}