using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPrefabsSet : Singleton<RoomPrefabsSet> 
{
    [SerializeField]
    public Dictionary<string, GameObject> roomPrefabs = new Dictionary<string, GameObject>();
    public List<string> roomPrefabsName;
    public List<GameObject> roomPrefabsList;

    // 방 이름과 프리팹을 딕셔너리에 등록
    void Awake()
    {
        for (int i = 0; i < roomPrefabsName.Count; i++)
        {
            roomPrefabs.Add(roomPrefabsName[i], roomPrefabsList[i]);
        }
        
    }
    
}
