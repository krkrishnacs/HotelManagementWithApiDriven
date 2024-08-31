using EmployeeMangementAPI.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeMangementAPI.Repository
{
    public class RoleRepository
    {
        private readonly string _connectionString;
        public RoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Role> GetAllRoles()
        {
            var roles = new List<Role>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Roles", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new Role
                        {
                            RoleID = (int)reader["RoleID"],
                            RoleName = reader["RoleName"].ToString(),
                            RoleDescription = reader["RoleDescription"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            UpdatedAt = reader["UpdatedAt"] as DateTime?,
                            IsActive = (bool)reader["IsActive"]
                        });
                    }
                }
            }

            return roles;
        }

        public Role GetRoleById(int id)
        {
            Role role = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Roles WHERE RoleID = @RoleID", connection);
                command.Parameters.AddWithValue("@RoleID", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        role = new Role
                        {
                            RoleID = (int)reader["RoleID"],
                            RoleName = reader["RoleName"].ToString(),
                            RoleDescription = reader["RoleDescription"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            UpdatedAt = reader["UpdatedAt"] as DateTime?,
                            IsActive = (bool)reader["IsActive"]
                        };
                    }
                }
            }

            return role;
        }

        public void AddRole(Role role)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(
                    "INSERT INTO Roles (RoleName, RoleDescription, CreatedAt, IsActive) VALUES (@RoleName, @RoleDescription, @CreatedAt, @IsActive)",
                    connection);
                command.Parameters.AddWithValue("@RoleName", role.RoleName);
                command.Parameters.AddWithValue("@RoleDescription", role.RoleDescription);
                command.Parameters.AddWithValue("@CreatedAt", role.CreatedAt);
                command.Parameters.AddWithValue("@IsActive", role.IsActive);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateRole(Role role)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(
                    "UPDATE Roles SET RoleName = @RoleName, RoleDescription = @RoleDescription, UpdatedAt = @UpdatedAt, IsActive = @IsActive WHERE RoleID = @RoleID",
                    connection);
                command.Parameters.AddWithValue("@RoleID", role.RoleID);
                command.Parameters.AddWithValue("@RoleName", role.RoleName);
                command.Parameters.AddWithValue("@RoleDescription", role.RoleDescription);
                command.Parameters.AddWithValue("@UpdatedAt", role.UpdatedAt);
                command.Parameters.AddWithValue("@IsActive", role.IsActive);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteRole(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM Roles WHERE RoleID = @RoleID", connection);
                command.Parameters.AddWithValue("@RoleID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

