using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSenser : MonoBehaviour
{
    //落下判定をするオブジェクト
    public static Vector3 respone_vector;
    public GameObject Player;
    public List<GameObject> clock_items;
    public TIME_MANAGER time_manager;
    
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

            foreach (var item in clock_items)
            {
                if (item.transform.position.y > 9 && item.GetComponent<turn_clock>().enable_repop == true)
                {
                    item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 10, item.transform.position.z);
                }
            }
            time_manager.set_Respone_gage();
            if(TIME_MANAGER.is_revtime == true)
            {
                TIME_MANAGER.is_revtime = false;
            }
            
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    public void revival_clock()
    {
        foreach (var item in clock_items)
        {
            if (item.transform.position.y > 9 && item.GetComponent<turn_clock>().enable_revial == true)
            {
                item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 10, item.transform.position.z);
            }
        }
    }


}
