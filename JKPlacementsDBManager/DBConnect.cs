using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Data;


namespace JKPlacementsDBManager
{
    public class DBConnect
    {
        public MySqlConnection conn;
        public bool connState;
        string[] settings = new string[5];
        public string server, database, uid, password, port;
        public string table1 = "company";
        public string table2 = "contacts";
        public string table3 = "pending";

        public string table1CompanyNum = "CompanyNum";
        public string table1CompanyName = "CompanyName";
        public string table1DateOfApproach = "DateOfApproach";
        public string table1Comments = "Comments";
        public string table1Response = "Response";
        public string table1Stream = "Stream";

        public string table2ContactID = "ContactID";
        public string table2CompanyName = "CompanyName";
        public string table2ContactPerson = "ContactPerson";
        public string table2ContactPhone = "ContactPhone";
        public string table2Email = "Email";

        public string table3PendingJobID = "PendingJobID";
        public string table3CompanyName = "CompanyName";
        public string table3PendingJob = "PendingJob";
        public string table3FinalDate = "FinalDate";
        public string table3JobStatus = "JobStatus";

        public DBConnect()
        {
            try
            {
                settings = File.ReadAllLines(@MainWindow.ServerLogLocation);
                server = settings[0];
                database = settings[1];
                uid = settings[2];
                password = settings[3];
                port = settings[4];
            }
            catch (FileNotFoundException e)
            {
                server = "localhost";
                database = "placements";
                uid = "root";
                password = "";
                port = "3306";
                settings[0] = server;
                settings[1] = database;
                settings[2] = uid;
                settings[3] = password;
                settings[4] = port;
                try
                {
                    File.WriteAllLines(@MainWindow.ServerLogLocation, settings);

                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Restart Application with administrative privileges.");
                }
            }
            Initialize();
        }

        public void Initialize()
        {
            string connString = "Server=" + server + ";Port=" + port + ";Database=" + database + ";Uid=" + uid + ";Pwd=" + password + ";";
            conn = new MySqlConnection(connString);
        }

        public bool OpenConnection()
        {
            Initialize();
            try
            {
                conn.Open();
                connState = true;
                return true;
            }
            catch (MySqlException e)
            {
                connState = false;
                return false;
            }
            catch (InvalidOperationException e)
            {
                connState = false;
                return false;
            }
        }

        public bool CloseConnection()
        {
            Initialize();
            try
            {
                conn.Close();
                connState = false;
                return true;
            }
            catch (MySqlException e)
            {
                connState = true;
                MessageBox.Show(e.Message);
                return false;
            }
            catch (InvalidOperationException e)
            {
                connState = true;
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }

}
