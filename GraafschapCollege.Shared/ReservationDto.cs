﻿namespace Covadis.Shared;

public class ReservationDto
{
    public int Id { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public virtual int Car { get; set; }
    public virtual int User { get; set; }
}