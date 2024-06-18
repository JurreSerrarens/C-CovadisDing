namespace Covadis.Shared;

public class ReservationDto
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public virtual CarDto? Car { get; set; }
    public virtual UserDto? User { get; set; }
}