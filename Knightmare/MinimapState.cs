using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapState : MonoBehaviour
{
    public GameObject Minimapfloor;
    public MiniMap mini;
    public int state;
    private void Start()
    {
        Minimapfloor = GameObject.Find(transform.name).transform.Find("MiniMap").GetChild(0).gameObject;
        mini = GameObject.Find("MinimapManager").GetComponent<MiniMap>();
        state = (int)STATE.missing;
        mini.ChangeMaterial(state, Minimapfloor);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ãæµ¹");
        if (other.transform.tag == "Player")
        {
            state = (int)STATE.current;
            mini.ChangeMaterial(state, Minimapfloor);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            state = (int)STATE.visit;
            mini.ChangeMaterial(state, Minimapfloor);
        }
    }
}
