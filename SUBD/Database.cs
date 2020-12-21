using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace SUBD
{
    public class Database
    {
        private readonly string _path;
        private readonly SqliteConnection _connection;

        public readonly List<Table> Tables;
        
        public Database(string source)
        {
            _path = source;
            _connection = new SqliteConnection($"Data Source={_path}");
            Tables = new List<Table>();
            FillTables();
        }
        
        private void FillTables()
        {
            _connection.Open();
            const string sql = "SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY name;";

            var command = new SqliteCommand {Connection = _connection, CommandText = sql};

            var tables = new List<string>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var name = reader.GetString(i);
                        if (name != "sqlite_sequence") tables.Add(name);
                    }
                }
            }

            foreach (var tableName in tables)
            {
                command = new SqliteCommand
                {
                    Connection = _connection, CommandText = $"PRAGMA table_info('{tableName}');"
                };


                var table = new Table(tableName, new List<Field>());
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(reader.GetOrdinal("name"));
                        var type = reader.GetString(reader.GetOrdinal("type"));

                        var primaryKey = reader.GetString(reader.GetOrdinal("pk")) == "1";
                        var notNull = reader.GetString(reader.GetOrdinal("notnull")) == "1";

                        var autoIncrement = false;
                        var unique = primaryKey;

                        var field = new Field(name, type, notNull, primaryKey, autoIncrement, unique);
                        table.Fields.Add(field);

                        if (primaryKey) table.PrimaryField = field;
                    }
                }
                Tables.Add(table);
            }

            foreach (var table in Tables)
            {
                command = new SqliteCommand
                {
                    Connection = _connection, CommandText = $"PRAGMA foreign_key_list('{table.Name}');"
                };


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fromTableName = reader.GetString(reader.GetOrdinal("table"));
                        var fromFieldName = reader.GetString(reader.GetOrdinal("from"));
                        var toFieldName = reader.GetString(reader.GetOrdinal("to"));

                        foreach (var field in table.Fields.Where(field => field.Name == fromFieldName))
                        {
                            foreach (var tbl1 in Tables.Where(tbl1 => tbl1.Name == fromTableName))
                            {
                                foreach (var fld1 in tbl1.Fields.Where(fld1 => fld1.Name == toFieldName))
                                {
                                    field.Foreign = new Foreign(tbl1, fld1);
                                    break;
                                }
                                break;
                            }

                            break;
                        }

                    }
                }
            }
            try
            {
                command = new SqliteCommand
                {
                    Connection = _connection, CommandText = "select name from sqlite_sequence;"
                };


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);
                        foreach (var table in Tables.Where(table => table.Name == name))
                        {
                            table.PrimaryField.AutoInc = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                
            }
            _connection.Close();
        }
        private void InsertSequence(Table table)
        {
            _connection.Open();

            var command = new SqliteCommand
            {
                Connection = _connection,
                CommandText = $"INSERT INTO sqlite_sequence (name, seq) VALUES ('{table.Name}', 0);"
            };


            command.ExecuteReader();

            _connection.Close();
        }
        private static string BaseSelectCommandText(string tableName, IEnumerable<Field> fields)
        {
            var fieldsString = String.Join(", ", fields.Select(field => tableName + '.' + field.Name).ToArray());
            return string.Format(@"
                        SELECT {0}
                        FROM '{1}'
                    ", fieldsString, tableName);
        }
        private static string BaseInnerJoinText(string tableName, List<Field> fields)
        {
            return fields.Where(field => field.Foreign != null).Aggregate("", (current, field) => current + $" INNER JOIN {field.Foreign.ToTable.Name} ON {field.Foreign.ToTable.Name}.{field.Foreign.ToField.Name} = {tableName}.{field.Name}");
        }
        
        public List<List<string>> Select(Table table, IEnumerable<Field> fields, bool addInner = false)
        {
            _connection.Open();

            var command = new SqliteCommand {Connection = _connection};

            var baseSelect = BaseSelectCommandText(table.Name, fields);

            if (addInner) baseSelect += BaseInnerJoinText(table.Name, table.Fields);

            command.CommandText = baseSelect;

            var result = new List<List<string>>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tmp = new List<string>();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var name = "";
                        try
                        {
                            name = reader.GetString(i);
                        }
                        catch (Exception)
                        {
                            name = "NULL";
                        }
                        tmp.Add(name);
                    }
                    result.Add(tmp);
                }
            }

            _connection.Close();
            return result;
        }
        public List<List<string>> Select(Table table, bool addInner = false)
        {
            _connection.Open();

            SqliteCommand command = new SqliteCommand {Connection = _connection};

            var baseSelect = $"SELECT * FROM '{table.Name}'";

            if (addInner) baseSelect += BaseInnerJoinText(table.Name, table.Fields);

            command.CommandText = baseSelect;

            var result = new List<List<string>>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tmp = new List<string>();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var name = "";
                        try
                        {
                            name = reader.GetString(i);
                        }
                        catch (Exception)
                        {
                            name = "NULL";
                        }
                        tmp.Add(name);
                    }
                    result.Add(tmp);
                }
            }

            _connection.Close();
            return result;
        }

        public List<List<string>> Select(Table table, string whereParams, bool addInner = false)
        {
            _connection.Open();

            SqliteCommand command = new SqliteCommand {Connection = _connection};

            var baseSelect = $"SELECT * FROM '{table.Name}'";

            if (addInner) baseSelect += BaseInnerJoinText(table.Name, table.Fields);

            baseSelect += $" WHERE {whereParams}";

            command.CommandText = baseSelect;

            var result = new List<List<string>>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tmp = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string name = "";
                        try
                        {
                            name = reader.GetString(i);
                        }
                        catch (Exception)
                        {
                            name = "NULL";
                        }
                        tmp.Add(name);
                    }
                    result.Add(tmp);
                }
            }

            _connection.Close();
            return result;
        }

        public List<List<string>> Select(Table table, List<Field> fields, string whereParams, bool addInner = false)
        {
            _connection.Open();

            var command = new SqliteCommand {Connection = _connection};

            var baseSelect = BaseSelectCommandText(table.Name, fields);

            if (addInner) baseSelect += BaseInnerJoinText(table.Name, table.Fields);

            baseSelect += $" WHERE {whereParams}";

            command.CommandText = baseSelect;

            var result = new List<List<string>>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tmp = new List<string>();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        string name = "";
                        try
                        {
                            name = reader.GetString(i);
                        }
                        catch (Exception)
                        {
                            name = "NULL";
                        }
                        tmp.Add(name);
                    }
                    result.Add(tmp);
                }
            }

            _connection.Close();
            return result;
        }
        public void Insert(Table table)
        {
            var baseInsert = "INSERT INTO '" + table.Name + "' ";
            var cols = "(";
            var values = "VALUES (";

            foreach (var field in table.Fields.Where(field => !field.AutoInc))
            {
                cols += "'" + field.Name + "', ";
                values += field.GetValue() + ", ";
            }

            cols = cols.Remove(cols.Length - 2);
            values = values.Remove(values.Length - 2);

            cols += ") ";
            values += ")";
            baseInsert += cols + values + ";";

            _connection.Open();

            var command = new SqliteCommand {Connection = _connection, CommandText = baseInsert};
            
            command.ExecuteReader();

            _connection.Close();
        }
        public void Create(Table table)
        {
            var baseCreate = $"CREATE TABLE IF NOT EXISTS '{table.Name}' (";

            baseCreate = table.Fields.Aggregate(baseCreate, (current, field) => current + (field.GetParams() + ","));

            baseCreate += $" PRIMARY KEY(\"{table.PrimaryField.Name}\"";

            if (table.PrimaryField.AutoInc) baseCreate += " AUTOINCREMENT";

            baseCreate += "));";

            _connection.Open();

            var command = new SqliteCommand {Connection = _connection, CommandText = baseCreate};

            command.ExecuteReader();
            _connection.Close();

            if (table.PrimaryField.AutoInc)
            {
                InsertSequence(table);
            }
        }
        public void Update(Table table)
        {
            var baseUpdate = "UPDATE '" + table.Name + "' SET ";
            baseUpdate = table.Fields.Where(field => !field.AutoInc).Aggregate(baseUpdate, (current, field) => current + $"{field.Name}={field.GetValue()}, ");

            baseUpdate = baseUpdate.Remove(baseUpdate.Length - 2);

            baseUpdate += $" WHERE {table.PrimaryField.Name}={table.PrimaryField.GetValue()};";

            _connection.Open();

            var command = new SqliteCommand {Connection = _connection, CommandText = baseUpdate};

            command.ExecuteReader();
            _connection.Close();
        }
        public void Delete(Table table)
        {
            var baseDelete = "DELETE FROM '" + table.Name + "' ";
            baseDelete += $"WHERE {table.PrimaryField.Name}={table.PrimaryField.GetValue()};";
            _connection.Open();

            var command = new SqliteCommand {Connection = _connection, CommandText = baseDelete};

            command.ExecuteReader();
            _connection.Close();
        }

        public void RenameColumn(string tableName, string oldName, string newName)
        {
            var baseRename = $"ALTER TABLE '{tableName}' RENAME COLUMN '{oldName}' TO '{newName}';";
            _connection.Open();

            var command = new SqliteCommand {Connection = _connection, CommandText = baseRename};

            command.ExecuteReader();
            _connection.Close();
        }

        public void DropTable(string tableName)
        {
            var baseDrop = $"DROP TABLE '{tableName}';";
            _connection.Open();

            var command = new SqliteCommand {Connection = _connection, CommandText = baseDrop};

            command.ExecuteReader();
            _connection.Close();
        }

        public void AddColumn(string tableName, Field field)
        {
            var baseAdd = $"ALTER TABLE '{tableName}' ADD COLUMN {field.Name} {field.Type}";
            _connection.Open();

            var command = new SqliteCommand {Connection = _connection, CommandText = baseAdd};

            command.ExecuteReader();
            _connection.Close();
        }

        public void DropColumn(Table table, Field dropColumn)
        {
            if (table.PrimaryField == dropColumn) return;

            var oldName = table.Name;
            table.Name += "__tmp";
            table.Fields.Remove(dropColumn);

            var fields = table.Fields.Aggregate("", (current, field) => current + (field.Name + ", "));
            fields = fields.Remove(fields.Length - 2);

            var baseDrop = $"CREATE TABLE '{table.Name}' AS SELECT {fields} FROM '{oldName}'; DROP TABLE '{oldName}'; ALTER TABLE '{table.Name}' RENAME TO '{oldName}';";
            _connection.Open();

            var command = new SqliteCommand {Connection = _connection, CommandText = baseDrop};

            command.ExecuteReader();

            table.Name = oldName;
            _connection.Close();
        }
    }

    public class Foreign
    {
        public readonly Table ToTable;
        public readonly Field ToField;

        public Foreign(Table toTable, Field toName)
        {
            this.ToTable = toTable;
            this.ToField = toName;
        }
    }

    public class Field
    {
        public string Name;
        public readonly string Type;
        public readonly bool NotNull;
        public readonly bool PrimaryKey;
        public bool AutoInc;
        public string Value;
        public Foreign Foreign;
        private readonly bool _unique;

        public Field(string name, string type, bool notNull, bool primaryKey, bool autoInc, bool unique)
        {
            Name = name;
            Type = type;
            NotNull = notNull;
            PrimaryKey = primaryKey;
            AutoInc = autoInc;
            _unique = unique;
        }

        public string GetParams()
        {
            var result = "\"" + Name + "\" ";
            result += Type + " ";
            if (NotNull) result += "NOT NULL ";
            if (_unique) result += "UNIQUE ";
            if (Foreign != null) result += $"references {Foreign.ToTable.Name}({Foreign.ToField.Name})  ON DELETE CASCADE ON UPDATE CASCADE";
            return result;
        }

        public string GetValue()
        {
            if (Type == "TEXT") return "\"" + Value + "\"";
            return Value;
        }
    }

    public class Table
    {
        public string Name;
        public Field PrimaryField;
        public List<Field> Fields;
        
        public Table(string name, List<Field> fields, Field primaryField)
        {
            Name = name;
            Fields = fields;
            PrimaryField = primaryField;
        }

        public Table(string name, List<Field> fields)
        {
            Name = name;
            Fields = fields;
        }
    }
}
