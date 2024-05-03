using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MyClass
{
    public int level;
    public float timeElapsed;
    public string playerName;
}


[Serializable]
public class MyArray
{
    public MyClass[] array = new MyClass[2];

}


public class JsonTest : MonoBehaviour
{
    private string json;

    void Start()
    {
        var array = new MyArray();

        MyClass myObject = new MyClass();
        myObject.level = 1;
        myObject.timeElapsed = 47.5f;
        myObject.playerName = "Charles";
        array.array[0] = myObject;

        myObject.level = 5;
        myObject.timeElapsed = 88.8f;
        myObject.playerName = "Zarles";
        array.array[1] = myObject;

        json = JsonUtility.ToJson(array);
        Debug.Log(json);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MyClass myOb = new MyClass();
            JsonUtility.FromJsonOverwrite(json, myOb);



            Debug.Log(myOb.level);
            Debug.Log(myOb.timeElapsed);
            Debug.Log(myOb.playerName);
        }
    }
}
