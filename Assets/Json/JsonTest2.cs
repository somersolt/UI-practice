using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using TreeEditor;
using Newtonsoft.Json.Converters;



public class JsonTest2 : MonoBehaviour
{
    private string json;

    void Start()
    {
       
        Vector3 position = new Vector3 (0, 0, 0);
        json = JsonConvert.SerializeObject(position, Formatting.None, new Vector3Converter());
        Debug.Log(json);

        {
            //List<MyClass> list = new List<MyClass>();   

            //MyClass myObject = new MyClass();
            //myObject.level = 1;
            //myObject.timeElapsed = 47.5f;
            //myObject.playerName = "Charles";

            //list.Add(myObject);
            //list.Add(myObject);

            //Debug.Log(list[0] == list[1]); //직렬화 전에는 내용물이 같으면 같다고 알 수 있음

            //json = JsonConvert.SerializeObject(list);
            //Debug.Log(json);
        }

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = JsonConvert.DeserializeObject<Vector3>(json, new Vector3Converter());
            Debug.Log(pos);
        }

        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    List<MyClass> list = JsonConvert.DeserializeObject<List<MyClass>>(json);
            //    Debug.Log(list[1].level);
            //    Debug.Log(list[1].timeElapsed);
            //    Debug.Log(list[1].playerName);

            //    Debug.Log(list[0] == list[1]); //직렬화 -> 역직렬화 후에는 내용물이 같음을 알 수 없음. 직렬화시 고려되지 않음.
            //}
        }

    }
}
