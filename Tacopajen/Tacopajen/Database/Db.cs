using System;
using System.Collections.Generic;
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
            var cmd = new MySqlCommand(sql, connection);
            var dataReader = cmd.ExecuteReader();
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

        public List<Comment> GetCommentsByRecipe(Guid recipeGuid)
        {
            OpenConnection();
            var list = new List<Comment>();
            var sql = "Select * from Comments Where recipe ='"+ recipeGuid +"'";
            var cmd = new MySqlCommand(sql, connection);
            var dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                var temp = new Comment()
                {
                    Text = dataReader["Comment"].ToString(),
                    Name = dataReader["Name"].ToString(),
                    Score = Convert.ToInt32(dataReader["Score"].ToString()),
                    RecipeId = recipeGuid,
                    Id = Convert.ToInt32(dataReader["CommentId"].ToString())
                };
                list.Add(temp);
            }
            CloseConnection();
            return list;
        }

        public bool AddComment(Comment comment)
        {
            OpenConnection();
            var sql = "Insert into Comments (Recipe, Comment, Name, Score) values ('" + comment.RecipeId + "','" + comment.Text + "','" + comment.Name + "','" + comment.Score + "')";
            var cmd = new MySqlCommand(sql, connection);
            var dataReader = cmd.ExecuteReader();
            dataReader.Read();
            CloseConnection();
            return true;
        }

        public Recipe GetRecipe(Guid guid)
        {
            OpenConnection();
            var sql = "Select * from Recipe Where id = '" + guid+"'";
            var cmd = new MySqlCommand(sql, connection);
            var dataReader = cmd.ExecuteReader();
            Recipe recipe = null;
            while (dataReader.Read())
            {
                recipe = new Recipe()
                {
                    Description = dataReader["Description"].ToString(),
                    Id = dataReader["id"].ToString(),
                    ImgUrl = dataReader["ImageUrl"].ToString(),
                    Name = dataReader["Name"].ToString()
                };
            }
            CloseConnection();
            return recipe;
        }

        public TotalIngredients GetAllIngredients(Guid guid)
        {
            OpenConnection();
            var sql = "Select * from Ingredients Where Recipe ='"+guid+"'";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            var listDeg = new List<Ingredient>();
            var listFyll = new List<Ingredient>();
            var ingredients = new TotalIngredients();
            while (dataReader.Read())
            {
                if (dataReader["Category"].Equals("Pajdeg"))
                {
                    listDeg.Add(new Ingredient()
                    {
                        IngredientName = dataReader["Name"].ToString(),
                        Quantity = dataReader["Quantity"].ToString()
                    });
                }
                else
                {
                    listFyll.Add(new Ingredient()
                    {
                        IngredientName = dataReader["Name"].ToString(),
                        Quantity = dataReader["Quantity"].ToString()
                    });
                }
                ingredients.Deg = listDeg;
                ingredients.Fyll = listFyll;

            }
            CloseConnection();
            return ingredients;
        }

        public bool AddRecipe(AddRecipeModel model)
        {
            OpenConnection();
            var id = Guid.NewGuid();
            var sql = "INSERT INTO Recipe (Id,Name,Description,ImageUrl) values('" + id + "','" + model.Name +
                "','" + model.Description + "','" + model.ImgUrl + "');";
            var cmd = new MySqlCommand(sql, connection);

            var dataReader = cmd.ExecuteReader();
            dataReader.Read();
            dataReader.Close();

            var Degar = model.Degs.Split(';');
            foreach (var deg in Degar)
            {
                var ingredient = deg.Split(',');
                var sqlQ = "INSERT INTO Ingredients (Name,Recipe,Quantity,Category) values('" + ingredient[0] + "','" + id +
                           "','" + ingredient[1] + "','" + "Pajdeg" + "');";
                var commander = new MySqlCommand(sqlQ, connection);
                var dataReading = commander.ExecuteReader();
                dataReading.Read();
                dataReading.Close();
            }

            var fyllningar = model.Fylls.Split(';');
            foreach (var fyllning in fyllningar)
            {
                var ingredient = fyllning.Split(',');
                var sqlQ = "INSERT INTO Ingredients (Name,Recipe,Quantity,Category) values('" + ingredient[0] + "','" + id +
                           "','" + ingredient[1] + "','" + "Fyllning" + "');";
                var commander = new MySqlCommand(sqlQ, connection);
                var dataReading = commander.ExecuteReader();
                dataReading.Read();
                dataReading.Close();

            }

            CloseConnection();
            return true;
        }
    }
}