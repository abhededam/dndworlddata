using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite; 
using System.Data; 
using System;

public class loadPoi : MonoBehaviour
{
    public GameObject poi;

    public List<string> namepoi = new List<string>();
    public List<int> xpos = new List<int>();
    public List<int> ypos = new List<int>();

    public static int i = 0;
    public int count = 0;



    private void Awake()
    {
        readDB();
    }


    private void Start()
    {
        Load();
    }
    private void Update()
    {
        //torefresh
        if(Input.GetKeyDown("r"))
        {
            readDB();
            Load();

        }
    }

    public void readDB()
    {
        string conn = "URI=file:" + Application.dataPath + "/worlddb.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT DISTINCT name, x, y FROM POI";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            namepoi.Add(reader.GetString(0));
            xpos.Add(reader.GetInt32(1));
            ypos.Add(reader.GetInt32(2));
            i++;
            //UnityEngine.Debug.Log(i);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public void Load()
    {
        do 
        {
            GameObject newPoi = new GameObject();
            newPoi = Instantiate(poi, new Vector3(xpos[count], ypos[count], 0), Quaternion.identity);
            newPoi.transform.SetParent(GameObject.Find("loadPoi").transform);
            newPoi.transform.Find("Text").GetComponent<Text>().text = namepoi[count];

            UnityEngine.Debug.Log(count + "   x:  " + xpos[count] + "   y:  " + ypos[count] + "   name:  " + namepoi[count]);
            count ++;
        } while(count < i);
    }
}
