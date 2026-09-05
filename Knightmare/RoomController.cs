using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : Singleton<RoomController>
{
    public string globalRoomTitle = "Basement";

    public RoomInfo currentLoadRoomData;
    public Room currRoom;

    public List<Room> loadedRooms = new List<Room>();

    public bool isLoadingRoom = false;

    // 기존 방을 정리하고 던전 생성
    public void CreatedRoom()
    {
        isLoadingRoom = false;

        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);

        loadedRooms.Clear();

        DungeonCrawlerController.Instance.CreatedRoom();
        SetRoomPath();


    }

    // 생성된 방들의 문과 벽 연결
    void SetRoomPath()
    {
        if (isLoadingRoom)
            return;

        if (loadedRooms.Count > 0)
        {
            foreach (Room room in loadedRooms)
            {
                room.RemoveUnconnectedWalls();
            }
            isLoadingRoom = true;
        }
    }

    // 방 데이터에 맞는 프리팹 생성
    public void LoadRoom(RoomInfo settingRoom)
    {
        if (DoesRoomExist(settingRoom.center_Position.x, settingRoom.center_Position.y, settingRoom.center_Position.z))
        {
            return;
        }

        string roomPreName = settingRoom.roomName;

        GameObject room = Instantiate(RoomPrefabsSet.Instance.roomPrefabs[roomPreName]);

        room.transform.position = new Vector3(
                    (settingRoom.center_Position.x * room.transform.GetComponent<Room>().Width),
                     settingRoom.center_Position.y,
                    (settingRoom.center_Position.z * room.transform.GetComponent<Room>().Height)
        );

        room.transform.localScale = new Vector3(
                    (room.transform.GetComponent<Room>().Width / 10),
                     1,
                    (room.transform.GetComponent<Room>().Height / 10)
        );
        room.transform.GetComponent<Room>().center_Position = settingRoom.center_Position;
        room.name = globalRoomTitle + "-" + settingRoom.roomName + " " + settingRoom.center_Position.x + ", " + settingRoom.center_Position.z;

        room.transform.GetComponent<Room>().roomName = settingRoom.roomName;
        room.transform.GetComponent<Room>().roomType = settingRoom.roomType;
        room.transform.GetComponent<Room>().roomId = settingRoom.roomID;
        room.transform.GetComponent<Room>().parent_Position = settingRoom.parent_Position;
        room.transform.GetComponent<Room>().mergeCenter_Position = settingRoom.mergeCenter_Position;
        room.transform.GetComponent<Room>().distance = settingRoom.distance;

        room.transform.parent = transform;

        loadedRooms.Add(room.GetComponent<Room>());
    }

    // 빈 데이터 혹은 삭제된 방이 있을 경우를 위한 예외처리
    public bool DoesRoomExist(int x, int y, int z)
    {
        return loadedRooms.Find(item => item.center_Position.x == x && item.center_Position.y == y && item.center_Position.z == z) != null;
    }
 
    public Room FindRoom(int x, int y, int z)
    {
        return loadedRooms.Find(item => item.center_Position.x == x && item.center_Position.y == y && item.center_Position.z == z);
    }

    // 플레이어가 들어온 방 저장
    public void OnPlayerEnterRoom(Room room)
    {
        currRoom = room;
    }

}
