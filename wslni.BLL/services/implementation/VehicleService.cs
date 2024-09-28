using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wslni.BLL.Helper;
using wslni.BLL.ModelVM;
using wslni.BLL.services.interfaces;
using wslni.DAL.Entities;
using wslni.DAL.Repo.interfaces;

namespace wslni.BLL.services.implementation
{
    public class VehicleService: IVehicleService
    {
        private readonly IVehicleRepo _vehicleRepo;

        public VehicleService(IVehicleRepo vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        public async Task AddVehicleAsync(VehicleVM vehicleVM, string userId)
        {
            string vehiclePictureFileName = UploadImg.UploadFile("Vehicles", vehicleVM.VehiclePicture);
            var vehicle = new Vehicle
            {
                UserId = userId, // Assuming UserId is int
                CarModel = vehicleVM.CarModel,
                CarColor = vehicleVM.CarColor,
                LicensePlate = vehicleVM.LicensePlate,
                CreatedAt = DateTime.Now,
                VehiclePictureUrl = $"/Imgs/Vehicles/{vehiclePictureFileName}", // Set the picture URL
                // Handle VehiclePictureUrl logic if needed
            };

            await _vehicleRepo.AddVehicleAsync(vehicle);
        }

        public async Task<Vehicle> GetVehicleByUserIdAsync(string userId)
        {
            return await _vehicleRepo.GetVehicleByUserIdAsync(userId);
        }
    }
}
