﻿using human.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.human.data.dataseeder
{
    public static class Seeder
    {
        private static List<string> Firstnames = new List<string>()
        {
            "Audrey",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Jimi",
            "Mick",
            "Kate",
            "Charles",
            "Kate"
        };
        private static List<string> Lastnames = new List<string>()
        {
            "Hepburn",
            "Trump",
            "Presley",
            "Obama",
            "Winfrey",
            "Hendrix",
            "Jagger",
            "Winslet",
            "Windsor",
            "Middleton"

        };
        private static List<string> Domain = new List<string>()
        {
            "bbc.co.uk",
            "google.com",
            "theworld.ca",
            "something.com",
            "tesla.com",
            "nasa.org.us",
            "gov.us",
            "gov.gr",
            "gov.nl",
            "gov.ru"
        };
        private static List<string> FirstWord = new List<string>()
        {
            "The",
            "Two",
            "Several",
            "Fifteen",
            "A bunch of",
            "An army of",
            "A herd of"


        };
        private static List<string> SecondWord = new List<string>()
        {
            "Orange",
            "Purple",
            "Large",
            "Microscopic",
            "Green",
            "Transparent",
            "Rose Smelling",
            "Bitter"
        };
        private static List<string> ThirdWord = new List<string>()
        {
            "Buildings",
            "Cars",
            "Planets",
            "Houses",
            "Flowers",
            "Leopards"
        };
        private static string GeneratePublisherName()
        {
            string[] words = { "Blue", "Readable", "Flying", "Expensive", "Reflective", "Feathery", "Shiny", "Clean", "Brown Bagel", "Unlimited", "Green", "Bay Tree", "Field of Dreams", "Flying Comet", "Faster than a speeding bullet", "Heroic", "Static" };


            Random random = new Random();


            return $"The {words[random.Next(words.Length)]} Publishing Company";

        }
        public static void Seed()
        {


            using (var db = new DataContext())
            {
                //if (db.Authors.ToList().Count > 0) return;
                //if (db.Publishers.ToList().Count > 0) return;
                //if (db.Books.ToList().Count > 0) return;

                Random authorRandom = new Random();
                Random bookRandom = new Random();
                Random publisherRandom = new Random();

                var authors = new List<Author>();
                var books = new List<Book>();
                var publishers = new List<Publisher>();

                for (int x = 1; x < 250; x++)
                {
                    Author author = new Author();
                    author.Id = x;
                    author.FirstName = Firstnames[authorRandom.Next(Firstnames.Count)];
                    author.LastName = Lastnames[authorRandom.Next(Lastnames.Count)];
                    author.Email = $"{author.FirstName}.{author.LastName}@{Domain[authorRandom.Next(Domain.Count)]}".ToLower();
                    authors.Add(author);


                }
                db.Authors.AddRange(authors);


                for (int i = 1; i <= 100; i++)
                {
                    Publisher publisher = new Publisher();
                    publisher.Id = i;
                    publisher.Name = GeneratePublisherName();
                    publishers.Add(publisher);
                }
                db.Publishers.AddRange(publishers);




                for (int x = 1; x < 250; x++)
                {
                    Book book = new Book();
                    book.Id = x;
                    book.Title = $"{FirstWord[bookRandom.Next(FirstWord.Count)]} {SecondWord[bookRandom.Next(SecondWord.Count)]} {ThirdWord[bookRandom.Next(ThirdWord.Count)]}";
                    book.AuthorId = authors[authorRandom.Next(authors.Count)].Id;
                    book.PublisherId = publishers[publisherRandom.Next(publishers.Count)].Id;
                    book.ReleaseDate = DateTime.UtcNow; //postgres didn't like .Now ! need UtcNow
                    books.Add(book);
                }
                db.Books.AddRange(books);

                db.SaveChanges();
            }

        }
    }
}
