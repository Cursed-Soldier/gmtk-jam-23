using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UnitDrag : MonoBehaviour
{
    public int gold = 500;

    public Tilemap tilemap;
    public Vector3Int location;
    public GameObject unitPrefab;
    public int unitIndex = 0;
    public GameObject[] prefabs;
    public int[] unitCosts;

    public void Dropper()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        location = tilemap.WorldToCell(mp);
        Instantiate(prefabs[unitIndex], location, Quaternion.identity);

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if(unitCosts[unitIndex] <= gold)
            {
                gold -= unitCosts[unitIndex];
                Dropper();
                //Update UI
            }
            
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            unitIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            unitIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            unitIndex = 2;
        }
    }
}