using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TIME_MANAGER : MonoBehaviour
{


    public static bool is_revtime = false;

    public Slider debug_slider;

    public int max_clock = 20;

    public bool Force_change = false;

    // Start is called before the first frame update
    void Start()
    {
        debug_slider.maxValue = max_clock;
        debug_slider.value = max_clock - Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (is_revtime==false && debug_slider.value > 0 )
            {
                is_revtime = true;
            }
            else if(is_revtime == true)
            {
                is_revtime = false;
            }
            
        }
        
        if (is_revtime == true)
        {
            debug_slider.value -= Time.deltaTime;
            //Debug.Log($"時間は逆行 is_revtime = {is_revtime}");
            if (debug_slider.value <= 0 && Force_change == true)
            {
                is_revtime = false;
            }

        }
        if (is_revtime == false)
        {
            //Debug.Log($"時間は通常 is_revtime = {is_revtime}");
            
        }

    }
}

