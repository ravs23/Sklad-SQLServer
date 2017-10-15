using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    static class SkladBase
    {
        /// <summary>
        /// Выбираем продукты из БД по коду для заполнения основного грида
        /// </summary>
        /// <param name="code">Код продутка</param>
        /// <returns></returns>
        public static DataTable SearchProdByCode(string code)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string sql = @"SELECT Product.code, Product.name, sum(Price.quantity) AS total
                            FROM Product, Price
                            WHERE Price.code = Product.code AND Product.code LIKE @code
                            GROUP BY Product.code, Product.Name";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("code", code + "%");
                SqlDataReader reader = command.ExecuteReader();

                result.Load(reader);
                reader.Close();
            }

            result.Columns[2].ReadOnly = false;
            return result;
        }

        /// <summary>
        /// Выбираем продукты из БД по названию для заполнения основного грида
        /// </summary>
        /// <param name="name">Название продукта</param>
        /// <returns></returns>
        public static DataTable SearchProdByName(string name)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string sql = @"SELECT Product.code, Product.name, sum(Price.quantity) AS total
                            FROM Product, Price
                            WHERE Price.code = Product.code AND Product.Name LIKE @name
                            GROUP BY Product.code, Product.Name";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("name", "%" + name + "%");
                SqlDataReader reader = command.ExecuteReader();

                result.Load(reader);
                reader.Close();

            }
            result.Columns[2].ReadOnly = false;
            return result;
        }

        /// <summary>
        /// Заполняем грид Details в соответствии с выбранным продуктом в основном гриде
        /// </summary>
        /// <param name="currentCode">Код выбранного продукта в основном гриде</param>
        /// <returns></returns>
        public static DataTable FilldgvDetails(string currentCode)
        {
            DataTable resultDetails = new DataTable();

            if (String.IsNullOrEmpty(currentCode))
                return resultDetails;

            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string sql = @"SELECT Price.code, Price.priceDC, Price.pricePC, Price.quantity, C_period.number, C_p_year.year, Price.discont, Price.description, C_type.type
                            FROM Price, C_period, C_type, Catalog, C_p_year
                            WHERE Price.catalog = Catalog.id AND Catalog.type = C_type.id AND Catalog.period = C_period.id and C_period.year = C_p_year.id AND Price.code = @code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("code", currentCode);
                SqlDataReader reader = command.ExecuteReader();

                resultDetails.Load(reader);
                reader.Close();

            }
            return resultDetails;
        }



        /// <summary>
        /// Изменяем количество продукта в БД
        /// </summary>
        /// <param name="code">Код</param>
        /// <param name="quant">Количество</param>
        /// <param name="dc">ДЦ</param>
        /// <param name="pc">ПЦ</param>
        /// <param name="discont">Дисконт</param>
        /// <param name="upDownOp">Отнимаем (Down) или прибавляем (Up)</param>
        public static void UpDownQtyPrice(int code, int quant, decimal dc, decimal pc, bool discont, UpDownOperation upDownOp)
        {
            int new_quant = quant;

            if (upDownOp == UpDownOperation.Down)  // определяем что нужно: отнять или прибавить кол-во
                new_quant--;
            else
                new_quant++;

            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string sql = @"UPDATE Price 
                               SET quantity = @new_quant
                               WHERE code = @code AND quantity = @quant AND priceDC = @dc AND pricePC = @pc AND discont = @discont";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("code", code);
                command.Parameters.AddWithValue("quant", quant);
                command.Parameters.AddWithValue("dc", dc);
                command.Parameters.AddWithValue("pc", pc);
                command.Parameters.AddWithValue("discont", discont);
                command.Parameters.AddWithValue("new_quant", new_quant);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Удаляем продукт из БД, из таблицы Price
        /// </summary>
        /// <param name="code">Код</param>
        /// <param name="quant">Количество</param>
        /// <param name="dc">ДЦ</param>
        /// <param name="pc">ПЦ</param>
        /// <param name="discont">Дисконт</param>
        public static void DeleteProdFromPrice(int code, int quant, decimal dc, decimal pc, bool discont)
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string sql = @"DELETE Price 
                               WHERE code = @code AND quantity = @quant AND priceDC = @dc AND pricePC = @pc AND discont = @discont";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("code", code);
                command.Parameters.AddWithValue("quant", quant);
                command.Parameters.AddWithValue("dc", dc);
                command.Parameters.AddWithValue("pc", pc);
                command.Parameters.AddWithValue("discont", discont);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Удаляем все продукты из БД, из таблицы Price по коду
        /// </summary>
        /// <param name="code">Код</param>
        public static void DeleteProdFromPrice(int code)
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string sql = @"DELETE Price 
                               WHERE code = @code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("code", code);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Удаляем продукт из БД, из таблицы Product.
        /// NOTE! Удалить можно только после удаления всех продуктов с таким же кодом из таблицы Price
        /// </summary>
        /// <param name="code">Код</param>
        public static void DeleteProdFromProductTable(int code)
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string sql = @"DELETE Product
                               WHERE code = @code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("code", code);
                command.ExecuteNonQuery();
            }
        }

        // разбить на методы
        /// <summary>
        /// Добавляем кталог в таблицу Catalog (id периода и тип)
        /// </summary>
        /// <param name="period"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int AddCatalog(int period, int type)
        {
            // Проверяем есть ли такой период и тип в БД. Если есть, получаем id (табл Catalog), если нет - создаём и получаем id
            int catalogIndex;
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string expression = @"SELECT id
                                    FROM  Catalog
                                    WHERE period = @period AND type = @type";
                SqlCommand cmd = new SqlCommand(expression, connection);
                cmd.Parameters.AddWithValue("period", period);
                cmd.Parameters.AddWithValue("type", type);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows) // если возвращается 0 - такого периода+типа нет в БД
                    catalogIndex = 0;
                else
                {
                    reader.Read();
                    catalogIndex = (int)reader[0];
                    reader.Close();
                }
            }

            // если такого периода+типа нету в БД, создаём и получаем Id
            if (catalogIndex == 0)
            {
                using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
                {
                    connection.Open();
                    string expression = @"INSERT INTO Catalog
                                        (period, type)
                                        VALUES 
                                        (@period, @type);
                                        SET @id=SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(expression, connection);
                    cmd.Parameters.AddWithValue("period", period);
                    cmd.Parameters.AddWithValue("type", type);
                    SqlParameter id = new SqlParameter("id", SqlDbType.Int);
                    id.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(id);

                    cmd.ExecuteNonQuery();

                    catalogIndex = (int)id.Value;
                }
            }
            Catalog.MakeList();

            return catalogIndex;
        }

        #region Добавляем каталожный период
        /// <summary>
        /// Добавляем каталожный период в БД (без проверки на его существование)
        /// </summary>
        /// <param name="period"></param>
        /// <param name="year"></param>
        public static void AddCatalogPeriod(int period, int year)
        {

            int yearId = CheckExistYear(year);

            if (yearId == 0)
            {
                yearId = InsertYear(year);
            }

            InsertPeriod(period, yearId);

            //обновляем информацию в локальном листе
            CatalogPeriod.MakeList();
        }

        static int CheckExistYear(int year)
        {
            int yearIndex;
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string expression = @"SELECT id
                                FROM  C_p_year
                                WHERE year = @year";
                SqlCommand cmd = new SqlCommand(expression, connection);
                cmd.Parameters.AddWithValue("year", year);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows) // если возвращается 0 - такого года нет в БД
                    return 0;

                reader.Read();
                yearIndex = (int)reader[0];
                reader.Close();
            }

            return yearIndex;
        }

        static int InsertYear(int year)
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string expression = @"INSERT INTO C_p_year
                                (year)
                                VALUES 
                                (@year);
                                SET @id=SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(expression, connection);
                cmd.Parameters.AddWithValue("year", year);
                SqlParameter id = new SqlParameter("id", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(id);

                cmd.ExecuteNonQuery();

                return (int)id.Value;
            }
        }

        static void InsertPeriod(int period, int yearId)
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();

                string expression = @"INSERT INTO C_period
                                    (number, year)
                                    VALUES
                                    (@period, @yearId)";
                SqlCommand cmd = new SqlCommand(expression, connection);
                cmd.Parameters.AddWithValue("yearId", yearId);
                cmd.Parameters.AddWithValue("period", period);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        /// <summary>
        /// Проверяем есть ли такой продукт в БД (табл Product). Еесли нет - создаём
        /// </summary>
        /// <param name="code">Код продукта</param>
        public static void AddProduct(string code, string name, int category)
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string expression = @"SELECT COUNT(code)
                                    FROM  Product
                                    WHERE code = @code";
                SqlCommand cmd = new SqlCommand(expression, connection);
                cmd.Parameters.AddWithValue("code", code);
                int existCode = (int)cmd.ExecuteScalar();

                if (existCode == 0) // если возвращается 0 - такого продукта нет в БД (табл Product)
                {
                    expression = @"INSERT INTO Product
                                        (code, name, category)
                                        VALUES 
                                        (@code, @name, @category);";
                    cmd.CommandText = expression;
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("category", category);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Добавляем продукт в таблицу Price
        /// </summary>
        /// <param name="code"></param>
        /// <param name="pricePC"></param>
        /// <param name="priceDC"></param>
        /// <param name="catalogId"></param>
        /// <param name="quantity"></param>
        /// <param name="discont"></param>
        /// <param name="description"></param>
        public static void AddProductToPrice(string code, decimal pricePC, decimal priceDC, int catalogId, int quantity, bool discont, string description)
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string expression = @"INSERT INTO Price
                                (code, pricePC, priceDC, catalog, quantity, discont, description)
                                VALUES 
                                (@code, CAST(@pricePC AS money), CAST(@priceDC AS money), @catalog, @quantity, @discont, @description);";
                SqlCommand cmd = new SqlCommand(expression, connection);
                cmd.Parameters.AddWithValue("code", code);
                cmd.Parameters.AddWithValue("pricePC", pricePC);
                cmd.Parameters.AddWithValue("priceDC", priceDC);
                cmd.Parameters.AddWithValue("catalog", catalogId);
                cmd.Parameters.AddWithValue("quantity", quantity);
                cmd.Parameters.AddWithValue("discont", discont ? 1 : 0);
                cmd.Parameters.AddWithValue("description", description);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Добавление категории продукта
        /// </summary>
        /// <param name="categoryName">Название категории</param>
        public static void AddCategory(string categoryName)
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string expression = @"INSERT INTO P_category
                                (name)
                                VALUES 
                                (@cat_name)";
                SqlCommand cmd = new SqlCommand(expression, connection);
                cmd.Parameters.AddWithValue("cat_name", categoryName);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Поиск продукта в БД для отображения в форме Результат поиска
        /// </summary>
        /// <param name="fieldSearch">Искомое значение</param>
        /// <param name="searchBy">По какому полю искать</param>
        /// <returns></returns>
        public static DataTable SearchForAdd(string fieldSearch, SearchBy searchBy)
        {
            DataTable ResultSearchDB = new DataTable();

            if (fieldSearch == string.Empty)
                return null;

            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                string sql = string.Empty;

                switch (searchBy)
                {
                    case SearchBy.Code:
                        sql = @"SELECT Product.code, Product.name, Price.priceDC, Price.pricePC, Price.discont, CONCAT (C_p_year.year, ' / ', C_period.number) AS period
                               FROM Product, Price, C_period, C_p_year, Catalog
                               WHERE Product.code = Price.code AND Price.catalog = Catalog.id AND Catalog.period = C_period.id AND C_period.year = C_p_year.id AND Product.code = @code";
                        command.Parameters.AddWithValue("code", fieldSearch);
                        command.CommandText = sql;
                        break;

                    case SearchBy.Name:
                        sql = @"SELECT Product.code, Product.name, Price.priceDC, Price.pricePC, Price.discont, CONCAT (C_p_year.year, ' / ', C_period.number) AS period
                               FROM Product, Price, C_period, C_p_year, Catalog
                               WHERE Product.code = Price.code AND Price.catalog = Catalog.id AND Catalog.period = C_period.id AND C_period.year = C_p_year.id AND Product.name LIKE @name";
                        command.Parameters.AddWithValue("name", "%" + fieldSearch + "%");
                        command.CommandText = sql;
                        break;
                }

                SqlDataReader reader = command.ExecuteReader();

                ResultSearchDB.Load(reader);
                reader.Close();
            }

            // Меняем все периоды XXXX / X на XXXX / 0X
            ResultSearchDB.Columns["period"].ReadOnly = false;
            foreach (DataRow row in ResultSearchDB.Rows)
            {
                if ((row["period"].ToString()).Length == 8)
                {
                    row["period"] = row["period"].ToString().Insert(7, "0");
                }
            }
            ResultSearchDB.Columns["period"].ReadOnly = true;

            return ResultSearchDB;
        }




        public static int CheckExistProductFull(out int quantityBD, string code, decimal pricePC, decimal priceDC, int catalogId, bool discont)
        {
            int productIndex;
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string expression = @"SELECT Price.id, Price.quantity
                                    FROM Price
                                    WHERE Price.code = @code AND
                                    Price.priceDC = @priceDC AND Price.pricePC = @pricePC AND
                                    Price.catalog = @catalog AND Price.discont = @discont";
                SqlCommand cmd = new SqlCommand(expression, connection);
                cmd.Parameters.AddWithValue("code", code);
                cmd.Parameters.AddWithValue("priceDC", priceDC);
                cmd.Parameters.AddWithValue("pricePC", pricePC);
                cmd.Parameters.AddWithValue("catalog", catalogId);
                cmd.Parameters.AddWithValue("discont", discont);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows) // если возвращается 0 - такого года нет в БД
                {
                    quantityBD = 0;
                    return 0;
                }
                reader.Read();
                productIndex = (int)reader[0];
                quantityBD = (int)reader[1];
                reader.Close();
            }
            return productIndex;
        }

        public static void UpdateProductQuantInPrice(int id, int newQuantity)
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                connection.Open();
                string sql = @"UPDATE Price 
                               SET quantity = @newQuantity
                               WHERE id = @id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("newQuantity", newQuantity);
                command.ExecuteNonQuery();
            }
        }






        /// <summary>
        /// Преобразуем числовой формат "Период" и "Год" в текстовый "Период / Год"
        /// </summary>
        /// <param name="period"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string ConvertPeriodToText(int period, int year)
        {
            string num = period.ToString();

            // если в настройках стоит "показывать с нулём", добавляем 0 перед каталогом
            if (Settings.DisplayCatalogPeriodsWithZero)
            {
                if (num.Length == 1)
                    num = num.Insert(0, "0");
            }

            return num + " / " + year.ToString();
        }
    }
}

