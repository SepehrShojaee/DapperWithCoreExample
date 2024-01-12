using Dapper;
using DapperWithCoreExample.Models;
using System.Data.SqlClient;

namespace DapperWithCoreExample.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> GetAllPerson();
        Person GetPersonById(int id);
        void RemovePerson(Person person);
        void AddPerson(Person person);
        void UpdatePerson(Person person);
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly ICommandText _commandText;
        private readonly string _connectionString;

        public PersonRepository(IConfiguration configuration, ICommandText commandText)
        {
            _commandText = commandText;
            _connectionString = configuration.GetConnectionString("Dapper");
        }
        public void AddPerson(Person person)
        {
            ExecuteCommand(_connectionString,
                conn => conn.Query<Person>(_commandText.AddPerson,
                new
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Phone = person.Phone,
                    ZipCode = person.ZipCode,
                    Address = person.Adresse,
                    CreateDate = person.CreateDate,
                    IsDelete = person.IsDelete
                }));
        }

        public List<Person> GetAllPerson()
        {
            var query = ExecuteCommand(_connectionString, conn => conn.Query<Person>(_commandText.GetAllPerson)).ToList();
            return query;
        }

        public Person GetPersonById(int id)
        {
            var query = ExecuteCommand<Person>(_connectionString, conn => conn.Query<Person>(_commandText.GetPersonByID, new { Id = id }).SingleOrDefault());
            return query;
        }

        public void RemovePerson(Person person)
        {
            ExecuteCommand(_connectionString, conn =>
            {
                var query = conn.Query<Person>(_commandText.RemovePerson,
                new { Id = person.Id });
            });

        }

        public void UpdatePerson(Person person)
        {
            ExecuteCommand(_connectionString,
                conn => conn.Query<Person>(_commandText.UpdatePerson,
                new
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Phone = person.Phone,
                    ZipCode = person.ZipCode,
                    Address = person.Adresse,
                    CreateDate = person.CreateDate,
                    IsDelete = person.IsDelete,
                    Id = person.Id
                }));
        }
        #region Helpers
        private void ExecuteCommand(string connection, Action<SqlConnection> task)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                task(conn);
            }

        }

        private T ExecuteCommand<T>(string connection, Func<SqlConnection, T> task)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                return task(conn);
            }

        }
        #endregion
    }
}
