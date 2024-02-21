using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jousyou : MonoBehaviour
{
    private GameObject gameobject;
    private GameObject SD_unitychan_humanoid;
    [SerializeField] private float walter_speed_y = 3.0f;
    public bool times = true;
    

    void OnTriggerStay(Collider col){
        if(col.tag == "Player"){
            if (TIME_MANAGER.is_revtime == true) {
                //Rigidbody rb = this.transform.GetComponent<Rigidbody> ();
                Rigidbody rb = col.GetComponent<Rigidbody> ();
                rb.velocity = new Vector3(0, walter_speed_y, 0);
                //if()
                //Debug.Log(col.name);
                //Debug.Log(col.tag);
            }
        }
        //}
        // } else {
        //     Rigidbody rb = this.transform.GetComponent<Rigidbody> ();
        //     rb.velocity = new Vector3(0, 3, 0);
        // }
        // switch (times){
        // case true:   //場合１
        //     Debug.Log(times);
        //     break;
        // case false:   //場合２
        //     Rigidbody rb = this.transform.GetComponent<Rigidbody> ();
        //     rb.velocity = new Vector3(0, 3, 0);
        //     Debug.Log(times);
        //     break;
        // default:         //その他の場合
           
        //     break;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Space)) {
            if (times == true){
                times = false;
                } else times = true;
            Debug.Log(times);
        }
        */
    }

    // void FixedUpdate () {
        // Rigidbody rb = this.transform.GetComponent<Rigidbody> ();
        // Vector3 force = new Vector3 (0f, 10.0f, 0.0f);
        
    // }
}
