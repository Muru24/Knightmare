using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapState : MonoBehaviour
{
    public GameObject Minimapfloor;
    public MiniMap mini;
    public int state;
    // 미니맵 오브젝트와 관리자 설정
    private void Start()
    {
        Minimapfloor = GameObject.Find(transform.name).transform.Find("MiniMap").GetChild(0).gameObject;
        mini = GameObject.Find("MinimapManager").GetComponent<MiniMap>();
        state = (int)STATE.missing;
        mini.ChangeMaterial(state, Minimapfloor);
    }
    // 플레이어가 들어오면 현재 방으로 표시
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌");
        if (other.transform.tag == "Player")
        {
            state = (int)STATE.current;
            mini.ChangeMaterial(state, Minimapfloor);
        }
    }

    // 플레이어가 나가면 방문한 방으로 표시
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            state = (int)STATE.visit;
            mini.ChangeMaterial(state, Minimapfloor);
        }
    }
}
