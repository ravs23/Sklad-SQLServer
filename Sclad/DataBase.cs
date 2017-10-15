using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

namespace Sklad
{
    static class DataBase
    {
        public static readonly string dbName = "OriSklad";
        public static string ConStrServ { get; private set; } = @"Data Source=A; Integrated Security=True; Pooling=true;";
        public static string ConStrDB { get; private set; } = @"Data Source=A; Initial Catalog=" + dbName + @"; Integrated Security=True; Pooling=true;";

        public static bool CheckConnection()
        {
            SqlConnection connection = new SqlConnection(ConStrServ);
            try
            {
                connection.Open();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool CheckExistDB()
        {
            int exist;
            using (SqlConnection connection = new SqlConnection(ConStrServ))
            {
                string expression = String.Format("SELECT COUNT(*) FROM sys.Databases WHERE [Name] = @dbn");//'{0}'", dbName);
                SqlCommand cmdCheckExistDB = new SqlCommand(expression, connection);
                cmdCheckExistDB.Parameters.AddWithValue("dbn", dbName);
                connection.Open();
                exist = (int)cmdCheckExistDB.ExecuteScalar();
            }
            if (exist != 0) return true;
            else return false;
        }

        public static void CreateDB()
        {
            using (SqlConnection connection = new SqlConnection(ConStrServ))
            {
                string expression = "CREATE DataBASE " + dbName;
                SqlCommand cmdCreatBD = new SqlCommand(expression, connection);
                connection.Open();
                cmdCreatBD.ExecuteNonQuery();
                connection.Close();
            }

        }

        public static void CreateAllTabels()
        {
            using (SqlConnection connection = new SqlConnection(ConStrDB))
            {
                connection.Open();
                // Создание таблицы Product_category
                string expression = @"CREATE TABLE P_category
                                    (
                                    id int IDENTITY NOT NULL PRIMARY KEY,
                                    name  varchar(25) NOT NULL
                                    )";
                SqlCommand cmd = new SqlCommand(expression, connection);
                cmd.Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                try
                {
                    cmd.ExecuteNonQuery();

                    // Создание таблицы Product
                    expression = @"CREATE TABLE Product
                                    (
                                    code int NOT NULL PRIMARY KEY,
                                    name  varchar(80) NOT NULL,
                                    category int NOT NULL FOREIGN KEY REFERENCES P_category(id)
                                    )";
                    cmd.CommandText = expression;
                    cmd.ExecuteNonQuery();



                    // Создание таблицы Catalog_type
                    expression = @"CREATE TABLE C_type
                                    (
                                    id int IDENTITY NOT NULL PRIMARY KEY,
                                    type varchar(30) NOT NULL
                                    )";
                    cmd.CommandText = expression;
                    cmd.ExecuteNonQuery();

                    // Создание таблицы Catalog_period_year
                    expression = @"CREATE TABLE C_p_year
                                    (
                                    id int IDENTITY NOT NULL PRIMARY KEY,
                                    year int NOT NULL
                                    )";
                    cmd.CommandText = expression;
                    cmd.ExecuteNonQuery();

                    // Создание таблицы Catalog_period
                    expression = @"CREATE TABLE C_period
                                    (
                                    id int IDENTITY NOT NULL PRIMARY KEY,
                                    number int NOT NULL,
                                    year int NOT NULL FOREIGN KEY REFERENCES C_p_year(id)
                                    )";
                    cmd.CommandText = expression;
                    cmd.ExecuteNonQuery();

                    // Создание таблицы Catalog
                    expression = @"CREATE TABLE Catalog
                                    (
                                    id int IDENTITY NOT NULL PRIMARY KEY,
                                    period int NOT NULL FOREIGN KEY REFERENCES C_period(id),
                                    type int NOT NULL FOREIGN KEY REFERENCES C_type(id)
                                    )";
                    cmd.CommandText = expression;
                    cmd.ExecuteNonQuery();

                    // Создание таблицы Price
                    expression = @"CREATE TABLE Price
                                    (
                                    id int IDENTITY NOT NULL PRIMARY KEY,
                                    code int NOT NULL FOREIGN KEY REFERENCES Product(code),
                                    pricePC money NOT NULL,
                                    priceDC money NOT NULL,
                                    catalog int NOT NULL FOREIGN KEY REFERENCES Catalog(id),
                                    quantity int NOT NULL,
                                    discont bit NOT NULL,
                                    description varchar(200)
                                    )";
                    cmd.CommandText = expression;
                    cmd.ExecuteNonQuery();

                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    cmd.Transaction.Rollback();
                }
            }
        }

        public static void DeleteDB()
        {
            using (SqlConnection connection = new SqlConnection(ConStrServ))
            {
                string expression = "DROP DATABASE [" + dbName + "]";
                SqlCommand cmdCreatBD = new SqlCommand(expression, connection);
                connection.Open();
                cmdCreatBD.ExecuteNonQuery();
            }

        }

        public static void ClearDB()
        {
            using (SqlConnection connection = new SqlConnection(ConStrDB))
            {
                string expression = @"sp_removedbreplication";

                //DELETE C_p_year;
                //DELETE C_period;
                //DELETE C_type;
                //DELETE Catalog;
                //DELETE P_category;
                //DELETE Price;
                //DELETE Product;";

                //            @"DELETE Price; SELECT * FROM Price;
                //DELETE Product; SELECT * FROM Product;
                //DELETE C_p_year; SELECT * FROM C_p_year;
                //DELETE C_period; SELECT * FROM C_period;
                //DELETE C_type; SELECT * FROM C_type;
                //DELETE Catalog; SELECT * FROM Catalog;
                //DELETE P_category; SELECT * FROM P_category";
                SqlCommand cmdCreatBD = new SqlCommand(expression, connection);
                connection.Open();

                SqlParameter par = cmdCreatBD.Parameters.AddWithValue("@dbname", dbName);
                par.SqlDbType = SqlDbType.VarChar;

                cmdCreatBD.ExecuteNonQuery();
            }
            using (SqlConnection connection = new SqlConnection(ConStrServ))
            {
                connection.Open();

                string expression = "DROP DATABASE [" + dbName + "]";
                SqlCommand cmdCreatBD2 = new SqlCommand(expression, connection);
                cmdCreatBD2.ExecuteNonQuery();

            }

        }

        public static void FillTestData()
        {
            using (SqlConnection connection = new SqlConnection(ConStrDB))
            {
                connection.Open();
                // Заполнение таблицы Product_category
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
                cmd.Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                try
                {
                    cmd.ExecuteNonQuery();

                    //Заполнение таблицы Product
                    expression = @"INSERT INTO Product
                                (code, name, category)
                                VALUES 
                                ('20533','Тушь для ресниц «УЛЬТРАобъем»',1),
                                ('20779','Лак для ногтей «100 % цвета» — Розовый Иней',1),
                                ('23410','Мыло «Инжир и лаванда»',3),
                                ('26261','Лак для ногтей «100 % цвета» — Спелая Слива',1),
                                ('29054','Косметичка',5)";
                    cmd.CommandText = expression;
                    cmd.ExecuteNonQuery();

                    //Заполнение таблицы C_type
                    expression = @"INSERT INTO C_type
                                (type)
                                VALUES 
                                ('Основной'),
                                ('Бизнес Класс'),
                                ('Распродажа'),
                                ('Акционный')";
                    cmd.CommandText = expression;
                    cmd.ExecuteNonQuery();

                    //Заполнение таблицы C_p_type
                    expression = @"INSERT INTO C_p_year
                                (year)
                                VALUES 
                                (2016),
                                (2017),
                                (2018),
                                (2019)";
                    cmd.CommandText = expression;
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

                    //Заполнение таблицы Catalog
                    expression = @"INSERT INTO Catalog
                                (period, type)
                                VALUES 
                                (14,1),
                                (14,2),
                                (14,3),
                                (15,1),
                                (15,2),
                                (15,3),
                                (16,1)";
                    cmd.CommandText = expression;
                    cmd.ExecuteNonQuery();

                    //Заполнение таблицы Price
                    expression = @"INSERT INTO Price
                                (code, pricePC, priceDC, catalog, quantity, discont)
                                VALUES 
                                (20779,   31.9,    25.5,    1,   1,   1),
                                (20533,   79.0,    63.18,   1,   4,   1),
                                (23410,   49.0,    39.18,   1,   2,   0),
                                (20779,   50.6,    45.15,   4,   3,   0),
                                (26261,   31.9,    25.5,    1,   1,   1),
                                (29054,   219.0,   175.2,   4,   7,   1),
                                (29054,   285.0,   267.1,   7,   2,   0),
                                (20779,   15.1,    11.5,    6,   3,   1)";
                    cmd.CommandText = expression;
                    cmd.ExecuteNonQuery();

                    cmd.Transaction.Commit();
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                    cmd.Transaction.Rollback();
                }
            }
        }

        public static void ConfigConnectionString()
        {
            try
            {
            String path = System.Reflection.Assembly.GetExecutingAssembly().Location + ".config";
            if (!File.Exists(path))
            {
                var servStr = new ConnectionStringSettings
                {
                    Name = "ServerConnectionString",     //имя строки подключения в конфигурационном файле
                    ConnectionString = ConStrServ
                };

                var dbStr = new ConnectionStringSettings
                {
                    Name = "DataBaseConnectionString",     //имя строки подключения в конфигурационном файле
                    ConnectionString = ConStrDB
                };

                Configuration config;  // Объект Config представляет конфигурационный файл
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);  // Объект ConfigurationManager предоставляет доступ к файлам конфигурации
                config.ConnectionStrings.ConnectionStrings.Add(servStr);
                config.ConnectionStrings.ConnectionStrings.Add(dbStr);
                config.Save();
            }

            // Получение строки подключения.
            else
            {
            ConStrServ = ConfigurationManager.ConnectionStrings["ServerConnectionString"].ConnectionString;
            ConStrDB = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            }
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
    }
}