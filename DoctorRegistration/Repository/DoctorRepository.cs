using DoctorRegistration.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorRegistration.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private AppDbContext _context;
        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> FilterDoctorsAsync(DoctorFilterRequest filter)
        {
            var query = _context.Doctors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Specialization))
            {
                query = query.Where(d => d.Specialization == filter.Specialization);
            }

            if (filter.MinExperience.HasValue)
            {
                query = query.Where(d => d.Experiences >= filter.MinExperience.Value);
            }

            if (filter.MinRating.HasValue)
            {
                query = query.Where(d => d.Rating >= filter.MinRating.Value);
            }

            if (filter.MaxConsultationFee.HasValue)
            {
                query = query.Where(d => d.ConsultationFee <= filter.MaxConsultationFee.Value);
            }

            // Executes SQL only here
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            var doc = await _context.Doctors.ToListAsync();
            return (doc);
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var doc = await _context.Doctors.FirstOrDefaultAsync(x => x.DoctorId == id);
            return (doc);
        }

        public async Task<bool> LoginDoctor(LoginDTO loginDTO)
        {
            var dr = await _context.Doctors.FirstOrDefaultAsync(x => x.Email == loginDTO.Email);

            if (dr == null)
                return false;

            if (dr.Password == loginDTO.Password)
                return true;

            return false;
        }


        public async Task RegisterDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
