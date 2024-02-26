using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colli_naible_con : MonoBehaviour
{
    public int SetNum;
    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();

        if(SetNum == 0)
        {
            collider.enabled = !collider.enabled;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(TIME_MANAGER.is_revtime == true){

            if (SetNum == 0)
            {
                collider.enabled = true;
            }
            if(SetNum == -1)
            {
                collider.enabled = false;
            }
        }
        else
        {
            if (SetNum == 0)
            {
                collider.enabled = false;
            }
            if (SetNum == -1)
            {
                collider.enabled = true;
            }
        }
    }

    
}
