using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//このクラスの is_revtime 変数は 頻繁に他のクラスから参照されます　ki43IIIより
public class TIME_MANAGER : MonoBehaviour
{
    public bool Enable_show_all_palam = false;
    public FallSenser fallSenser;
    public static bool is_revtime = false;

    public Slider debug_slider;
    //public int public_slider_value;


    public float max_clock = 20;
    public int respone_clock_value = 4;
    public float current_clock_value;
    public float repop_item_get = 10;//アイテムを取得したあとそのアイテムが再出現する時間　キャラのリスポーンとは別

    public bool Force_change = true;
    public bool decreasing_gage = true;

    //public float after_extinguishing_time = 10f;
    public float after_nogage_respone = 10f;

    bool is_revial_flag = false;
    bool is_respone_flag = false;

    // Start is called before the first frame update
    void Start()
    {
        debug_slider.maxValue = 8;
        debug_slider.value = 8;
        current_clock_value = max_clock;
    }

    // Update is called once per frame
    void Update()
    {
        //public_slider_value = debug_slider.value;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (is_revtime==false && debug_slider.value > 0.1 )
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
            }
            
            if (debug_slider.value <= 0.1 && Force_change == true)
            {
                is_revtime = false;
            }

        }

        //そのうち短縮版のコードを書きます
        if ((max_clock / 8) * 8 <= current_clock_value)
        {
            debug_slider.value = 8;
        }
        else if ((max_clock / 8) * 7 <= current_clock_value)
        {
            debug_slider.value = 7;
        }
        else if ((max_clock / 8) * 6 <= current_clock_value)
        {
            debug_slider.value = 6;
        }
        else if ((max_clock / 8) * 5 <= current_clock_value)
        {
            debug_slider.value = 5;
        }
        else if ((max_clock / 8) * 4 <= current_clock_value)
        {
            debug_slider.value = 4;
        }
        else if ((max_clock / 8) * 3 <= current_clock_value)
        {
            debug_slider.value = 3;
        }
        else if ((max_clock / 8) * 2 <= current_clock_value)
        {
            debug_slider.value = 2;
        }
        else if ((max_clock / 8) * 1 < current_clock_value)
        {
            debug_slider.value = 1;

        }
        else if (is_respone_flag == false)//ゲージが０になるとき呼ばれる
        {
            
            is_respone_flag = true;
            StartCoroutine(DelayCoroutine(after_nogage_respone, () =>
            {
                is_respone_flag = false;
                // n秒後にここの処理が実行される
                if (current_clock_value < max_clock / 8)
                {
                    fallSenser.nogage_respone();
                    fallSenser.revival_clock();
                }
            }));
        }else if(is_respone_flag == true)
        {
            debug_slider.value = 0.01f;
        }


    }

    public void set_Respone_gage()
    {
        if (debug_slider.value <= respone_clock_value)
        {
            current_clock_value = max_clock / 8 * respone_clock_value + 1;
            debug_slider.value = respone_clock_value;
        }
    }

    

    //遅延子ルーチン用
    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
