namespace apbd_tut6.Models;

public class Visit
{
    public DateTime DateOfVisit { get; set; }
    public Animal Animal { get; set; }
    public String description { get; set; }
    public int Price { get; set; }
}