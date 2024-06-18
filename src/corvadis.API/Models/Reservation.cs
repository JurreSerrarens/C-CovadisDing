namespace Covadis.API.Models;

public class Reservation
{
    public int Id { get; set; }

    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public virtual Car? Car { get; set; }
    public virtual User? User { get; set; }
}

