using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class Create : MonoBehaviour
{
    public GameObject prefab;
    private string json;
    JsonSerializerSettings settings;
    string directory = "./history.json";

    List<Cube> cubeList = new List<Cube>();

    public struct Cube
    {
        public Vector3 pos;
        public Color color;
        public Quaternion rotation;
        public Vector3 scale;
    }

    public void Start()
    {
        settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto
        };
    }

    public void CubeCreate()
    {
        int i = Random.Range(1, 10);


        for (int j = 0; j < 10; j++)
        {
            float x = Random.Range(-10, 10);
            float y = Random.Range(-10, 10);
            float z = Random.Range(-10, 10);
            var cube = Instantiate(prefab, new Vector3(x,y,z) ,Random.rotation );
            var scale = cube.transform.localScale;
            float v = Random.Range(0.5f, 2);
            scale = new Vector3(v, v, v);
            var ren = cube.GetComponent<Renderer>();
            ren.material.color = new Color(Random.value, Random.value, Random.value);

            Cube cube1 = new Cube();
            cube1.pos = cube.transform.position;
            cube1.color = ren.material.color;
            cube1.rotation = cube.transform.rotation;
            cube1.scale = scale;

            cubeList.Add(cube1);
        }
    }

    public void Save()
    {
        json = JsonConvert.SerializeObject(cubeList, Formatting.Indented, new Vector3Converter() , new ColorConverter() , new QuaternionConverter() );
        File.WriteAllText(directory, json);
    }

    public void Load()
    {
        Clear();
        json = File.ReadAllText(directory);
        cubeList = JsonConvert.DeserializeObject<List<Cube>>(json, new Vector3Converter(), new ColorConverter(), new QuaternionConverter());
        foreach (var cube in cubeList)
        {
            var cube1 = Instantiate(prefab, cube.pos, cube.rotation);
            cube1.transform.localScale = cube.scale;
            var ren = cube1.GetComponent<Renderer>();
            ren.material.color = cube.color;
        }
    }

    public void Clear()
    {
        foreach (var cube in cubeList)
        {


        }
    }
}
