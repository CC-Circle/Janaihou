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
        if(Input.GetKeyDown(KeyCode.Space)){

            if (SetNum == 0)
            {
                collider.enabled = !collider.enabled;
            }
            if(SetNum == -1)
            {
                collider.enabled = !collider.enabled;
            }
        }
    }

    
}
