using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.Diagnostics;

public class db : MonoBehaviour
{
    public GameObject poi;
    public List<float> xpos = new List<float>();
    public List<float> ypos = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(poi, new Vector3(0, 0, 0), Quaternion.identity);
        readDB();
    }

    void readDB()
    {
        string conn = "URI=file:" + Application.dataPath + "/worlddb.db"; //Path to database.

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT name, x, y " + "FROM poi";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString(0);
            xpos.Add(reader.GetInt32(1));
            ypos.Add(reader.GetInt32(2));

        }
        
        foreach(int i in xpos)
        {
            Instantiate(poi, new Vector3(xpos[i], 0, 0), Quaternion.identity);
            UnityEngine.Debug.Log("there is a Point of Interest AHHH   " + xpos[i]);
        }
        

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
