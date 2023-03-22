namespace QCinema.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Movie Movie { get; set; }
        public double Amount    { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
