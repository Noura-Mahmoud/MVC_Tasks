using System.Collections.Generic;

namespace DotNetFiveCarWebAppCore.Models
{
    public class CarList
    {
        public static List<Car> Cars = new List<Car>()
        {
            new Car(){Num = 1, Color = "red ", Model="2012 ", Manfacture="ss"},
            new Car(){Num = 2, Color = "green ", Model="2018 ", Manfacture="nn"},
            new Car(){Num = 3, Color = "yellow ", Model="2017 ", Manfacture="ll"},
            new Car(){Num = 4, Color = "brown ", Model="2019 ", Manfacture="oo"},
            new Car(){Num = 5, Color = "purple ", Model="2020 ", Manfacture="qq"}
        };
    }
}
