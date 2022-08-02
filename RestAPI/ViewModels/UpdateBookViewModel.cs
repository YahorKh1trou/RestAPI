using Data.Data.Models;

namespace RestAPI.ViewModels
{
    public class UpdateBookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patro { get; set; }
        public string Birthdate { get; set; }
        public string Bookname { get; set; }
        public int? Year { get; set; }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }
            return true;
        }

        public Book ToDomainBook(UpdateBookViewModel updateBook)
        {
            return new Book
            {
                Id = updateBook.Id,
                Name = updateBook.Name,
                Lastname = updateBook.Lastname,
                Patro = updateBook.Patro,
                Birthdate = DateTime.Parse(updateBook.Birthdate),
                Bookname = updateBook.Bookname,
                Year = updateBook.Year,
            };
        }
    }
}
