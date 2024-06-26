﻿using BookTaxi.CustomExceptions;
using BookTaxi.Data;
using BookTaxi.Enums;
using BookTaxi.IServices;
using BookTaxi.Models;
using BookTaxi.Models.Request;

namespace BookTaxi.Services
{
    public class StartRideService: IStartRideService
    {
        private readonly EF_DataContext _context;
        public StartRideService(EF_DataContext context)
        {
            _context = context;
        }
        public void StartRide(StartRideRequest startRideDetails, string email, string userType)
        {
            // Convert userType string to UserRole enum
            if (!Enum.TryParse<UserRole>(userType, out UserRole userRole))
            {
                // Handle invalid userType
                throw new ArgumentException("Invalid user type.", nameof(userType));
            }

            Ride? ride = _context.Rides.FirstOrDefault(r =>r.RideId==startRideDetails.RideId && r.OTP==startRideDetails.OTP && r.RideStatus==RideStatus.YetToStart);
            if (ride == null)
            {
                throw new CanNotStartRideException();
            }
            User? driver = _context.Users.FirstOrDefault(v => v.Email == email && v.UserRole == userRole);
            if (driver == null)
            {
                throw new CanNotStartRideException();
            }
            Vehicle? vehicle = _context.Vehicles.FirstOrDefault(v => v.UserId == driver.UserId);
            if (vehicle==null || vehicle.VehicleId!=ride.VehicleId)
            {
                throw new CanNotStartRideException();
            }
            ride.RideStatus = RideStatus.InProgress;
            _context.SaveChanges();if (driver == null)
            {
                throw new CanNotStartRideException();
            }

        }
    }
}
