using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // 벽 방향
    public enum WallType
    {
        left, top, right, bottom
    }
    public WallType wallType;
    public Transform wallPos;
    public bool isSetUp = true;
    public bool isUpdate = false;

}
