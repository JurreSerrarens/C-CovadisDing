namespace Covadis.Shared;

public class RideDto
{
    public int Id { get; set; }
    public double StartPosition { get; set; }
    public double EndPosition { get; set; }

    public string StartAddress { get; set; }
    public string EndAddress { get; set; }


    public int User {  get; set; }
    public int Car { get; set; }

    public bool Active { get; set; }
}
