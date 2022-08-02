﻿using DomainModels = Data.Data.Models;
namespace RestAPI.Models
{
    public class Book
    {
        public Book(DomainModels.Book domainBook)
        {
            Id = domainBook.Id;
            Name = domainBook.Name;
            Lastname = domainBook.Lastname;
            Patro = domainBook.Patro;
            Birthdate = domainBook.Birthdate.ToString();
            Bookname = domainBook.Bookname;
            Year = domainBook.Year;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patro { get; set; }
        public string Birthdate { get; set; }
        public string Bookname { get; set; }
        public int? Year { get; set; }
    }
}