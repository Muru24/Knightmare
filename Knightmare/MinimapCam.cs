using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCam : MonoBehaviour
{
    public GameObject taget;
    Vector3 targetPosition;
  
    private void Update()
    {
        fllow();
    }

    private void fllow()
    {
        targetPosition = taget.transform.position;
        transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
    }
}
