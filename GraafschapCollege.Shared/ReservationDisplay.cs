namespace Covadis.Shared;

public class ReservationDisplay
{
    public int Id { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public virtual string Car { get; set; }
    public virtual string User { get; set; }
}