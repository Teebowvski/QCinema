namespace QCinema.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MovieId { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Order order  { get; set; }
    }
}
