using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCam : MonoBehaviour
{
    // 카메라가 따라갈 대상
    public GameObject taget;
    Vector3 targetPosition;
  
    private void Update()
    {
        fllow();
    }

    private void fllow()
    {
        // 대상의 X, Z 위치만 따라가기
        targetPosition = taget.transform.position;
        transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
    }
}
