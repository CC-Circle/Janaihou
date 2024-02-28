using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using System;

public class spline_anime_manage : MonoBehaviour
{
    [SerializeField] SplineAnimate splineAnimate;


    float duration = 0;
    // Start is called before the first frame update
    void Start()
    {
        duration = splineAnimate.Duration / 12;
        StartCoroutine(DelayCoroutine(0.01f, () =>
        {
            splineAnimate.ElapsedTime += duration;
        }));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (splineAnimate.Duration > splineAnimate.ElapsedTime + duration)
            
            splineAnimate.ElapsedTime += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            if (splineAnimate.ElapsedTime > duration)
            splineAnimate.ElapsedTime -= Time.deltaTime;
        }

    }

    //遅延子ルーチン用
    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }


}
