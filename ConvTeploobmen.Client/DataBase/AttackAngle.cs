using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvTeploobmen.App.DataBase
{
    public class AttackAngle
    {
        [Key]
        public int Degree { get; set; }
        public double Value { get; set; }
    }
}
