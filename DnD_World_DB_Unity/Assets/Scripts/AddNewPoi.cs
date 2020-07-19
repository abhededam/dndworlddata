using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class AddNewPoi : MonoBehaviour
{
    Button add;
    Button cancel;
    TMP_InputField inputname;
    TMP_Dropdown inputtype;

    public string poiname;
    public string poitype;
    public float poix;
    public float poiy;


    private void Awake()
    {
        add = this.transform.Find("addButton").GetComponent<Button>();
        cancel = this.transform.Find("cancelButton").GetComponent<Button>();
        inputname = this.transform.Find("nameInput").GetComponent<TMP_InputField>();
        inputtype = this.transform.Find("typeInput").GetComponent<TMP_Dropdown>();
        
        
        Hide();
    }

    void Update()
    {
        cancel.onClick.AddListener(Hide);
        add.onClick.AddListener(createPoi);
    }

    void createPoi()
    {
        poiname = inputname.text;
        poitype = inputtype.transform.Find("Label").GetComponent<TMP_Text>().text;

        /*string conn = "URI=file:" + Application.dataPath + "/worlddb.db"; //Path to database.

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = 
            "INSERT INTO poi [(name, type, x, y)]" + "VALUES(" + poiname + "," + poitype + "," + poix + "," + poiy + "); ";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();*/


    }

    public void Show()
    {
        UnityEngine.Debug.Log("i am visible");
        poix = Input.GetAxis("Mouse X");
        poiy = Input.GetAxis("Mouse Y");
        gameObject.SetActive(true);

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
