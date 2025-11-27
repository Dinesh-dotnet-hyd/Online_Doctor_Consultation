using DoctorRegistration.Model;

namespace DoctorRegistration.Repository
{
    public interface IDoctorRepository
    {
        public Task<IEnumerable<Doctor>> GetAll();
        public Task<IEnumerable<Doctor>> FilterDoctorsAsync(DoctorFilterRequest filter);
        public Task<Doctor> GetDoctorByIdAsync(int id);
        public Task RegisterDoctor(Doctor doctor);

        public Task<bool> LoginDoctor(LoginDTO loginDTO);

    }
}
