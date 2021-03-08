using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdoDemo1 {


    /*
     * 
     * Using
     * Properties.Settings.Default.connString
     * SqlConnection
     * SqlCommand
     * SqlDataReader
     * IDataRecord
     * 
     */

    /*
     *  Øvelse 3 Load people
     *      Use a SqlDataReader to read in all persons and print them to the console output like this:
     *      ID = 1         , Name = Jeannette  :    4 points,   26 years,   72 kg
     */
    public class Exercise3
    {
        public Exercise3()
        {
            ReadPersonData(Properties.Settings.Default.connString);
        }


        private void ReadPersonData(string connectionString)
        {
            string queryString = "SELECT * FROM Persons";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IDataRecord record = (IDataRecord)reader;

                    int id = (int)record[0];
                    string name = (string)record[1];
                    int age = (int)record[2];
                    int weight = (int)record[3];
                    int score = (int)record[4];
                    //Console.WriteLine($"ID = {id}   , Name = {name},    :   {score} points,     {age} years,    {weight} kg");
                    Console.WriteLine(String.Format("ID = {0},  Name = {1}  :   {2} points,     {3} years,  {4} kg", id, name, score, age, weight));
                }

                reader.Close();
            }
        }
    }


    /*
     *  Øvelse 4 Exercise JOIN
     *   1. Use a DataTable to find all Pets. 
     *   2. Use a DataTable to find all People with Pets.
     *   3. Do an inner join to write id and name of Pet-People, together with the id and name of the pet.
     */
    public class Exercise4
    {
        public Exercise4()
        {
            ReadPetDataByDataTableEx4p1(Properties.Settings.Default.connString);
        }

        public void ReadPetDataByDataTableEx4p1(string connectionString)
        {
            string query = "SELECT * FROM Pets";
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                int id = (int)row["ID"];
                string name = (string)row["Name"];
                int age = (int)row["Age"];
                int weight = (int)row["Weight"];
                string species = (string)row["Species"];

                Console.WriteLine($"ID={id}, Name={name}, Age={age}, Weight={weight}, Species={species}");
            }
            conn.Close();
            da.Dispose();
        }

        public void FindPeopleWithPetsUsingDataTableEx4p3(string connectionString)
        {
            string query = "SELECT Persons.ID, Persons.Name, Pets.Name " +
                            "FROM Persons " +
                            "INNER JOIN Pets ON Persons.ID = Pets.owner_id;";
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                var personColumnNameID = row.Table.Columns[0].ColumnName;
                var personColumnNameName = row.Table.Columns[1].ColumnName;
                var petColumnNameName = row.Table.Columns[2].ColumnName;

                int id = (int)row[personColumnNameID];
                string personNameString = (string)row[personColumnNameName];
                string petNameString = (string)row[petColumnNameName];

                Console.WriteLine($"Owner ID = {id}: { personNameString} owns { petNameString}");
            }

            conn.Close();
            da.Dispose();
        }
    }


    /*
     * Øvelse 5 Max score
     *      Using SQL calculate and output all scores like this:
     *      
     *      ID=1, PersonName=Jeannette, Score = 4 has pet
     *      ID=6, PersonName=Eleanora, Score = 6 has pet
     *      ...
     *      and finally output by SQL the person having highest scoring with a Pet.
     */
    public class Exercise5
    {
        public Exercise5()
        {
            HighestScoringPetOwner(Properties.Settings.Default.connString);
        }

        public void ScoreAndPet(string connectionString)
        {
            string query = 
                "SELECT Persons.ID, Persons.Name, Persons.Score, Pets.Name " +
                "FROM Persons " +
                "LEFT JOIN Pets ON Persons.ID = Pets.owner_id;";

            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                var personColumnNameID = row.Table.Columns[0].ColumnName;
                var personColumnNameName = row.Table.Columns[1].ColumnName;
                var personColumnNameScore = row.Table.Columns[2].ColumnName;
                var petColumnNameName = row.Table.Columns[3].ColumnName;

                int id = (int)row[personColumnNameID];
                string personNameString = (string)row[personColumnNameName];
                int score = (int)row[personColumnNameScore];
                string petNameString;
                try
                {
                    petNameString = (string)row[petColumnNameName];
                }
                catch
                {
                    petNameString = "";
                }
                string hasPet = petNameString.Length > 0 ? "has pet" : "has no pet";
                Console.WriteLine($"Owner ID = {id}, PersonName = { personNameString}, Score = {score} {hasPet}");
            }

            conn.Close();
            da.Dispose();
        }

        public void HighestScoringPetOwner(string connectionString)
        {
            string query =
                   "SELECT Persons.ID, Persons.Name, MAX(Score), Pets.Name" +
                   "FROM Persons INNER JOIN Pets" +
                   "ON Persons.ID = Pets.owner_id" +
                   "WHERE Persons.Score = (SELECT MAX(Score)" +
                   "                        FROM Persons INNER JOIN Pets" +
                   "                        ON Persons.ID = Pets.owner_id) " +
                   "GROUP BY Persons.Name, Persons.Score, Persons.ID, Pets.Name;";
            
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            // The query will result in one row only
            //DataRow row = dataTable.Rows[0];
            foreach (DataRow row in dataTable.Rows)
            {

             var columnNameID = row.Table.Columns[0].ColumnName;
            var columnNameOwner_Name = row.Table.Columns[1].ColumnName;
            var columnNameScore = row.Table.Columns[2].ColumnName;
            var columnNamePet_Name = row.Table.Columns[3].ColumnName;

            int id = (int)row[columnNameID];
            string ownerNameString = (string)row[columnNameOwner_Name];
            int score = (int)row[columnNameScore];
            string petNameString = (string)row[columnNamePet_Name];

            Console.WriteLine($"Owner ID = {id}, PersonName = {ownerNameString}, Score = {score} Pet name = {petNameString}");
            }


            conn.Close();
            da.Dispose();
        }
    }

    /* Øvelse 6 Update
     *      Garfield (a cat) gained weight. He now weighs 24kg. Update the database to reflect this.
     */
    public class Exercise6
    {
        public Exercise6()
        {
            UpdateGarfieldsWeight(Properties.Settings.Default.connString, 24);
        }

        public void UpdateGarfieldsWeight(string connectionString, int newWeight)
        {
            string query = $"UPDATE Pets SET Weight = {newWeight} WHERE Name = 'Garfield'";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    /* Øvelse 7 Insert 
     *      Edison has no pets. He finds a kitten and names it Alfred. 
     *      The kitten weighs about one kg. Insert the new kitten into the database to reflect this.
     */
    public class Exercise7
    {
        public Exercise7()
        {
            InsertKitten(Properties.Settings.Default.connString);

        }

        public void InsertKitten(string connectionString)
        {
            int ownerID = GetPersonID(connectionString, "Edison");
            string query = $"INSERT INTO Pets (ID,owner_id,Name,Age,Weight,Species) VALUES (7, {ownerID}, 'Alfred', 0, 1, 'Cat');";
            Console.WriteLine(query);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private int GetPersonID(string connectionString, string personName)
        {
            int result = -1;
            string queryStringPersonName = $"SELECT Persons.ID FROM Persons WHERE Persons.Name = '{personName}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryStringPersonName, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // If there is a result
                while (reader.Read())
                {
                    IDataRecord record = (IDataRecord)reader;

                    int id = (int)record[0];
                    Console.WriteLine($"ID = {id}");

                    result = id;
                }

                reader.Close();
            }

            return result;
        }
    }

    /* Øvelse 8 Delete
     *      Wyatt doesn’t want to be part of this set of exercises, and due to GDPR we must delete him.
     *      What is GDPR? Delete Wyatt from the DB.
    */
    public class Exercise8
    {
        public Exercise8()
        {
            DeletePerson(Properties.Settings.Default.connString, GetPersonID(Properties.Settings.Default.connString, "Wyatt"));
        }

        public void DeletePerson(string connectionString, int personID)
        {            
            string query = $"DELETE FROM Persons WHERE ID = {personID};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private int GetPersonID(string connectionString, string personName)
        {
            int result = -1;
            string queryStringPersonName = $"SELECT Persons.ID FROM Persons WHERE Persons.Name = '{personName}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryStringPersonName, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // If there is a result
                while (reader.Read())
                {
                    IDataRecord record = (IDataRecord)reader;

                    int id = (int)record[0];
                    Console.WriteLine($"ID = {id}");

                    result = id;
                }

                reader.Close();
            }

            return result;
        }
    }

    /* Øvelse 9 Join by LINQ
     *      Load all People into one DataTable and all Pets into another. 
     *      Then use LINQ to join the tables to output the ownerships like this:
     *          { Id = 1, Name = Jeannette, PetId = 2, PetName = Rolf }
     *          { Id = 2, Name = Octavio, PetId = 5, PetName = Pete }
     *          { Id = 3, Name = Claudio, PetId = 1, PetName = Fido }
     *          ...
     */
    public class Exercise9
    {
        public Exercise9()
        {
            LoadAllPeopleUsingLinq(Properties.Settings.Default.connString);

        }

        public void LoadAllPeopleUsingLinq(string connectionString)
        {

        }
    }

    //--------------------------------------------------
    public class DBReader1 {
        // The simplest possible way to do ADO
        public DBReader1() {
            ReadData(Properties.Settings.Default.connString);
        }

        private void ReadPersonData(string connectionString)
        {
            string queryString = "SELECT * FROM Persons";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IDataRecord record = (IDataRecord)reader;

                    int id = (int)record[0];
                    string name = (string)record[1];
                    int age = (int)record[2];
                    int weight = (int)record[3];
                    int score = (int)record[4];
                    //Console.WriteLine($"ID = {id}   , Name = {name},    :   {score} points,     {age} years,    {weight} kg");
                    Console.WriteLine(String.Format("ID = {0},  Name = {1}  :   {2} points,     {3} years,  {4} kg", id, name, score, age, weight));
                }

                reader.Close();
            }
        }


        private void ReadData(string connectionString) {
            string queryString = "SELECT * FROM Persons";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(queryString, connection)) 
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IDataRecord record = (IDataRecord)reader;

                            for (int i = 0; i < record.FieldCount; ++i)
                            {
                                Console.WriteLine(String.Format("{0}, {1}, {2}", record.GetDataTypeName(i), record.GetName(i), record[i])); // record[i].GetType()

                            }
                            
                                int id = (int)record[0];
                                string name = (string)record[1];
                                int age = (int)record[2];
                                int weight = (int)record[3];
                                int score = (int)record[4];


                                // Do stuff with data
                        }
                    }
                }
            }
        }
    }

    /*
     * Using
     * DataTable
     */
    public class DBReader2 {

        public DBReader2() {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString) {
            string query = "SELECT * FROM Persons";

            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        // this will query your database and return the result to your datatable
                        da.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            int id = (int)row["ID"];
                            string name = (string)row["Name"];
                            int age = (int)row["Age"];
                            int weight = (int)row["Weight"];
                            int score = (int)row["Score"];

                            Console.WriteLine($"ID={id},Name={name},Age={age},Weight={weight},Score={score}");
                        }

                        // Using LINQ
                        var q = from row in dataTable.AsEnumerable()
                                where row.Field<int>("Age") > 40
                                select new
                                {
                                    ID = row.Field<int>("ID"),
                                    Name = row.Field<string>("Name"),
                                };
                        foreach (var obj in q)
                            Console.WriteLine($"ID={obj.ID}, Name={obj.Name}");

                    }
                }
            }
        }
    }

    public class DBReader3 {

        public DBReader3() {
            ReadData(Properties.Settings.Default.connString);
        }



        public void ReadData(string connectionString) {
            string query = "SELECT * FROM Persons";

            //DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet("Persons");
                        da.Fill(dataSet);
                        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            Console.WriteLine(dataSet.Tables[0].Rows[i]["Name"].ToString());

                        string tableName = dataSet.Tables[0].TableName;
                        DataTable table = dataSet.Tables["Table"];
                        foreach (DataRow row in table.Rows)
                        {
                            int id = (int)row["ID"];
                            string name = (string)row["Name"];
                            int age = (int)row["Age"];
                            int weight = (int)row["Weight"];
                            int score = (int)row["Score"];

                            // Do lots of funny stuff with dataTable
                        }

                        var q = from row in table.AsEnumerable()
                                where row.Field<int>("Age") > 40
                                select new
                                {
                                    ID = row.Field<int>("ID"),
                                    Name = row.Field<string>("Name"),
                                };
                        foreach (var obj in q)
                            Console.WriteLine($"ID={obj.ID}, Name={obj.Name}");
                    }
                }
            }                
        }
    }


    // SELECT Persons.ID, Persons.Name, Pets.Name FROM Persons
    // INNER JOIN Pets ON Persons.ID = Pets.owner_id;
    public class DBReader4 {

        public DBReader4() {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString) {
            string query = "SELECT Persons.Name, Pets.Name FROM Persons INNER JOIN Pets ON Persons.ID = Pets.owner_id";

            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows) {
                var c0 = row.Table.Columns[0].ColumnName;
                var c1 = row.Table.Columns[1].ColumnName;
                
                var PersonName = (string)row[c0];
                var PetName = (string)row[c1];

                Console.WriteLine($"PersonName={PersonName}, PetName={PetName}");

                // Do lots of funny stuff with dataTable
            }

            //// Using LINQ
            //var q = from row in dataTable.AsEnumerable()
            //        where row.Field<int>("ID") >= 1
            //        select new {
            //            Name = row.Field<string>(1),
            //            Pet = row.Field<string>(2),
            //        };
            //foreach (var obj in q)
            //    Console.WriteLine($"Name={obj.Name}, Pet={obj.Pet}");

            conn.Close();
            da.Dispose();
        }
    }

    public class DBWriter5 {

        public DBWriter5() {
            WriteData1(Properties.Settings.Default.connString);
            WriteData2(Properties.Settings.Default.connString);
            WriteData3(Properties.Settings.Default.connString);
            WriteData4(Properties.Settings.Default.connString);
        }

        public void WriteData1(string connectionString) {

            string query = "INSERT INTO Persons (ID,Name,Age,Weight,Score) VALUES (21,'Anton',34,64,8)";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public void WriteData2(string connectionString) {

            string query = "INSERT INTO Persons (ID,Name,Age,Weight,Score) VALUES (@ID,@Name,@Age,@Weight,@Score)";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {

                    command.Parameters.Add("@ID", SqlDbType.Int).Value = 22;
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 250).Value = "Anton";
                    command.Parameters.Add("@Age", SqlDbType.Int).Value = 34;
                    command.Parameters.Add("@Weight", SqlDbType.Int).Value = 64;
                    command.Parameters.Add("@Score", SqlDbType.Int).Value = 8;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }


            //--DELETE FROM Persons WHERE ID = 21;
            //--UPDATE Pets SET Weight = 24 WHERE Name = 'Garfield';

        }

        public void WriteData3(string connectionString) {

            string query = "DELETE FROM Persons WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = 22;                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void WriteData4(string connectionString) {

            string query = "UPDATE Persons SET Age = 39 WHERE ID = 21";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    class Program {

        static void Main(string[] args) {
            //Console.WriteLine("connString : " + Properties.Settings.Default.connString);

            //Console.WriteLine("Running Exercise5");
            //var readerEx5 = new Exercise5();

            //Console.WriteLine("Running Exercise6");
            //var readerEx6 = new Exercise6();

            //Console.WriteLine("Running Exercise7");
            //var readerEx7 = new Exercise7();

            Console.WriteLine("Running Exercise8");
            var readerEx8 = new Exercise8();

            //Console.WriteLine("Running DBReader1");
            //var reader1 = new DBReader1();

            //Console.WriteLine("Running DBReader2");
            //var reader2 = new DBReader2();

            //Console.WriteLine("Running DBReader3");
            //var reader3 = new DBReader3();

            //Console.WriteLine("Running DBReader4");
            //var reader4 = new DBReader4();

            //Console.WriteLine("Running DBWriter5");
            //var writer5 = new DBWriter5();

            Console.ReadKey();
        }

    }
}
