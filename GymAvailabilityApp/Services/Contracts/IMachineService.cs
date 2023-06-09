
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
        Task<List<GymRoomModel>> GetGymRooms();
        Task<GymModel> GetGym(int id);
        Task<List<MachineAvaiabilityFactModel>> GetAvaiabilityFacts(int machineId, string startDate, string EndDate);
    
    }
}
    