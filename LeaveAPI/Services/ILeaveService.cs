using LeaveAPI.Models;
using System.Collections.Generic;

namespace LeaveAPI.Services
{
    public interface ILeaveService
    {
        List<Leave> GetAllLeaves();
        List<LeaveType> GetAllLeaveTypes();
        Leave GetLeave(int id);

        void SaveLeave(Leave leave);
        void DeleteLeave(int id);
    }
}
