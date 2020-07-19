using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoiInput : MonoBehaviour
{
    Button add;
    Button cancel;
    TMP_InputField inputname;
    TMP_Dropdown inputtype;

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
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void CreatePoi()
    {
        Hide();
    }
}
