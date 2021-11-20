using System;
using System.Collections.Generic;

namespace GoProGPS
{
    public class Definitions
    {

        public class DevInfo
        {
            public int DeviceID { get; set; }       // Auto generated unique-ID for managing a large number of connect devices
            public string DeviceName { get; set; }  // Display name of the device
        }

        public class GpsInfo
        {
            public int Fix { get; set; }
            public DateTime Utc { get; set; }
            public string AltSys { get; set; }
            public Unit Unit { get; set; } = new();
            public Scal Scal { get; set; } = new();
            public List<PosVel> Pos_list { get; set; } = new();
            public double Dop { get; set; } = 9999;
        }

        public class Unit
        {
            public string Lat { get; set; }
            public string Lon { get; set; }
            public string Alt { get; set; }
            public string Spd2D { get; set; }
            public string Spd3D { get; set; }
        }

        public class Scal : PosVel { }

        public class PosVel
        {
            public double Lat { get; set; }
            public double Lon { get; set; }
            public double Alt { get; set; }
            public double Spd2D { get; set; }
            public double Spd3D { get; set; }
            public DateTime UtcOfSample { get; set; }
        }
    }
}
