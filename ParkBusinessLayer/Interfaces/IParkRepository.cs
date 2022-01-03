using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBusinessLayer.Interfaces {
    public interface IParkRepository {
        void VoegParkToe(Park p);
        void UpdatePark(Park p);
        Park GeefPark(string id);
    }
}
