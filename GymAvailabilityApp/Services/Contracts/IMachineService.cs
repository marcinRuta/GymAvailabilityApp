
using GymAvailabilityApp.Entities;
using GymAvailabilityApp.Models;

namespace GymAvailabilityApp.Services.Contracts
{
    public interface IMachineService
    {
        Task<List<MachineModel>> GetMachines();
        Task<MachineModel> GetMachine(int id);
        Task<Machine> CreateMachine(MachineModel machine);
        Task<Machine> UpdateMachine(MachineModel machine);
        Task<Machine> DeleteMachine(int id);
        Task<List<GymRoomModel>> GetGymRooms();
        Task<GymRoom> CreateGymRoom(GymRoomModel gymRoom);
        Task<GymRoom> UpdateGymRoom(GymRoomModel gymRoom);
        Task<GymRoom> DeleteGymRoom(int id);
        Task<GymModel> GetGym(int id);
        Task<List<MachineAvaiabilityFactModel>> GetAvaiabilityFacts(int machineId, string startDate, string EndDate);

    
    }
}
    