using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

static class TableExtensoinClass
{
    // этот метод записывает данные в таблицу на основе DataReader
    public static void LoadWithSchema(this DataTable table, SqlDataReader reader)
    {
        CreateSchemaFromReader(table, reader);

        table.Load(reader); // Метод Load используется для загрузки в таблицу DataTable строк из источника данных. 
    }

    // этот метод создает ограничения на столбцы таблице на основе полученного объекта DataReader
    private static void CreateSchemaFromReader(DataTable table, SqlDataReader reader)
    {
        DataTable schemaTable = reader.GetSchemaTable(); // Метод Возвращает таблицу описывающую метаданные столбца объекта SqlDataReader. 

        foreach (DataRow schemaRow in schemaTable.Rows)
        {
            DataColumn column = new DataColumn((string)schemaRow["ColumnName"]);    // создание столбца с именем столбца в источнике данных
            column.AllowDBNull = (bool)schemaRow["AllowDbNull"];                    // получение значения свойства AllowDBNull
            column.DataType = (Type)schemaRow["DataType"];                          // получение значения свойства DataType
            column.Unique = (bool)schemaRow["IsUnique"];                            // получение значения свойства Unique
            column.ReadOnly = (bool)schemaRow["IsReadOnly"];                        // получение значения свойства Readonly
            column.AutoIncrement = (bool)schemaRow["IsIdentity"];                   // получение значения свойства AutoIncrement

            if (column.DataType == typeof(string))                                  // если поле типа string
                column.MaxLength = (int)schemaRow["ColumnSize"];                    // получить значение свойства MaxLength

            if (column.AutoIncrement == true)                                       // Если поле с автоинкрементом 
            { column.AutoIncrementStep = -1; column.AutoIncrementSeed = 0; }        // задать свойства AutoIncrementStep и AutoIncrementSeed

            table.Columns.Add(column);                                              // добавить созданный столбец в коллекцию Columns таблицы
        }
    }
}
