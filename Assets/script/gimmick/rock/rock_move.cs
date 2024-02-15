using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_move : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 normal_fall = new Vector3(-2f, -3.0f, 0);
    public Vector3 rev_time_fall = new Vector3(2f, 3.0f, 0);
    public Vector3 normal_slope = new Vector3(-1.0f, -1.8f, 0);
    public Vector3 rev_time_slope =  new Vector3(3.0f, -1.8f, 0);
    public Vector3 normal_cliff = new Vector3(-2f, -2.0f, 0);
    public Vector3 rev_time_cliff = new Vector3(3f, 2.0f, 0);

    //public FallSenser fallsensor;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = set_vec_data;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Slope"))
        {

            if (timecont.is_rev_time == false)
            {
                rb.velocity = normal_slope;
            }
            else
            {
                rb.velocity = rev_time_slope;
            }

        }
        
        ////////////////////////////////////////////////////////
        if (other.CompareTag("vertical"))
        {
            //Debug.Log("vertical");
            if (timecont.is_rev_time == true)
            {
                //rb.velocity = new Vector3(0, 3.0f, 0);
                this.gameObject.GetComponent<Rigidbody>().velocity = rev_time_fall;
                Debug.Log("vertical rev time");
            }
            else if (timecont.is_rev_time == false)
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = normal_fall;

                //Debug.Log($"vertical normal time {rb.velocity}");


            }

        }
        /////////////////////////////////////////////////////////////
        if (other.CompareTag("cliff"))
        {
            //Debug.Log("cliff");
            if (timecont.is_rev_time == false)
            {
                rb.velocity = normal_cliff;
            }
            else
            {
                rb.velocity = rev_time_cliff;
            }
        }

        if (other.CompareTag("dest"))
        {
            DestroyObject(this.gameObject);
        }
        

        
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            collision.transform.position = FallSenser.respone_vector;
        }
    }



}
