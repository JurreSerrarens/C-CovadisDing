namespace Covadis.Shared;

public class RideDisplay
{
    public int Id { get; set; }
    public double StartPosition { get; set; }
    public double EndPosition { get; set; }

    public string StartAddress { get; set; }
    public string EndAddress { get; set; }


    public string User { get; set; }
    public string Car { get; set; }

    public bool Active { get; set; }
}
