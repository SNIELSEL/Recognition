using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.LowLevel;

public class SaveAndLoad : MonoBehaviour
{
    public int slot;
    public float sensitivity;
    public float volume;
    public int difficulty;
    public bool saveWaveForLeaderBoard;

    private XML_SaveData tempSave;

    public void Awake()
    {
        slot = 1;
    }
    public void Start()
    {
        slot = PlayerPrefs.GetInt("SaveSlot");

        if (slot == 0)
        {
            slot++;
        }
    }

    public void SetSlot(int selectedslot)
    {
        slot = selectedslot;

        PlayerPrefs.SetInt("SaveSlot", slot);
    }

    public void SaveData()
    {
        XML_SaveData tempSave = new XML_SaveData();
        tempSave.slot = slot;
        tempSave.sensitivity = sensitivity;
        tempSave.volume = volume;
        tempSave.difficulty = difficulty;
        tempSave.saveWaveForLeaderBoard = saveWaveForLeaderBoard;

        XmlSerializer serializer = new XmlSerializer(typeof(XML_SaveData));

        using (FileStream stream = new FileStream(Application.persistentDataPath + "/GameData" +slot + ".xml", FileMode.Create))
        {
            serializer.Serialize(stream, tempSave);
        }
    }

    public void LoadData()
    {
        XML_SaveData tempSave = new XML_SaveData();
        
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XML_SaveData));

            using (FileStream stream = new FileStream(Application.persistentDataPath + "/GameData" + slot + ".xml", FileMode.Open))
            {
                tempSave = serializer.Deserialize(stream) as XML_SaveData;

                slot = tempSave.slot;
                sensitivity = tempSave.sensitivity;
                volume = tempSave.volume;
                difficulty = tempSave.difficulty;
                saveWaveForLeaderBoard = tempSave.saveWaveForLeaderBoard;
            }
        }
        catch
        {
            SaveData();
        }
    }

    public XML_SaveData GetSaveData()
    {
        return tempSave;
    }

    public void ResetData()
    {
        XML_SaveData tempSave = new XML_SaveData();
        tempSave.slot = slot;
        tempSave.sensitivity = 0;
        tempSave.volume = 1;


        XmlSerializer serializer = new XmlSerializer(typeof(XML_SaveData));

        using (FileStream stream = new FileStream(Application.persistentDataPath + "/SaveData" + slot + ".xml", FileMode.Create))
        {
            serializer.Serialize(stream, tempSave);
        }
    }
}
    [System.Serializable]
    public class XML_SaveData
    {
        public int slot;
        public float sensitivity;
        public float volume;
        public int difficulty;
        public bool saveWaveForLeaderBoard;
}