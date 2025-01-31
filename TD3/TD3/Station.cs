﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Position
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Availabilities
    {
        public int bikes { get; set; }
        public int stands { get; set; }
        public int mechanicalBikes { get; set; }
        public int electricalBikes { get; set; }
        public int electricalInternalBatteryBikes { get; set; }
        public int electricalRemovableBatteryBikes { get; set; }
    }

    public class TotalStands
    {
        public Availabilities availabilities { get; set; }
        public int capacity { get; set; }
    }

    public class MainStands
    {
        public Availabilities availabilities { get; set; }
        public int capacity { get; set; }
    }

    public class Station
    {
        public int number { get; set; }
        public string contractName { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Position position { get; set; }
        public bool banking { get; set; }
        public bool bonus { get; set; }
        public string status { get; set; }
        public DateTime lastUpdate { get; set; }
        public bool connected { get; set; }
        public bool overflow { get; set; }
        public object shape { get; set; }
        public TotalStands totalStands { get; set; }
        public MainStands mainStands { get; set; }
        public object overflowStands { get; set; }

        public override string ToString()
        {
            //return all attributs of the object
            return @"{
                number: " + number + @",
                contractName: " + contractName + @",
                name: " + name + @",
                address: " + address + @",
                position: " + position.latitude + " - " + position.longitude + @",
                banking: " + banking + @",
                bonus: " + bonus + @",
                status: " + status + @",
                lastUpdate: " + lastUpdate + @",
                connected: " + connected + @",
                overflow: " + overflow + @",
                shape: " + shape + @",
                totalStands: " + totalStands + @",
                mainStands: " + mainStands + @",
                overflowStands: " + overflowStands + @"
            }";
        }
    }
}
