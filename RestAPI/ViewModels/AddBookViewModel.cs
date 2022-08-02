using Data.Data.Models;

namespace RestAPI.ViewModels
{
    public class AddBookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patro { get; set; }
        public string Birthdate { get; set; }
        public string Bookname { get; set; }
        public int? Year { get; set; }
        public int Counter { get; set; }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }
            return true;
        }

        public Book ToDomainBook(AddBookViewModel addBook)
        {
            return new Book
            {
                Name = addBook.Name,
                Lastname = addBook.Lastname,
                Patro = addBook.Patro,
                Birthdate = DateTime.Parse(addBook.Birthdate),
                Bookname = addBook.Bookname,
                Year = addBook.Year,
            };
        }
    }
}
