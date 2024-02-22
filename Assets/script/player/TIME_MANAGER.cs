using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//このクラスの is_revtime 変数は 頻繁に他のクラスから参照されます　ki43IIIより
public class TIME_MANAGER : MonoBehaviour
{

    public static bool is_revtime = false;

    public Slider debug_slider;

    public int max_clock = 20;
    float current_clock_value;

    public bool Force_change = false;
    public bool decreasing_gage = true;

    
    // Start is called before the first frame update
    void Start()
    {
        debug_slider.maxValue = 8;
        debug_slider.value = 8;
        current_clock_value = max_clock - Time.time;
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
            if (decreasing_gage == true)
            {
                current_clock_value -= Time.deltaTime;

                //そのうち短縮版のコードを書きます
                if ((max_clock / 8) * 8 < current_clock_value)
                {
                    debug_slider.value = 8;
                }
                else if ((max_clock / 8) * 7 < current_clock_value)
                {
                    debug_slider.value = 7;
                }
                else if ((max_clock / 8) * 6 < current_clock_value)
                {
                    debug_slider.value = 6;
                }
                else if ((max_clock / 8) * 5 < current_clock_value)
                {
                    debug_slider.value = 5;
                }
                else if ((max_clock / 8) * 4 < current_clock_value)
                {
                    debug_slider.value = 4;
                }
                else if ((max_clock / 8) * 3 < current_clock_value)
                {
                    debug_slider.value = 3;
                }
                else if ((max_clock / 8) * 2 < current_clock_value)
                {
                    debug_slider.value = 2;
                }
                else if ((max_clock / 8) * 1 < current_clock_value)
                {
                    debug_slider.value = 1;
                }
                else
                {
                    debug_slider.value = 0;
                }

            }
            
            if (debug_slider.value <= 0 && Force_change == true)
            {
                is_revtime = false;
            }

        }
        

    }
}
