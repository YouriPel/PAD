using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MySQL : MonoBehaviour
{
    //Declare variables connection
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    // Create connect method
    public void ConnectToMySQL()
    {
        print("Initializing");
        Initialize();
    }
    //Initialize variables for connectionstring
    public void Initialize()
    {
        server = "localhost";
        database = "zsinayn";
        uid = "sinayn";
        password = "Waag003";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        //MySqlConnection connection = new MySqlConnection(@"data source=C:\users\nsina\zsinayn.db;");
        connection = new MySqlConnection(connectionString);
    }
    //Open Connection with MySQL if an error occurs write down the error
    public bool OpenConnection()
       
    {
        try
        {
            connection.Open();
            print("connection works");
            return true;
        }
        catch (MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:
                    print("Cannot connect to server!");
                    break;
                case 1045:
                    print("Username or password of the connection string is wrong!");
                    break;
                case 1042:
                    print("Unable to connect to the MySQL Server, is the server down?");
                    break;
            }
            return false;
        }
    }
    //Close Connection with MySQL if an error occurs write down the error
    public bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    //Insert playername into the database
    public void InsertNames()
    {
        string query = "Insert INTO player (PlayerName) VALUES ()";

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }

    //Update scores in the database
    public void UpdateScores()
    {
        string query = "UPDATE scoreboard (Score) VALUES()";

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }

    //Delete the content inside the player table 
    public void ResetNames()
    {
        string query = "DELETE player (id_Player,PlayerName,id_Game,Score)";
        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }
    //Delete the content inside the scoreboard table
    public void ResetScores()
    {
        string query = "DELETE scoreboard (PlayerName,Score)";
        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }
    //Get a randomized question and the corresponding  from the database
    public List<string>[] GetQuestionsAnswer()
    {
        string query = "SELECT Questionbox, answerCorrect" +
            "FROM question " +
            "INNER JOIN questionhasanswer as qhaq ON qhaq.id_Question =question.id_Question " +
            "INNER JOIN answer as ghaa ON ghaa.id_Answer = question.id_Question " +
            "WHERE question.id_Question >= RAND() * (SELECT MAX(id_Question)FROM question) " +
            "LIMIT 1";

        List<string>[] list = new List<string>[2];
        list[0] = new List<string>();
        list[1] = new List<string>();

        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["Questionbox"] + "");
                list[1].Add(dataReader["answerCorrect"] + "");
                UnityEngine.Debug.Log("de eerste vraag is" + list[0]);
            }
            dataReader.Close();
            this.CloseConnection();
            return list;
        }
        else
        {
            return list;
        }
    }

    //Create backup database
    public void Backup()
    {
        try
        {
            DateTime Time = DateTime.Now;
            int year = Time.Year;
            int month = Time.Month;
            int day = Time.Day;
            int hour = Time.Hour;
            int minute = Time.Minute;
            int second = Time.Second;
            int millisecond = Time.Millisecond;

            string path;
            path = "C:\\MySqlBackup" + year + "-" + month + "-" + day +
        "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
            StreamWriter file = new StreamWriter(path);


            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "mysqldump";
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                uid, password, server, database);
            psi.UseShellExecute = false;

            Process process = Process.Start(psi);

            string output;
            output = process.StandardOutput.ReadToEnd();
            file.WriteLine(output);
            process.WaitForExit();
            file.Close();
            process.Close();
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error , unable to backup!");
        }
    }
    //Restore backup database
    public void Restore()
    {
        try
        {
            string path;
            path = "C:\\MySqlBackup.sql";
            StreamReader file = new StreamReader(path);
            string input = file.ReadToEnd();
            file.Close();

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "mysql";
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = false;
            psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                uid, password, server, database);
            psi.UseShellExecute = false;


            Process process = Process.Start(psi);
            process.StandardInput.WriteLine(input);
            process.StandardInput.Close();
            process.WaitForExit();
            process.Close();
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error , unable to Restore!");
        }
    }
}



