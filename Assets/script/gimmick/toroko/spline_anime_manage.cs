using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using System;

public class spline_anime_manage : MonoBehaviour
{
    [SerializeField] SplineAnimate splineAnimate;
    Material mat;
    Shader sha;
    MeshRenderer mesh;
    public Renderer rend;
    
    public float timeOut;

    float duration = 0;
    // Start is called before the first frame update
    void Start()
    {
        mat = rend.material;
        sha = mat.shader;
        //mat.SetInt("",1);
        
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

    //一定時間処理　似非マルチスレッド
    IEnumerator FuncCoroutine()
    {
        while (true)
        {
            
            
            yield return new WaitForSeconds(timeOut);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        FuncCoroutine();
    }
}
