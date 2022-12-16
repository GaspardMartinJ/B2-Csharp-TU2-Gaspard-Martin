using ProjetPourTU.Services;
using System;

namespace ProjetPourTU {
    class Program {
        static void Main(string[] args) {
            var srv = new VehiculeService();
            srv.AddVehicule(null);
        }
    }
}
