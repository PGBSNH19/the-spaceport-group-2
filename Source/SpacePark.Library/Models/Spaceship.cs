﻿using SpacePark.Library.Context;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpacePark.Library.Models
{
    public class Spaceship
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public int VisitorID { get; set; }
        public Visitor Visitor { get; set; }
        public ParkingLot ParkingLot { get; set;}
        public int ParkingLotID { get; set; }

        public static Spaceship CreateShip(SpaceShipArray spaceShipArray)
        {
            var shipsResult = spaceShipArray.Spaceships[0];
            Spaceship Spaceship = new Spaceship
            {
                Name = shipsResult.Name
            };

            return Spaceship;
        }
    }
}