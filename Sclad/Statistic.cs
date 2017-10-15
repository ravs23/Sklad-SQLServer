using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    class Statistic
    {



        public static string[] GetStatistic()
        {
            string[] results = new string[7];
            string[] queries = GetQueries(-1, -1); // Для общей статистики

            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                SqlCommand cmd = connection.CreateCommand();
                connection.Open();

                for (int i = 0; i < results.Length; i++)
                {
                    cmd.CommandText = queries[i];
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                        results[i] = string.Empty;
                    else
                    {
                        reader.Read();
                        if (i == 2 || i == 3)
                            results[i] = Double.Parse(reader[0].ToString()).ToString();
                        else
                            results[i] = reader[0].ToString();
                    }
                    reader.Close();
                }
            }

            return results;
        }


        public static string[] GetStatistic(int catalogType, int category, FrmStatistic frm)
        {
            string[] results = new string[7] { "", "", "", "", "", "", "" };
            if (catalogType == 0 & category == 0)
                return results;

            string[] queries = GetQueries(catalogType, category);

            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    connection.Open();

                    for (int i = 0; i < results.Length; i++)
                    {
                        cmd.CommandText = queries[i];
                    frm.tbTEST.Text = queries[i];
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (!reader.HasRows)
                            results[i] = string.Empty;
                        else
                        {
                            reader.Read();
                        double price;
                        if ((i == 2 || i == 3) && double.TryParse(reader[0].ToString(), out price))
                            results[i] = price.ToString();
                        else
                            results[i] = reader[0].ToString();
                        }
                        reader.Close();
                    }

                }
            return results;
        }



        static string[] GetQueries(int catalogType, int category)
        {
            string param1 = string.Empty;
            string param2 = string.Empty;
            string param1_repl = " AND Price.catalog = Catalog.id AND Catalog.type = ";// = int
            string param2_repl = " AND Price.code = Product.code AND Product.category = ";// = int
            string paramAdd1 = string.Empty;
            string paramAdd2 = string.Empty;
            string paramAdd1_repl = ", Catalog ";
            string paramAdd2_repl = "";//, Product ";

            if (catalogType > 0 & category == 0)
            {
                param1 = param1_repl + catalogType;
                paramAdd1 = paramAdd1_repl;
            }
            else if(catalogType == 0 & category > 0)
            {
                param2 = param2_repl + category;
                paramAdd2 = paramAdd2_repl;
            }
            else if (catalogType > 0 & category > 0)
            {
                param1 = param1_repl + catalogType;
                paramAdd1 = paramAdd1_repl;

                param2 = param2_repl + category;
                paramAdd2 = paramAdd2_repl;
            }

            string querie1 = @"SELECT sum(Price.quantity) FROM Product, Price " + paramAdd1 + " " + paramAdd2 + " WHERE Product.code = Price.code AND Price.code > 0 " + param1 + " " + param2;

            string querie2 = @"SELECT count(DISTINCT(Product.code)) FROM Product, Price " + paramAdd1 + " " + paramAdd2 + "WHERE Product.code = Price.code AND Product.code > 0 " + param1 + " " + param2;

            string querie3 = @"SELECT sum(Price.priceDC * Price.quantity) FROM Product, Price " + paramAdd1 + " " + paramAdd2 + "WHERE Product.code = Price.code AND Price.code > 0 " + param1 + " " + param2;

            string querie4 = @"SELECT sum(Price.pricePC * Price.quantity) FROM Product, Price " + paramAdd1 + " " + paramAdd2 + "WHERE Product.code = Price.code AND Price.code > 0 " + param1 + " " + param2;

            string querie5 = @"SELECT MIN(CONCAT(C_p_year.year, ' / ', C_period.number))
                               FROM C_p_year, C_period, Catalog, Price, C_type, P_category, Product
                               WHERE C_p_year.id = C_period.year AND C_period.id= catalog.period AND Catalog.id = Price.catalog " + param1 + " " + param2;

            string querie6 = @"SELECT MAX(CONCAT(C_p_year.year, ' / ', C_period.number))
                               FROM C_p_year, C_period, Catalog, Price, C_type, P_category, Product
                               WHERE C_p_year.id = C_period.year AND C_period.id= catalog.period AND Catalog.id = Price.catalog " + param1 + " " + param2;

            string querie7 = @"SELECT COUNT(DISTINCT(CONCAT(C_period.number, ' / ', C_p_year.year)))
                               FROM C_p_year, C_period, Catalog, Price, C_type, P_category, Product
                               WHERE C_p_year.id = C_period.year AND C_period.id= catalog.period AND Catalog.id = Price.catalog " + param1 + " " + param2;

            string[] queries = { querie1, querie2, querie3, querie4, querie5, querie6, querie7 };

            return queries;
        }
    }
}
