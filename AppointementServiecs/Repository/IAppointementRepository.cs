using AppointementServiecs.Model;

namespace AppointementServiecs.Repository
{
    public interface IAppointementRepository
    {
        Task AddAsync(Appointment appointment);
        Task<List<Appointment>> GetDoctorAppointmentsByDateAsync(int doctorId, DateTime dateLocal);

        Task<List<Appointment>> GetPatientPastAppointmentsAsync(int patientId, int page = 1, int pageSize = 20);
        Task<List<Appointment>> GetPatientFutureAppointmentsAsync(int patientId, int page = 1, int pageSize = 20);
    }
}
