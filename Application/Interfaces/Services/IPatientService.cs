using MapProject.Models;
using Microsoft.AspNetCore.Identity;

namespace MapProject.Application.Interfaces.Services
{
    public class IPatientService
    {
        Task<UserInfo> GetAsync(long id);//find
        Task<(long, string)> CreateAsync(TiepNhanCreateRequest request);//create
        Task<TiepNhan> PutAsync(long id, TiepNhanUpdateRequest request);
        Task<bool> Delete(long id);
        Task<(List<TiepNhanDanhSachReponse>, int)> GetAsyncWithConclusion(TimKiemTiepNhanRequest request);
        Task ChangeStatusAsync(long id, string NoiDung, TrangThaiTiepNhan status, int? userId);
        Task<TiepNhanThongTinReponse> GetJoinAsync(long id);//find
    }
}
