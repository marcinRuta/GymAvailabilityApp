﻿
using GymAvailabilityApp.Models;

namespace GymAvailabilityApp.Services.Contracts
{
    public interface IMachineService
    {
        Task<List<MachineModel>> GetMachines();
        Task<MachineModel> GetMachine(int id);
        Task<MachineModel> CreateMachine(MachineModel machine);
        Task<MachineModel> UpdateMachine(MachineModel machine);
        Task<MachineModel> DeleteMachine(int id);
    
    }
}