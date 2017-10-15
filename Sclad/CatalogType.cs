using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{

    static class CatalogType
    {
        public static List<string> catalogType;

        public static void MakeList()
        {
            FillDBCatalogType();

            catalogType = new List<string>()
            {
                "Основной",
                "Бизнес Класс",
                "Распродажа",
                "Акционный"
            };
        }

        // если в БД таблица пустая - записать в неё типы каталогов
        static void FillDBCatalogType()
        {
            if (CheckTableCatalogType())
            {
                using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
                {
                    connection.Open();
                    string expression = @"INSERT INTO C_type
                                (type)
                                VALUES 
                                ('Основной'),
                                ('Бизнес Класс'),
                                ('Распродажа'),
                                ('Акционный')";
                    SqlCommand cmd = new SqlCommand(expression, connection);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // проверяем БД на наличие в таблице C_type записей
        static bool CheckTableCatalogType()
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string expression = @"SELECT COUNT(*) FROM C_type";
                SqlCommand cmd = new SqlCommand(expression, connection);
                int count = (int)cmd.ExecuteScalar();
                return count == 0;
            }
        }


    }
}