using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    static class DataSetUtil
    {
        /// <summary>
        /// Создаем схему таблицы в DataTable и записываем в неё данный из БД
        /// </summary>
        /// <param name="table">Таблица для инициализации</param>
        public static void LoadDBtoDataTable(DataTable table)
        {
            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + table.TableName, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //  table.LoadWithSchema(reader);   //не используем этот метод. используем table.Load(reader)
                table.Load(reader);
                reader.Close();
            }
        }

        /// <summary>
        /// Создаем схему всех таблиц в DataTable и записываем в неё данный из БД
        /// </summary>
        /// <param name="dataset">Коллекция всех таблиц для инициализации</param>
        public static void LoadDBtoDataSet(DataSet dataset)
        {

            using (SqlConnection connection = new SqlConnection(DataBase.ConStrDB))
            {
                SqlCommand cmd = connection.CreateCommand();// ("SELECT * FROM " + table.TableName, connection);
                connection.Open();

                foreach (DataTable table in dataset.Tables)
                {
                    cmd.CommandText = "SELECT * FROM " + table.TableName;

                    SqlDataReader reader = cmd.ExecuteReader();

                    table.LoadWithSchema(reader);
                    reader.Close();
                }

            }
        }

        /// <summary>
        /// Настраиваем Adapter и заполняем им DataSet
        /// </summary>
        /// <param name="dataset"></param>
        public static void AdapterFill(DataSet dataset)
        {
            SqlConnection connection = new SqlConnection(DataBase.ConStrDB);

            string sql = "SELECT * FROM Product;" +
                        "SELECT * FROM Price;" +
                        "SELECT * FROM P_category;" +
                        "SELECT * FROM Catalog;" +
                        "SELECT * FROM C_Period;" +
                        "SELECT * FROM C_p_year;" +
                        "SELECT * FROM C_type;";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            // adapter.Fill создает в DataSet таблицы и заполняет их данными из БД.
            // но по умолчанию не переносит никаких ограничений на таблицы из БД.
            // для переноса всех ограничений, кроме ForeignKey, используется свойство
            // adapter.MissingSchemaAction
            // ограничения ForeignKey необходимо проставлять вручную. 
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // После Fill Все таблицы имеют по-умолчанию имена Table, Table1, TableN
            // Задаем Fill назвать их по другому (два способа - Add, AddRange)

            adapter.TableMappings.Add("Table2", "P_category");

            DataTableMapping[] t_maps = new DataTableMapping[]
            {
            new DataTableMapping("Table3", "Catalog"),
            new DataTableMapping("Table4", "C_period"),
            new DataTableMapping("Table5", "C_p_year"),
            new DataTableMapping("Table6", "C_type")
            };
            adapter.TableMappings.AddRange(t_maps);

            DataTableMapping t_prod = adapter.TableMappings.Add("Table", "Product");
            DataTableMapping t_price = adapter.TableMappings.Add("Table1", "Price");

            //// Можно задать свои имена столбцов в DataTable, который будут отображаться в DataGridView
            //var productColumnMappings = new DataColumnMapping[]
            //    {
            //        new DataColumnMapping("code", "Код продукта"),      // переименовать 
            //        new DataColumnMapping("name", "Наименование"),          // переименовать  
            //        new DataColumnMapping("category","Категория")       // переименовать 
            //    };
            //t_prod.ColumnMappings.AddRange(productColumnMappings);

            //var priceColumnMappings = new DataColumnMapping[]
            //   {
            //        new DataColumnMapping("id", "ID"),
            //        new DataColumnMapping("code", "Код продукта"),
            //        new DataColumnMapping("pricePC", "ПЦ"),
            //        new DataColumnMapping("priceDC","ДЦ"),
            //        new DataColumnMapping("catalog","Каталог"),
            //        new DataColumnMapping("quantity","Количество"),
            //        new DataColumnMapping("discont","Дисконт"),
            //        new DataColumnMapping("description","Описание")
            //  };
            //t_price.ColumnMappings.AddRange(priceColumnMappings);

            adapter.Fill(dataset);
        }

        /// <summary>
        /// Просмотр всех таблиц
        /// </summary>
        /// <param name="dataset">Коллекция таблиц</param>
        public static void ViewTables(DataSet dataset)
        {
            foreach (DataTable table in dataset.Tables)
            {
                Console.WriteLine("!!!!!!----------------{0}--------------!!!!!!", table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(new string('-', 50));
            }
        }

        /// <summary>
        /// Создание связей в DataSet
        /// </summary>
        /// <param name="dataset"></param>
        public static void CreateReferences(DataSet dataset)
        {
            // создание PrimaryKey для таблицы Product
            dataset.Tables["Product"].PrimaryKey = new DataColumn[] { dataset.Tables["Product"].Columns["code"] };

            // создание ограничения ForeignKeyConstraint для таблицы Product (FK) и P_category (PK)
            // 1ый способ
            var fk_prod = new ForeignKeyConstraint(dataset.Tables["P_category"].Columns["id"], dataset.Tables["Product"].Columns["category"]);
            dataset.Tables["Product"].Constraints.Add(fk_prod);

            dataset.Tables["Price"].PrimaryKey = new DataColumn[] { dataset.Tables["Price"].Columns["id"] };
            var fk_price = new ForeignKeyConstraint(dataset.Tables["Product"].Columns["code"], dataset.Tables["Price"].Columns["code"]);
            dataset.Tables["Price"].Constraints.Add(fk_price);

            dataset.Tables["P_category"].PrimaryKey = new DataColumn[] { dataset.Tables["P_category"].Columns["id"] };

            dataset.Tables["Catalog"].PrimaryKey = new DataColumn[] { dataset.Tables["Catalog"].Columns["id"] };

            // установка отношений ForeignKey, 2ой спопсоб
            dataset.Relations.Add("fk_cp", dataset.Tables["C_period"].Columns["id"], dataset.Tables["Catalog"].Columns["period"]);
            dataset.Relations.Add("fk_ct", dataset.Tables["C_type"].Columns["id"], dataset.Tables["Catalog"].Columns["type"]);

            dataset.Tables["C_period"].PrimaryKey = new DataColumn[] { dataset.Tables["C_period"].Columns["id"] };
            var fk_cpy = new ForeignKeyConstraint(dataset.Tables["C_p_year"].Columns["id"], dataset.Tables["C_period"].Columns["year"]);
            dataset.Tables["C_period"].Constraints.Add(fk_cpy);

            dataset.Tables["C_p_year"].PrimaryKey = new DataColumn[] { dataset.Tables["C_p_year"].Columns["id"] };

            dataset.Tables["C_type"].PrimaryKey = new DataColumn[] { dataset.Tables["C_type"].Columns["id"] };


        }

        /// <summary>
        /// Создание связей в DataSet после Adapter
        /// После Adapter необходимо создать только связи ForeignKey.
        /// PrimaryKey уже установлен, если применялся параметр adapter.MissingSchemaAction
        /// </summary>
        /// <param name="dataset"></param>
        public static void CreateReferencesAfterAdapter(DataSet dataset)
        {
            // создание ограничения ForeignKeyConstraint для таблицы Product (FK) и P_category (PK)
            // использовать ТОЛЬКО еси нужно сделать ограничение. В этом случае не создаётся связь Relation
            // и не работаю методы GetChildRows, GetParentRow, GetParentsRow.
            // var fk_prod = new ForeignKeyConstraint(dataset.Tables["P_category"].Columns["id"], dataset.Tables["Product"].Columns["Категория"]);
            // dataset.Tables["Product"].Constraints.Add(fk_prod);
            dataset.Relations.Add("P_category_Product", dataset.Tables["P_category"].Columns["id"], dataset.Tables["Product"].Columns["category"]);

            dataset.Relations.Add("Product_Price", dataset.Tables["Product"].Columns["code"], dataset.Tables["Price"].Columns["code"]);

            dataset.Relations.Add("Catalog_Price", dataset.Tables["Catalog"].Columns["id"], dataset.Tables["Price"].Columns["catalog"]);

            // установка отношений ForeignKey, 2ой спопсоб
            // !! Предпочтительней, т.к. автоматически создаются ограничения Unique и AllowDBNull
            // на родительской таблице и ограничение ForeignKeyConstraint на дочерней таблице.
            // Но можно отменить создание ограничений, передав четвертый параметр false.
            // Так же можно настроить правила удаления и обновления очерних таблиц
            // var cons = dataset.Tables["nameTable"].Constraints["nameConstr"] as ForeignKeyConstraint
            // cons.DeleteRule = Rule.Cascade
            // cons.UpdateRule =
            dataset.Relations.Add("C_period_Catalog", dataset.Tables["C_period"].Columns["id"], dataset.Tables["Catalog"].Columns["period"]);
            dataset.Relations.Add("C_type_Catalog", dataset.Tables["C_type"].Columns["id"], dataset.Tables["Catalog"].Columns["type"]);

            dataset.Relations.Add("C_p_year_C_period", dataset.Tables["C_p_year"].Columns["id"], dataset.Tables["C_period"].Columns["year"]);

        }

    }
}