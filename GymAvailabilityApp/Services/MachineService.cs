using GymAvailabilityApp.Data;
using GymAvailabilityApp.Models;
using GymAvailabilityApp.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GymAvailabilityApp.Services
{
    public class MachineService : IMachineService
    {
        private readonly GymAvaiabilityDbContext gymAvaiabilityDbContext;

        public MachineService(GymAvaiabilityDbContext gymAvaiabilityDbContext)
        {
            this.gymAvaiabilityDbContext = gymAvaiabilityDbContext;
        }

        public Task<MachineModel> CreateMachine(MachineModel machine)
        {
            throw new NotImplementedException();
        }

        public Task<MachineModel> DeleteMachine(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MachineModel> GetMachine(int id)
        {
            var returnedMachine = await (from machine in this.gymAvaiabilityDbContext.Machines
                                 where machine.Id == id
                                 select new MachineModel
                                 {
                                     Id = machine.Id,
                                     Name = machine.Name,
                                     ImageFileLink = machine.ImageFileLink,
                                     Description = machine.Description,
                                     DeviceEUI = machine.DeviceEUI
                                 }).SingleOrDefaultAsync();
            if (returnedMachine == null)
            {
                return returnedMachine;
            }
            var returnedAvaiabilityReport = await (from avaiabilityReport in this.gymAvaiabilityDbContext.AvaiabilityReports
                                           where avaiabilityReport.MachineId == id
                                           orderby avaiabilityReport.Timestamp descending
                                           select new AvaiabilityReportModel
                                           {
                                               Id = avaiabilityReport.Id,
                                               CurrentState = avaiabilityReport.CurrentState,
                                               PreviousState = avaiabilityReport.PreviousState,
                                               Timestamp = avaiabilityReport.Timestamp     
                                           }).FirstOrDefaultAsync();
            if(returnedAvaiabilityReport == null)
            {
                returnedMachine.IsOccupied = false;
                return returnedMachine;
            }
            returnedMachine.IsOccupied = returnedAvaiabilityReport.CurrentState == "True";

            return returnedMachine;
        }

        public async Task<List<MachineModel>> GetMachines()
        {
           var machines = await ( from machine in this.gymAvaiabilityDbContext.Machines
                                  select new MachineModel
                                  {
                                        Id = machine.Id,
                                        Name = machine.Name,
                                        ImageFileLink = machine.ImageFileLink,
                                        Description = machine.Description,
                                        DeviceEUI = machine.DeviceEUI
                                  }).ToListAsync();
            if (machines !=null )
            {
                return machines;
            }
            else
            {
                return new List<MachineModel> { };
            }
        }

        public Task<MachineModel> UpdateMachine(MachineModel machine)
        {
            throw new NotImplementedException();
        }
    }
}
