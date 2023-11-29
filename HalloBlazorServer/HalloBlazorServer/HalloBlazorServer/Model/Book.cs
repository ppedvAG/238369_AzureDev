namespace HalloBlazorServer.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Subtile { get; set; } = string.Empty;
        public int PageCount { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual ICollection<Author> Authors { get; set; } = new HashSet<Author>();
    }
}
