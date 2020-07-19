using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class db : MonoBehaviour
{
    //[SerializeField] private AddNewPoi newPoiInput;
     
    public List<int> index = new List<int>();
    public List<string> namepoi = new List<string>();
    public List<int> xpos = new List<int>();
    public List<int> ypos = new List<int>();

    public GameObject poi;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("start");
        //Instantiate(poi, new Vector3(0, 0, 0), Quaternion.identity);
        readDB();
        
        foreach (int i in index)
        {
            GameObject newPoi = new GameObject();
            newPoi = Instantiate(poi, new Vector3(xpos[i-1], ypos[i-1], 0), Quaternion.identity);
            newPoi.GetComponent<Text>().text = namepoi[i-1];

            UnityEngine.Debug.Log(i);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.Debug.Log("SET NEW POI");
           // newPoiInput.Show();
        }
    }

    public void readDB()
    {
        string conn = "URI=file:" + Application.dataPath + "/worlddb.db"; //Path to database.

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT id, name, x, y " + "FROM poi";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            index.Add(reader.GetInt32(0));
            namepoi.Add(reader.GetString(1));
            xpos.Add(reader.GetInt32(2));
            ypos.Add(reader.GetInt32(3));
            UnityEngine.Debug.Log("read");
        }
        

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
