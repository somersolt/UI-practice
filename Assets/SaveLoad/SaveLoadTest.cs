using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveLoadTest : MonoBehaviour
{
    public TMPro.TMP_InputField inputGold;
    public TMPro.TMP_InputField inputName;

    public GameObject cube;
    public Slider slider;
    public Slider slider2;
    public Scrollbar scrollbar;
    private float rotationX = 0f;
    private float rotationY = 0f;
    private Vector3 UiValue;
    private void Start()
    {
        //Load();
    }

    public void Save()
    {
        SaveDataV3 data = new SaveDataV3();
        data.Gold = int.Parse(inputGold.text);
        //data.Name = inputName.text;
        data.Position = cube.transform.position;
        data.Rotation = cube.transform.rotation;
        data.Scale = cube.transform.localScale;
        data.color = cube.GetComponent<Renderer>().material.color;
        data.Uivalue = new Vector3(slider.value,slider2.value,scrollbar.value);

        SaveLoadSystem.Save(data);

    }

    public void Load()
    {
        inputGold.text = string.Empty;
        var data = SaveLoadSystem.Load() as SaveDataV3;

        inputGold.text = data.Gold.ToString();
        //inputName.text = data.Name;
        cube.transform.position = data.Position;
        cube.transform.rotation = data.Rotation;
        cube.transform.localScale = data.Scale;
        cube.GetComponent<Renderer>().material.color = data.color;
        slider.value = data.Uivalue.x;
        slider2.value = data.Uivalue.y;
        scrollbar.value = data.Uivalue.z;
    }


    public void Red()
    {
        cube.GetComponent<Renderer>().material.color = Color.red;
    }
    public void Blue()
    {
        cube.GetComponent<Renderer>().material.color = Color.blue;
    }
    public void Green()
    {
        cube.GetComponent<Renderer>().material.color = Color.green;
    }

    public void RotateY()
    {
        float targetRotationY = slider.value * 360f - 180f;
        rotationY = targetRotationY; // Y 축 회전값을 누적
        cube.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        
    }

    public void RotateX()
    {
        float targetRotationX = slider2.value * 360f - 180f;
        rotationX = targetRotationX; // X 축 회전값을 누적
        cube.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    public void Scale()
    {
        var v = scrollbar.value * (3f - 0.5f) + 0.5f;
        cube.transform.localScale = new Vector3(v, v, v);
        UiValue.z = scrollbar.value;

    }
}
