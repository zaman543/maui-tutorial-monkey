using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;

namespace MonkeyFinder.Model;

public class Monkey
{
    //json2csharp website
    //edit -> paste special -> json as classes 
    //be careful about types and double check to make sure they are correct when using automated conversions
    //error w method 2 - float instead of double
    public string Name { get; set; }
    public string Location { get; set; }
    public string Details { get; set; }
    public string Image { get; set; }
    public int Population { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}