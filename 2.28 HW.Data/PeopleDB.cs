using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace _2._28_HW.Data
{
    public class PeopleDB
    {
        private readonly string _connectionString;

        public PeopleDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetPeople()
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM People ORDER BY LastName DESC";
            connection.Open();

            var reader = cmd.ExecuteReader();
            List<Person> people = new();

            while(reader.Read())
            {
                people.Add(new()
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }

            return people;
        }

        public void AddPeople(Person p)
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO People (FirstName, LastName, Age) " +
                              "VALUES (@first, @last, @age)";
            cmd.Parameters.AddWithValue("@first", p.FirstName);
            cmd.Parameters.AddWithValue("@last", p.LastName);
            cmd.Parameters.AddWithValue("@age", p.Age);
            connection.Open();

            cmd.ExecuteNonQuery();
        }

        public void AddMany(List<Person> ppl)
        {
            foreach(Person p in ppl)
            {
                if (p.FirstName == null && p.LastName == null && p.Age.ToString() == null)
                {
                    return;
                }
                AddPeople(p);
               
            }
           
        }
    }
}
