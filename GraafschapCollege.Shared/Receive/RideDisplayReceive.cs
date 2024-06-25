namespace Covadis.Shared.Receive;

public class RideDisplayReceive
{
    public int id { get; set; }
    public double startPosition { get; set; }
    public double endPosition { get; set; }

    public string startAddress { get; set; }
    public string endAddress { get; set; }

    public int user {  get; set; }
    public int car { get; set; }

    public bool active { get; set; }
}
