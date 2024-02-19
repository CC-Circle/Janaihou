using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSenser : MonoBehaviour
{
    //落下判定をするオブジェクト
    public static Vector3 respone_vector;
    public GameObject Player;
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
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    
}
