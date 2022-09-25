namespace BookStoreDAL.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableCopies { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}