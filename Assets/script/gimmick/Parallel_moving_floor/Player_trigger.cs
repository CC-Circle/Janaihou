using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_trigger : MonoBehaviour
{
    [SerializeField] private GameObject parentObj;
    [SerializeField] private GameObject playerObj;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("object is on the floor");
        if (other.gameObject.name == "SD_unitychan_humanoid")
        {
            //Debug.Log("'SD_unitychan_humanoid' is on the floor");
            playerObj.transform.SetParent(parentObj.transform);
        }
    }

    void OnCollisionExit(Collision other)
    {
        //Debug.Log("object is not on the floor");
        if (other.gameObject.name == "SD_unitychan_humanoid")
        {
            //Debug.Log("'SD_unitychan_humanoid' is not on the floor");
            playerObj.transform.SetParent(null);
        }
    }
}
