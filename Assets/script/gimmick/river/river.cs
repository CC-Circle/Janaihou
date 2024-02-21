using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class river : MonoBehaviour
{
    private GameObject gameobject;
    private GameObject SD_unitychan_humanoid;
    public bool times = true;

    [SerializeField] private float true_walter_speed_z = 250;
    [SerializeField] private float false_walter_speed_z = -150;

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if (TIME_MANAGER.is_revtime == false)
            {
                
                Rigidbody rb = col.transform.GetComponent<Rigidbody>();
                rb.AddForce(0, 0, true_walter_speed_z);
                //Debug.Log(col.name);
                //Debug.Log(col.tag);
            }
            else
            {
                Rigidbody rb = col.transform.GetComponent<Rigidbody>();
                rb.AddForce(0, 0, false_walter_speed_z);
                //Debug.Log(col.name);
                //Debug.Log(col.tag);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (times == true)
            {
                times = false;
            }
            else times = true;
            //Debug.Log(times);
        }
    }
}
