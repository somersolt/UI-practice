using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTableTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var itemTalbe = DataTableMgr.Get<ItemTable>(DataTableIds.Item);

        Debug.Log(itemTalbe.Get("Item1"));
        Debug.Log(itemTalbe.Get("Item2"));
        Debug.Log(itemTalbe.Get("Item3"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
