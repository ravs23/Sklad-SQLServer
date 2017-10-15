using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    static class Catalog
    {
        public static List<CatalogOne> catalog;

        // Выбираем таблицу Catalog и создаем список существующих каталогов и типов
        public static void MakeList()
        {

            catalog = new List<CatalogOne>();

            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                string sql = @"SELECT Catalog.id, Catalog.period, Catalog.type
                               FROM Catalog";
                //
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CatalogOne catalogOne = new CatalogOne();

                        catalogOne.Id = (int)reader[0];
                        catalogOne.Period = (int)reader[1];
                        catalogOne.Type = (int)reader[2];

                        catalog.Add(catalogOne);
                    }
                }

                reader.Close();

            }
        }

        // Искуственный фил во время разработки. В рабочей программе не используем этот метод,
        // так как программа поставляется с пустыми таблицами, заполняемыми в этом методе
        public static void FillDBCatalog()
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();

                //Заполнение таблицы Catalog
                string expression = @"INSERT INTO Catalog
                                    (period, type)
                                    VALUES 
                                    (14,1),
                                    (14,2),
                                    (14,3),
                                    (15,1),
                                    (15,2),
                                    (15,3),
                                    (16,1)";
                SqlCommand cmd = new SqlCommand(expression, connection);
                cmd.ExecuteNonQuery();
            }
        }
    }


    struct CatalogOne
    {
        public int Id { get; set; }
        public int Period { get; set; }
        public int Type { get; set; }
    }
}
