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
        myObject.playerName = "Dr Charles Francis";
        array.array[0] = myObject;
        myObject = new MyClass();
        myObject.level = 2;
        myObject.timeElapsed = 11;
        myObject.playerName = "Charles Francis";
        array.array[1] = myObject;

        json = JsonUtility.ToJson(array);
        Debug.Log(json);
        // json now contains: '{"level":1,"timeElapsed":47.5,"playerName":"Dr Charles Francis"}'
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyClass myObject = new MyClass();
            JsonUtility.FromJsonOverwrite(json, myObject);
            Debug.Log(myObject.level);
            Debug.Log(myObject.timeElapsed);
            Debug.Log(myObject.playerName);

        }
    }
}
