namespace BranchService.Data.Models.Branch;

public class BranchUserConnection
{
    public int Id { get; set; }
    
    public Branch Branch { get; set; }

    public string UserId { get; set; }
}