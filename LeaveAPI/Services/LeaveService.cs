using System.Linq;
using System.Collections.Generic;
using LeaveAPI.Data;
using LeaveAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveAPI.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly LeaveContext context;

        public LeaveService(LeaveContext context)
        {
            this.context = context;
        }

        public List<Leave> GetAllLeaves() =>
            context.Leaves.AsNoTracking().Include(l => l.Type).ToList();

        public Leave GetLeave(int id) =>
            context.Leaves.AsNoTracking().Single(l => l.Id == id);

        public List<LeaveType> GetAllLeaveTypes() =>
            context.LeaveTypes.AsNoTracking().ToList();

        public void SaveLeave(Leave leave)
        {
            if (leave.Id == null)
                context.Leaves.Add(leave);
            else
                context.Leaves.Update(leave);

            context.SaveChanges();
        }

        public void DeleteLeave(int id)
        {
            var leave = context.Leaves.Find(id);
            if (leave != null)
            {
                context.Leaves.Remove(leave);
                context.SaveChanges();
            }
        }
    }
}