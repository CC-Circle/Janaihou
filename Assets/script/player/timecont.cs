using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timecont : MonoBehaviour
{
    static public bool is_rev_time = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // 自分で初期化する
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void Init()
    {
        is_rev_time = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            is_rev_time = !is_rev_time;
            Debug.Log(is_rev_time);
        }
    }
}
