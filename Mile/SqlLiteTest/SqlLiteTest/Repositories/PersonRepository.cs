using SqlLiteTest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace SqlLiteTest.Repositories
{
    public class PersonRepository
    {
        public string StatusMessage { get; set; }

        private readonly SQLiteAsyncConnection _connection;

        public PersonRepository(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);

            _connection.CreateTableAsync<People>();
        }

        public async Task AddNewPerson(string name)
        {
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                var result = await _connection.InsertAsync(new People { Name = name });
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public async Task<List<People>> GetAllPeople()
        {
            try
            {
                return await _connection.Table<People>()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed: {e.Message}";
            }
            return new List<People>();
        }
    }
}
