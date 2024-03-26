using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public class ReaderRepository
    {
        private readonly List<ReaderModel> _readers;

        public ReaderRepository()
        {
            _readers = new List<ReaderModel>
        {
            new ReaderModel { Id = 1, Name = "Alice Smith", Email = "alice@example.com", Address = "123 Main St, City", BirthDate = new DateTime(1990, 5, 15) },
            new ReaderModel { Id = 2, Name = "Bob Johnson", Email = "bob@example.com", Address = "456 Elm St, Town", BirthDate = new DateTime(1985, 8, 20) },
            new ReaderModel { Id = 3, Name = "Charlie Brown", Email = "charlie@example.com", Address = "789 Oak St, Village", BirthDate = new DateTime(1993, 11, 10) },
            new ReaderModel { Id = 4, Name = "David Lee", Email = "david@example.com", Address = "321 Pine St, City", BirthDate = new DateTime(1982, 3, 25) },
            new ReaderModel { Id = 5, Name = "Emma Davis", Email = "emma@example.com", Address = "654 Maple St, Town", BirthDate = new DateTime(1991, 7, 5) },
            new ReaderModel { Id = 6, Name = "Frank Wilson", Email = "frank@example.com", Address = "987 Cedar St, Village", BirthDate = new DateTime(1988, 9, 15) },
            new ReaderModel { Id = 7, Name = "Grace Martinez", Email = "grace@example.com", Address = "135 Walnut St, City", BirthDate = new DateTime(1994, 12, 20) },
            new ReaderModel { Id = 8, Name = "Hannah Thompson", Email = "hannah@example.com", Address = "246 Birch St, Town", BirthDate = new DateTime(1987, 2, 10) },
            new ReaderModel { Id = 9, Name = "Isaac Rodriguez", Email = "isaac@example.com", Address = "579 Cherry St, Village", BirthDate = new DateTime(1992, 6, 30) },
            new ReaderModel { Id = 10, Name = "Jessica White", Email = "jessica@example.com", Address = "864 Pineapple St, City", BirthDate = new DateTime(1983, 4, 15) },
            new ReaderModel { Id = 11, Name = "Kevin Adams", Email = "kevin@example.com", Address = "369 Banana St, Town", BirthDate = new DateTime(1995, 10, 5) },
            new ReaderModel { Id = 12, Name = "Laura Brown", Email = "laura@example.com", Address = "258 Orange St, Village", BirthDate = new DateTime(1986, 1, 20) },
            new ReaderModel { Id = 13, Name = "Michael Clark", Email = "michael@example.com", Address = "741 Lemon St, City", BirthDate = new DateTime(1996, 8, 10) },
            new ReaderModel { Id = 14, Name = "Nancy Evans", Email = "nancy@example.com", Address = "852 Lime St, Town", BirthDate = new DateTime(1984, 5, 25) },
            new ReaderModel { Id = 15, Name = "Olivia Garcia", Email = "olivia@example.com", Address = "963 Grape St, Village", BirthDate = new DateTime(1997, 3, 15) },
            new ReaderModel { Id = 16, Name = "Peter Harris", Email = "peter@example.com", Address = "174 Watermelon St, City", BirthDate = new DateTime(1989, 12, 5) },
            new ReaderModel { Id = 17, Name = "Quinn Jackson", Email = "quinn@example.com", Address = "357 Blueberry St, Town", BirthDate = new DateTime(1998, 1, 20) },
            new ReaderModel { Id = 18, Name = "Rachel King", Email = "rachel@example.com", Address = "486 Raspberry St, Village", BirthDate = new DateTime(1981, 7, 10) },
            new ReaderModel { Id = 19, Name = "Samuel Lopez", Email = "samuel@example.com", Address = "579 Strawberry St, City", BirthDate = new DateTime(1990, 4, 25) },
            new ReaderModel { Id = 20, Name = "Taylor Moore", Email = "taylor@example.com", Address = "684 Blackberry St, Town", BirthDate = new DateTime(1980, 9, 15) }
        };
        }

        public IEnumerable<ReaderModel> GetAllReaders()
        {
            return _readers.ToList();
        }

        public ReaderModel GetReaderById(int id)
        {
            return _readers.FirstOrDefault(r => r.Id == id);
        }

        public void AddReader(ReaderModel reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            reader.Id = _readers.Any() ? _readers.Max(r => r.Id) + 1 : 1;
            _readers.Add(reader);
        }

        public void UpdateReader(ReaderModel reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            var existingReader = _readers.FirstOrDefault(r => r.Id == reader.Id);
            if (existingReader != null)
            {
                existingReader.Name = reader.Name;
                existingReader.Email = reader.Email;
                existingReader.Address = reader.Address;
                existingReader.BirthDate = reader.BirthDate;
            }
        }

        public void DeleteReader(int id)
        {
            var readerToDelete = _readers.FirstOrDefault(r => r.Id == id);
            if (readerToDelete != null)
                _readers.Remove(readerToDelete);
        }
    }
}
