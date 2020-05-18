﻿using System;
using System.Text.RegularExpressions;

namespace Store
{
    public class Book
    {
        public int Id { get; }

        public string Isbn { get; }

        public string Author { get; }

        public string Title { get; }

        public string Description { get; }

        public decimal Price { get; }

        public Book(int id, string isbn, string author, string title, string description, decimal price)
        {
            Id = id;
            Isbn = isbn;
            Author = author;
            Title = title;
            Description = description;
            Price = price;
        }

        internal static bool IsIsbnValid(string isbn)
        {
            if (isbn == null)
                return false;

            var normalizedIsbn = NormalizeIsbn(isbn);

            return Regex.IsMatch(normalizedIsbn, "^ISBN\\d{10}(\\d{3})?$");
        }

        internal static string NormalizeIsbn(string isbn)
        {
            if (isbn == null)
                throw new ArgumentNullException(nameof(isbn));

            return isbn.Replace("-", "")
                       .Replace(" ", "")
                       .ToUpper();
        }
    }
}
