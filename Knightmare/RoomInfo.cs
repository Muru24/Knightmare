using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class RoomInfo
{
    public string roomID;
    public string roomName;
    public string roomType;

    // 개별 방 위치
    public Vector3Int center_Position;
    // 부모 방의 위치
    public Vector3Int parent_Position;
    // 복합 방 중앙 위치
    public Vector3 mergeCenter_Position;
    // 방 생성 상태(true : 생성, false : 빈방)
    public bool isValidRoom;
    // 시작 방부터 해당 방까지의 거리
    public int distance;

}
