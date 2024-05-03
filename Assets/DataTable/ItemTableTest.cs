using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTableTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var itemTable = DataTableManager.Get<ItemTable>(DataTableIds.Item);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
