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
    public bool DeniedName;

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
        tempSave.DeniedName = DeniedName;

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
                DeniedName = tempSave.DeniedName;
            }
        }
        catch
        {
            SaveData();
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
        public bool DeniedName;
}