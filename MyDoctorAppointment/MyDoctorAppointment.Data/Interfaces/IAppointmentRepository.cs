using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
	public interface IAppointmentRepository
	{
		Appointment GetAllByDoctor(Doctor doctor);

		Appointment GetAllByPatient(Patient patient);
	}
}