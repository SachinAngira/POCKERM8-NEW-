using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Text;
using Newtonsoft.Json;


public class FileOperations : MonoBehaviour
{

    public Button LoadBtn;
    public Button SaveBtn;
    public Text text;

    private string fileName;
    private string saveDataJson;
    private SaveData saveData;

    public InputField IdText;
    public InputField NameText;


    public void Awake()
    {
        LoadBtn.onClick.AddListener(LoadGameBtnListener);
        SaveBtn.onClick.AddListener(SaveGameBtnListener);

        fileName = Application.persistentDataPath + "/SaveData.json";

        ChechDataFile();        
    }

    private void ChechDataFile()
    {
        try
        {
            if(!File.Exists(fileName))
            {
                FileStream fs = File.Create(fileName);
                fs.Close();
            }
        }
        catch (Exception e)
        {
            Debug.Log("Exeption: " + e);
        }
    }

    private void ReadDataFile()
    {
        saveDataJson = string.Empty;
        
        try
        {
            if(File.Exists(fileName))
            {
                saveDataJson = File.ReadAllText(fileName);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Exeption: " + e);
        }
    }

    private void SaveGameBtnListener()
    {
        ReadDataFile();

        if(IdText.text == string.Empty || NameText.text ==string.Empty)
        {
            return;
        }

        int x = 0;

        if (Int32.TryParse(IdText.text, out x) == false)
        {
            return;
        }

        if (saveDataJson != string.Empty)
        {
            saveData = JsonConvert.DeserializeObject<SaveData>(saveDataJson);
        }
        else
        {
            saveData = new SaveData();
            saveData.Items = new List<InventoryItem>();
        }

        InventoryItem inventoryItem;

        inventoryItem = saveData.Items.Find(item => item.ID == Int32.Parse(IdText.text));

        if(inventoryItem == null)
        {
            inventoryItem = new InventoryItem();
            inventoryItem.ID = Int32.Parse(IdText.text);
            inventoryItem.Name = NameText.text;
            saveData.Items.Add(inventoryItem);
        }
        else
        {
            //Update Data
            inventoryItem.Name = NameText.text;
        }
        
        saveDataJson = JsonConvert.SerializeObject(saveData);

        try
        {
            File.WriteAllText(fileName, saveDataJson);
        }
        catch (Exception e)
        {
            Debug.Log("Exeption: " + e);
        }

        LoadGameBtnListener();
    }

    private void LoadGameBtnListener()
    {
        ReadDataFile();



        text.text = saveDataJson;
        
    }

    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}