using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noclip_block : MonoBehaviour
{

    public GameObject block_point_Obj;
    Vector3 block_point;
    // Start is called before the first frame update
    void Start()
    {
        block_point = block_point_Obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //一定地点へ飛ばして壁抜けを防止する　その地点はblock_point_objに依存している
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.position = block_point;
        }
    }

}
