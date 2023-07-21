using GymAvailabilityApp.Data;
using GymAvailabilityApp.Entities;
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

        public async Task<GymRoom> CreateGymRoom(GymRoomModel gymRoom)
        {
            var newGymRoom = new GymRoom
            {
                Name = gymRoom.Name,
                Floor = gymRoom.Floor,
                RoomFileLink = gymRoom.RoomFileLink
            };
            var result = await this.gymAvaiabilityDbContext.GymRooms.AddAsync(newGymRoom);
            await this.gymAvaiabilityDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<GymRoom> DeleteGymRoom(int id)
        {
            var gymRoomToDelete = await this.gymAvaiabilityDbContext.GymRooms.FirstOrDefaultAsync(gymRoom => gymRoom.Id == id);
            if (gymRoomToDelete != null)
            {
                this.gymAvaiabilityDbContext.GymRooms.Remove(gymRoomToDelete);
                await this.gymAvaiabilityDbContext.SaveChangesAsync();
                return gymRoomToDelete;
            }
            return null;

        }
        public async Task<GymRoom> UpdateGymRoom(GymRoomModel gymRoom)
        {
            // write a code to update gymRoom object in database 
            var gymRoomToUpdate = await this.gymAvaiabilityDbContext.GymRooms.FirstOrDefaultAsync(_gymRoom => _gymRoom.Id == gymRoom.Id);
            if (gymRoomToUpdate != null)
            {
                gymRoomToUpdate.GymId = '1';
                gymRoomToUpdate.Name = gymRoom.Name;
                gymRoomToUpdate.Floor = gymRoom.Floor;
                gymRoomToUpdate.RoomFileLink = gymRoom.RoomFileLink;
                await this.gymAvaiabilityDbContext.SaveChangesAsync();
                return gymRoomToUpdate;
            }
            return null;

        }

        public async Task<List<MachineAvaiabilityFactModel>> GetAvaiabilityFacts(int machineId, string startDate, string endDate)
        {



            var newStartDate = DateTime.Parse(startDate);
            var newEndDate = DateTime.Parse(endDate);
            var returnedMachineAvaiabilityFacts = await (from machineAvaiabilityFact in this.gymAvaiabilityDbContext.AvaiabilityReportFactSt
                                                         where machineAvaiabilityFact.MachineId == machineId
                                                         && machineAvaiabilityFact.Date >= newStartDate
                                                         && machineAvaiabilityFact.Date <= newEndDate
                                                         select new MachineAvaiabilityFactModel
                                                         {
                                                             Id = machineAvaiabilityFact.Id,
                                                             Occupancy = machineAvaiabilityFact.Occupancy,
                                                             Timestamp = machineAvaiabilityFact.Timestamp,
                                                             MachineId = machineAvaiabilityFact.MachineId,
                                                             GymRoomId = machineAvaiabilityFact.GymRoomId,
                                                             Date = machineAvaiabilityFact.Date
                                                         }).ToListAsync();

            return returnedMachineAvaiabilityFacts;


        }

        public async Task<GymModel> GetGym(int id)
        {
            return await (from gym in this.gymAvaiabilityDbContext.Gyms
                          where gym.Id == id
                          select new GymModel
                          {
                              Id = gym.Id,
                              Name = gym.Name
                          }).SingleOrDefaultAsync();
        }

        public async Task<List<GymRoomModel>> GetGymRooms()
        {
            var returnedGymFloors = await (from gymRoom in this.gymAvaiabilityDbContext.GymRooms
                                           select new GymRoomModel
                                           {
                                               Id = gymRoom.Id,
                                               Name = gymRoom.Name,
                                               Floor = gymRoom.Floor,
                                               RoomFileLink = gymRoom.RoomFileLink
                                           }).ToListAsync();
            if (returnedGymFloors.Any())
            {
                foreach (var gymFloor in returnedGymFloors)
                {
                    gymFloor.GymRoomMachines = await (from machinePlacement in this.gymAvaiabilityDbContext.MachinePlacements
                                                      where machinePlacement.GymRoomId == gymFloor.Id
                                                      join machine in this.gymAvaiabilityDbContext.Machines
                                                        on machinePlacement.MachineId equals machine.Id
                                                      select new MachineModel
                                                      {
                                                          Id = machine.Id,
                                                          Name = machine.Name,
                                                          ImageFileLink = machine.ImageFileLink,
                                                          Description = machine.Description,
                                                          DeviceEUI = machine.DeviceEUI
                                                      }).ToListAsync();

                }

            }
            return returnedGymFloors;

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
            if (returnedAvaiabilityReport == null)
            {
                returnedMachine.IsOccupied = false;
                return returnedMachine;
            }
            returnedMachine.IsOccupied = returnedAvaiabilityReport.CurrentState == "True";

            return returnedMachine;
        }

        public async Task<List<MachineModel>> GetMachines()
        {
            var machines = await (from machine in this.gymAvaiabilityDbContext.Machines
                                  join machinePlacement in this.gymAvaiabilityDbContext.MachinePlacements
                                    on machine.Id equals machinePlacement.MachineId
                                  join gymRoom in this.gymAvaiabilityDbContext.GymRooms
                                    on machinePlacement.GymRoomId equals gymRoom.Id

                                  select new MachineModel
                                  {
                                      Id = machine.Id,
                                      Name = machine.Name,
                                      ImageFileLink = machine.ImageFileLink,
                                      Description = machine.Description,
                                      DeviceEUI = machine.DeviceEUI,
                                      GymRoomId = gymRoom.Id,
                                      GymRoomName = gymRoom.Name,
                                      MachinePlacementDescription = machinePlacement.Description,

                                  }).ToListAsync();
            if (machines != null)
            {
                return machines;
            }
            else
            {
                return new List<MachineModel> { };
            }
        }



        public async Task<Machine> UpdateMachine(MachineModel machine)
        {
            var machineToUpdate = this.gymAvaiabilityDbContext.Machines.FirstOrDefault(_machine => _machine.Id == machine.Id);
            var machinePlacement = this.gymAvaiabilityDbContext.MachinePlacements.FirstOrDefault(_machinePlacement => _machinePlacement.MachineId == machine.Id);
            if (machineToUpdate != null)
            {
                machineToUpdate.DeviceEUI = machine.DeviceEUI;
                machineToUpdate.Name = machine.Name;
                machineToUpdate.Description = machine.Description;
                machineToUpdate.ImageFileLink = machine.ImageFileLink;
                if (machinePlacement == null)
                {
                    var newMachinePlacement = new MachinePlacement
                    {
                        GymRoomId = machine.GymRoomId,
                        MachineId = machine.Id,
                        Description = machine.MachinePlacementDescription
                    };

                }
                else
                {
                    machinePlacement.GymRoomId = machine.GymRoomId;
                    machinePlacement.Description = machine.MachinePlacementDescription;
                }
                await this.gymAvaiabilityDbContext.SaveChangesAsync();
                return machineToUpdate;
            }
            return null;
        }
        public async Task<Machine> DeleteMachine(int id)
        {
            var machineToBeDeleted = this.gymAvaiabilityDbContext.Machines.FirstOrDefault(_machine => _machine.Id == id);
            var machinePlacementToBeDeleted = this.gymAvaiabilityDbContext.MachinePlacements.FirstOrDefault(_machinePlacement => _machinePlacement.MachineId == machineToBeDeleted.Id);

            if (machineToBeDeleted != null)
            {

                this.gymAvaiabilityDbContext.Machines.Remove(machineToBeDeleted);
                if (machinePlacementToBeDeleted !=null)
                {
                    this.gymAvaiabilityDbContext.MachinePlacements.Remove(machinePlacementToBeDeleted);
                }
                await this.gymAvaiabilityDbContext.SaveChangesAsync();
                return machineToBeDeleted;
            }
            return null;


        }

        public async Task<Machine> CreateMachine(MachineModel machine)
        {
            var newMachine = new Machine
            {
                Description = machine.Description,
                DeviceEUI = machine.DeviceEUI,
                Name = machine.Name

            };
            var result = await this.gymAvaiabilityDbContext.Machines.AddAsync(newMachine);
            await this.gymAvaiabilityDbContext.SaveChangesAsync();

            if (machine.GymRoomId != null)
            {
                var newMachinePlacement = new MachinePlacement
                {
                    GymRoomId = machine.GymRoomId,
                    MachineId = result.Entity.Id,
                    Description = machine.MachinePlacementDescription
                };
                await this.gymAvaiabilityDbContext.MachinePlacements.AddAsync(newMachinePlacement);

            }
            await this.gymAvaiabilityDbContext.SaveChangesAsync();
            return result.Entity;

        }
    }

}
