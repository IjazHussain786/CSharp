using System.Collections.Generic;
using System;
using HotelBookingSystem.Interfaces;

namespace HotelBookingSystem.Models
{
    public class Venue : IDbEntity
    {
        private string name = string.Empty;
        private string address;
        
        public Venue(string name, string address, string description, IUser owner)
        {
            this.Name = name;
            this.Address = address;
            this.Description = description;
            this.Owner = owner;
        }
        
        public int Id { get; set; }
        
        public string Name
        {
            get 
            { 
                return this.name; 
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format("The venue name cannot be empty."));
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException(string.Format("The venue name must be at least 3 symbols long."));
                }

                this.name = value;
            }
        }

        public string Address
        {
            get 
            { 
                return this.address; 
            }
            
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format("The venue address cannot be empty."));
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException(string.Format("The venue address must be at least 3 symbols long."));
                }

                this.address = value;
            }
        }

        public string Description { get; set; }
        public IUser Owner { get; set; }
        public ICollection<Room> Rooms { get; private set; }
    }
}
