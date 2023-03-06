namespace FrontToBack.Models.Demo
{
    public class BookGenre
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
