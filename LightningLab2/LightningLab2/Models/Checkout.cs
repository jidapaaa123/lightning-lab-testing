namespace LightningLab2.Models;

public class Checkout
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string BookId { get; set; } = string.Empty;
    public DateTime CheckoutDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
