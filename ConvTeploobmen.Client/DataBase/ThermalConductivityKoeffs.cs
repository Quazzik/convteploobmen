using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvTeploobmen.Client.DataBase
{
    public class ThermalConductivityKoeffs
    {
        [Key]
        public string GasName { get; set; }
        public double koeff1 { get; set; }
        public double koeff2 { get; set; }
        public double koeff3 { get; set; }
    }
}
