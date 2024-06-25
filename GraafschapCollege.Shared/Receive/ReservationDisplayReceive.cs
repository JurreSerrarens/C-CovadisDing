namespace Covadis.Shared.Receive;

public class ReservationDisplayReceive
{
    public int id { get; set; }
    public DateTime from { get; set; }
    public DateTime to { get; set; }

    public virtual string car { get; set; }
    public virtual string user { get; set; }
}