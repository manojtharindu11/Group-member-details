using MySql.Data.MySqlClient;

namespace Groupmemberdetails.Models
{
    public class DetailsRepository
    {
        private static string connectionString = "server=localhost;user=root;database=groupdetails;port=3306;password=manoj22561";

        public static List<Details> GetDetails()
        {
            List<Details> details = new List<Details>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM members", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Details detail = new Details();
                    detail.IndexNo = Convert.ToInt32(reader["Index"]);
                    detail.Name = reader["Name"].ToString();
                    detail.Email = reader["Email"].ToString();
                    detail.Age = Convert.ToInt32(reader["age"]);

                    details.Add(detail);
                }

                reader.Close();
            }

            return details;
        }

        public static void UpdateDetails(int index, Details details)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand updateCmd = new MySqlCommand("UPDATE members SET Name = @Name, Email = @Email, Age = @Age WHERE `Index` = @Index", con);

                updateCmd.Parameters.AddWithValue("@Name", details.Name);
                updateCmd.Parameters.AddWithValue("@Email", details.Email);
                updateCmd.Parameters.AddWithValue("@Age", details.Age);
                updateCmd.Parameters.AddWithValue("@Index", details.IndexNo);


                int rowsUpdated = updateCmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsUpdated} row(s) updated.");
            }
        }

        public static Details? GetDetailsByIndex(int index)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM members WHERE `Index` = @Index", con);
                cmd.Parameters.AddWithValue("@Index", index);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Details
                    {
                        IndexNo = Convert.ToInt32(reader["Index"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Age = Convert.ToInt32(reader["age"])
                    };
                }

                reader.Close();
            }

            return null;
        }

        public static void DeleteMemberByIndex(int index)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand deleteCmd = new MySqlCommand("DELETE FROM members WHERE `Index` = @IndexToDelete", con);
                deleteCmd.Parameters.AddWithValue("@IndexToDelete", index);

                int rowsDeleted = deleteCmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsDeleted} row(s) deleted.");
            }
        }

        public static void AddMember(Details details)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand insertCmd = new MySqlCommand("INSERT INTO members (Name, Email, Age) VALUES (@Name, @Email, @Age)", con);

                insertCmd.Parameters.AddWithValue("@Name", details.Name);
                insertCmd.Parameters.AddWithValue("@Email", details.Email);
                insertCmd.Parameters.AddWithValue("@Age", details.Age);

                insertCmd.ExecuteNonQuery();
            }
        }
    }
}
