using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_clock : MonoBehaviour
{

    public TIME_MANAGER time_manager;
    

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(0,2,0);
        //parent = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            this.transform.position = new Vector3(transform.position.x,transform.position.y+10,transform.position.z);

            if (time_manager.debug_slider.value < 8)
            {
                time_manager.debug_slider.value++;
            }
        }
    }

    public void clock_ripop()
    {
        if (gameObject.GetComponent<BoxCollider>().enabled == false)
        {
            Debug.Log("not_repop");
        }
    }
}
