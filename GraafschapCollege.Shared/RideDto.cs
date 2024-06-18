namespace Covadis.Shared;

public class RideDto
{
    public double StartPosition { get; set; }
    public double EndPosition { get; set; }
    public string Destination { get; set; }

    public bool Active { get; set; }
}
