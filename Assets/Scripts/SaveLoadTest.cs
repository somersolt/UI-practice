using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveLoadTest : MonoBehaviour
{
    public TMP_InputField inputGold;
    public TMP_InputField inputName;

    //public void Start()
    //{
    //    Load();
    //}

    //public void Save()
    //{
    //    SaveDataV2 data = new SaveDataV2();
    //    data.Gold = int.Parse(inputGold.text);
    //    data.Name = inputName.text;

    //    SaveLoadSystem.Save(data);
    //}

    //public void Load()
    //{
    //    var data = SaveLoadSystem.Load() as SaveDataV2;
    //    inputGold.text = data.Gold.ToString();
    //    inputName.text = data.Name;
    //}
}
