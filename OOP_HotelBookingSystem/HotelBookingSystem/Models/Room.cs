using HotelBookingSystem.Interfaces;
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Models
{
    public class Room : IDbEntity
    {
        private int placesCount;
        private decimal pricePerDay;

        public Room(int placesCount, decimal pricePerDay)
        {
            this.PlacesCount = placesCount;
            this.PricePerDay = pricePerDay;
            this.Bookings = new List<Booking>();
            this.AvailableDates = new List<AvailableDate>();
        }

        public int Id { get; set; }

        public int PlacesCount
        {
            get
            {
                return this.placesCount;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The places must not be less than 0.");
                }

                this.placesCount = value;
            }
        }

        public decimal PricePerDay
        {
            get 
            { 
                return this.pricePerDay; 
            }
            
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price per day must not be less than 0.");
                }

                this.pricePerDay = value;
            }
        }

        public ICollection<AvailableDate> AvailableDates { get; protected set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}