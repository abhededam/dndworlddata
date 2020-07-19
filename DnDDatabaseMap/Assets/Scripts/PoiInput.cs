using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Mono.Data.Sqlite; 
using System.Data; 
using System;
using TMPro;

public class PoiInput : MonoBehaviour
{
    [SerializeField] private loadPoi loadPoi;

    Button add;
    Button cancel;
    TMP_InputField inputname;
    TMP_Dropdown inputtype;

    public string poiname;
    public string poitype;
    public int poix;
    public int poiy;

    private void Awake()
    {
        add = this.transform.Find("addButton").GetComponent<Button>();
        cancel = this.transform.Find("cancelButton").GetComponent<Button>();
        inputname = this.transform.Find("nameInput").GetComponent<TMP_InputField>();
        inputtype = this.transform.Find("typeInput").GetComponent<TMP_Dropdown>();

        Hide();
    }

    private void Update()
    {
        cancel.onClick.AddListener(Hide);
        add.onClick.AddListener(CreatePoi);
    }

    public void Show()
    {
        //Debug.Log("show");
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        //Debug.Log("Hide");
        gameObject.SetActive(false);
    }

    public void CreatePoi()
    {
        poix = canvasListener.x;
        poiy = canvasListener.y;
        poiname = inputname.text;
        poitype = inputtype.transform.Find("Label").GetComponent<TMP_Text>().text;
        
        
        Debug.Log("you submitted a new POI:: " + poiname + " || type: " + poitype + " || x: " + poix + " || y: " + poiy);
        
        
        Hide();
        SavePoi();
    }

    public void SavePoi()
    {
        string conn = "URI=file:" + Application.dataPath + "/worlddb.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "DELETE FROM POI WHERE id > 3; INSERT INTO POI (name,type,x,y) VALUES('" + poiname + "','" + poitype + "'," + poix + "," + poiy + "); ";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        /*while (reader.Read())
        {
            Debug.Log("Saved" + reader.GetInt32(0));
        }*/
        
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;


        //loadPoi.Load();
    }
}
