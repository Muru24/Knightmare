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
    // 0 = 미방문
    // 1 = 현재 방
    // 2 = 방문 완료
    public Material[] MinimapStatusMaterial;

    // 미니맵 상태에 맞는 재질 적용
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
