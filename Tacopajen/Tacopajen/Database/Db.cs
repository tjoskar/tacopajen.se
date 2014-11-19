using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Tacopajen.Models;

namespace Tacopajen.Database
{
    public class Db
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public Db()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "mysql13.citynetwork.se";
            database = "107372-tacopaj";
            uid = "107372-zo70272";
            password = "hundiparis5";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<Recipe> GetAllRecipe()
        {
            OpenConnection();
            var sql = "Select * from Recipe";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            var list = new List<Recipe>();
            while (dataReader.Read())
            {
                var temp = new Recipe()
                {
                    Description = dataReader["Description"].ToString(),
                    Id = dataReader["id"].ToString(),
                    ImgUrl = dataReader["ImageUrl"].ToString(),
                    Name = dataReader["Name"].ToString()
                };
                list.Add(temp);
            }
            CloseConnection();
            return list;
        }

        public Recipe GetRecipe(Guid guid)
        {
            OpenConnection();
            var sql = "Select * from Recipe Where id ="+guid;
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            var recipe = new Recipe()
            {
                Description = dataReader["Description"].ToString(),
                Id = dataReader["id"].ToString(),
                ImgUrl = dataReader["ImageUrl"].ToString(),
                Name = dataReader["Name"].ToString()
            };
            CloseConnection();
            return recipe;
        }

        public List<Ingredient> GetAllIngredientsfor(Guid guid)
        {
            OpenConnection();
            var sql = "Select * from Ingredients Where Recipe ="+guid;
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            var list = new List<Ingredient>();
            while (dataReader.Read())
            {
                list.Add(new Ingredient()
                {
                    IngredientName = dataReader["Name"].ToString(),
                    Quantity = dataReader["Quantity"].ToString()
                }
                    );
            }
            CloseConnection();
            return list;
        }
    }
}