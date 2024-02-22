using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSenser : MonoBehaviour
{
    //落下判定をするオブジェクト
    public static Vector3 respone_vector;
    public GameObject Player;

    public GameObject clock_items;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.position = respone_vector;

            clock_items.transform.position = new Vector3(clock_items.transform.position.x, clock_items.transform.position.y - 10, clock_items.transform.position.z);
            
            
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    
}
