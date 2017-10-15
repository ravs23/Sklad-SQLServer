using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklad
{

    static class Category
    {
        public static List<CategoryOne> category;

        public static void MakeList()
        {
            FillDBCategory();
            category = new List<CategoryOne>();

            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string sql = @"SELECT *
                            FROM P_category";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader[0];
                    string name = (string)reader[1];
                    category.Add(new CategoryOne() {Id=id, Name=name });
                }

                reader.Close();

            }
        }

        // если БД таблица пустая - записать в неё категории продуктов по-умолчани
        static void FillDBCategory()
        {
            if (!CheckTableCategory())
            {
                using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
                {
                    connection.Open();
                    string expression = @"INSERT INTO P_category
                                (name)
                                VALUES 
                                ('Декоративная косметика'),
                                ('Парфюмы'),
                                ('Wellness'),
                                ('Аксессуары'),
                                ('Уход для мужчин'),
                                ('Уход за телом'),
                                ('Уход за лицом'),
                                ('Уход за волосами'),
                                ('Детская серия')";
                    SqlCommand cmd = new SqlCommand(expression, connection);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // проверяем БД на наличие в таблице P_category хотя бы одной записи
        static bool CheckTableCategory()
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string expression = @"SELECT COUNT(*) FROM P_category";
                SqlCommand cmd = new SqlCommand(expression, connection);
                int count = (int)cmd.ExecuteScalar();
                return count != 0;
            }
        }
    }

    struct CategoryOne
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

//  Можно использовать в MS SQL Server
//  выбрать все категории, на которые не ссылается ни один продукт (не задействованные категории)
//  SELECT P_category.id
//  FROM Product
//  RIGHT JOIN P_category
//  ON Product.category = P_category.id
//  WHERE Product.category IS NULL

//  Можно использовать и в MS SQL Server и в SQLite
//  SELECT Product_category.id
//  FROM Product_category
//  LEFT JOIN Product
//  ON Product_category.id = Product.category
//  WHERE Product.category IS NULL
