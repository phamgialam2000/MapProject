using Azure.Core;
using MapProject.Application.Interfaces;
using MapProject.Application.Interfaces.Repositories;
using MapProject.Data;
using MapProject.Infrastructure.AppDbContext;
using MapProject.Models;
using MapProject.ViewModel.Patient;
using Microsoft.EntityFrameworkCore;

namespace MapProject.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Patient>> GetAsync()
        {
            var result = await _context.Patients.Where(x => x.Isdelete == false).ToListAsync();
            return result;
        }


        public async Task<Patient> FindAsync(long id)
        {
            var result = await _context.Patients.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            return result ?? throw new NotImplementedException();
        }

        public async Task<Patient> CreateAsync(Patient entity)
        {
            await _context.Patients.AddAsync(entity);
            return entity;

        }
        public Task UpdateAsync(Patient entity)
        {
            _context.Patients.Update(entity);
            return Task.CompletedTask;  // Đánh dấu phương thức là hoàn thành ngay lập tức (vì Update không cần chờ)
        }

        public Task DeleteAsync(Patient entity)
        {
            _context.Patients.Remove(entity);
            return Task.CompletedTask;

        }

    public async Task<bool> SoftDeleteAsync(int id)
        {
            var entity = await _context.Patients.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException("Patient not found.");

            entity.Isdelete = true;

            _context.Patients.Update(entity);
            return true;
        }

        public async Task<(List<PatientResponse>, int)> Search(PatientRequest req)
        {
            var query = _context.Patients
                        .AsNoTracking()
                        .Where(x => x.Isdelete == false)
                        .IgnoreQueryFilters();
                

            if (req.Page == 0 || req.PageSize == 0)
            {
                req.Page = 1;
                req.PageSize = 10;
            }

            if (!string.IsNullOrEmpty(req.Name))
            {
                query = query.Where(x => x.Name.Contains(req.Name));
            }
            #region find by properties
            //if (!string.IsNullOrEmpty(req.Type))
            //{
            //    query = query.Where(x => x.Type.Contains(req.Type));
            //}

            //if (!string.IsNullOrEmpty(req.Level))
            //{
            //    query = query.Where(x => x.Level.Contains(req.Level));
            //}

            //if (!string.IsNullOrEmpty(req.Address))
            //{
            //    query = query.Where(x => x.Address.Contains(req.Address));
            //}

            //if (!string.IsNullOrEmpty(req.Date))
            //{
            //    query = query.Where(x => x.Date.Contains(req.Date));
            //}

            //if (!string.IsNullOrEmpty(req.Dateofbirth))
            //{
            //    query = query.Where(x => x.Dateofbirth.Contains(req.Dateofbirth));
            //}

            //if (!string.IsNullOrEmpty(req.Phone))
            //{
            //    query = query.Where(x => x.Phone.Contains(req.Phone));
            //}

            //if (req.District != null)
            //{
            //    query = query.Where(x => x.District == req.District);
            //}

            //if (req.Group != null)
            //{
            //    query = query.Where(x => x.Group == req.Group);
            //}
            #endregion

            int totalCount = query.Count();
            int startIndex = (req.Page - 1) * req.PageSize;

            //Lỗi này xảy ra vì biểu thức Select((x, index) => new PatientResponse { ... }) không thể được dịch sang SQL bởi EF Core. 
            //Phần index là một giá trị tính toán trên client, và EF Core không hỗ trợ trực tiếp việc tính toán chỉ số dựa trên thứ tự trong truy vấn SQL.
            //Để khắc phục, bạn có thể tính chỉ số(Index) sau khi dữ liệu đã được lấy từ database.Điều này đảm bảo rằng các phần của truy vấn không bị giới hạn bởi khả năng dịch sang SQL.

            var pagedData = await query
            .Skip(startIndex)
            .Take(req.PageSize)
            .ToListAsync(); // Lấy dữ liệu từ database trước

            var result = pagedData
                //.OrderBy(x => x.Id)
                //.Skip(startIndex)
                //.Take(req.PageSize)
                .Select((x, index) => new PatientResponse
                {
                    Index = startIndex + index + 1,
                    Id = x.Id,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    Type = x.Type,
                    Name = x.Name,
                    Level = x.Level,
                    Group = x.Group,
                    Note = x.Note,
                    Address = x.Address,
                    Date = x.Date,
                    District = x.District,
                    Dateofbirth = x.Dateofbirth,
                    Phone = x.Phone
                })
                .ToList();

            return (result, totalCount);
        }

    }
}
