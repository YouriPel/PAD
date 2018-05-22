using System;
using ADODB;
using UnityEngine;

public class MySQL : MonoBehaviour{

    public Recordset DB_RS;
    public Connection DB_CONN;

    public static MySQL mysql = new MySQL();

    public void MySQLInit()
    {

        try
        {
            DB_RS = new Recordset();
            DB_CONN = new Connection
            {
                ConnectionString = "Driver={MySql ODBC 5.1.13 Driver}; Server=localhost;Port=3306; Database=foodtrivia;User = root;Password=1234;Option=3;",
                CursorLocation = CursorLocationEnum.adUseServer
            };
            DB_CONN.Open();
                Debug.Log("Connection Succes");
            
            var db = DB_RS;
            {
                db.Open("SELECT * FROM question WHERE 0=1", DB_CONN, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                db.AddNew();
                db.Fields["Questionbox"].Value = "Noahhetwerkt";
                db.Update();
                db.Close();
            }
        }
        catch(Exception ex)
        {
            Debug.Log(ex);
           //Debug.Log();
        }
    }
}
