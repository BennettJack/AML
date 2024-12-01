namespace BranchService.Data.Models.Branch;

public class BusinessHours
{
    public int BusinessHoursId { get; set;}
    public Branch Branch { get; set; }
    public int Day { get; private set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }


    public void SetDay(int day)
    {
        if (day ! < 6)
        {
            Day = day;
        }
    }
}