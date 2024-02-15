using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTrigerEnter(Collision collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "rock")
        {
           Destroy(collision.gameObject);
        }
    }
}
