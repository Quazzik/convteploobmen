using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvTeploobmen.Client.DataBase;

public class Gas
{
    [Key]
    public string Name { get; set; }
    public double KinematicViscosity { get; set; }
}
