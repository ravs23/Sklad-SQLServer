using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    static class CatalogPeriod
    {
        public static List<CatalogPeriodOne> catalogPeriod;

        // Выбираем две таблицы C_period,C_p_year и создаем список существующих каталогов
        public static void MakeList()
        {
            catalogPeriod = new List<CatalogPeriodOne>();

            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                string sql = @"SELECT C_period.id, C_period.number, C_p_year.id, C_p_year.year
                                FROM C_period, C_p_year
                                WHERE C_period.year = C_p_year.id
                                ORDER BY C_p_year.year, C_period.number";

                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CatalogPeriodOne catalogPeriodOne = new CatalogPeriodOne();

                    catalogPeriodOne.PeriodId = (int)reader[0];
                    catalogPeriodOne.Number = (int)reader[1];
                    catalogPeriodOne.YearId = (int)reader[2];
                    catalogPeriodOne.Year = (int)reader[3];

                    catalogPeriod.Add(catalogPeriodOne);
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

                //Заполнение таблицы C_p_type
                string expression = @"INSERT INTO C_p_year
                                    (year)
                                    VALUES 
                                    (2016),
                                    (2017),
                                    (2018),
                                    (2019),
                                    (2020)";
                SqlCommand cmd = new SqlCommand(expression, connection);
                cmd.ExecuteNonQuery();

                //Заполнение таблицы C_period
                expression = @"INSERT INTO C_period
                            (number, year)
                            VALUES 
                            (1, 1), 
                            (2, 1), 
                            (3, 1), 
                            (4, 1), 
                            (5, 1), 
                            (6, 1), 
                            (7, 1), 
                            (8, 1), 
                            (9, 1), 
                            (10, 1), 
                            (11, 1), 
                            (12, 1), 
                            (13, 1), 
                            (14, 1), 
                            (15, 1), 
                            (16, 2), 
                            (17, 1), 
                            (1, 2), 
                            (2, 2), 
                            (3, 2)";
                cmd.CommandText = expression;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Поиск каталожного периода в коллекции периодов
        /// </summary>
        /// <param name="periodTEXT"></param>
        /// <returns></returns>
        public static bool SearchSuchCatalog(string periodTEXT)
        {
            foreach (CatalogPeriodOne item in CatalogPeriod.catalogPeriod)
            {
                if (item.CatalogPeriodText == periodTEXT)
                {
                    return true;
                }
            }
            return false;
        }
    }


    struct CatalogPeriodOne
    {
        public int PeriodId { get; set; }
        public int Number { get; set; }
        public int YearId { get; set; }
        public int Year { get; set; }
        public string CatalogPeriodText
        {
            get
            {
                return SkladBase.ConvertPeriodToText(Number, Year);
            }
        }
    }

}
