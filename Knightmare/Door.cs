using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // 문 정보
    public enum DoorType
    {
        left, right, top, bottom
    }
    public GameObject nextRoom;
    public Door SideDoor;
    public DoorType doorType;
    public Transform doorPos;
    public bool isUpdate = false;



    // 연결된 다음 방 설정
    public void setNextRoom(GameObject _nextRoom)
    {
        nextRoom = _nextRoom;
    }
}
