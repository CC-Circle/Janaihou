using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instance_rock : MonoBehaviour
{
    public GameObject rock;

    public GameObject point_top;
    public GameObject point_buttom;

    public float frequency = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("insta_rock", 0, frequency);
        StartCoroutine("insta_rock");
    }

    // Update is called once per frame
    void Update()
    {

    }


    void insta_rock()
    {
        if (timecont.is_rev_time == false)
        {
            Instantiate(rock, point_top.transform.position, Quaternion.identity);

        }
        else
        {
            Instantiate(rock, point_buttom.transform.position, Quaternion.identity);
        }

        Invoke("insta_rock", frequency);
    }
}
