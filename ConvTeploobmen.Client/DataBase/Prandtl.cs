using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvTeploobmen.Client.DataBase;

public class Prandtl
{
    [Key]
    public double Temperature { get; set; }
    public double Value { get; set; }
}
