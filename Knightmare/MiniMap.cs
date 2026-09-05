using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE
{
    missing = 0,
    current,
    visit,
}
public class MiniMap : MonoBehaviour
{
    //0 = missing
    //1 = current
    //2 = visit
    public Material[] MinimapStatusMaterial;

    public void ChangeMaterial(int mapState,GameObject floor)
    {
        if (mapState == (int)STATE.missing)
        {
            floor.transform.GetComponent<MeshRenderer>().material = MinimapStatusMaterial[0];
        }
        if (mapState == (int)STATE.current)
        {
            floor.transform.GetComponent<MeshRenderer>().material = MinimapStatusMaterial[1];
        }
        if (mapState == (int)STATE.visit)
        {
            floor.transform.GetComponent<MeshRenderer>().material = MinimapStatusMaterial[2];
        }
    }
}
