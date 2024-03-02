using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using System;
using EventBridge;


public class spline_anime_manage : MonoBehaviour
{
    [SerializeField] SplineAnimate splineAnimate;
    public ParticleSystem effect;
    [SerializeField] private GameObject start_point;
    private IComponentEventHandler _eventHandler_start_point;
    [SerializeField] private GameObject end_point;
    private IComponentEventHandler _eventHandler_end_point;
    [SerializeField] private GameObject toroko_obj;
    private IComponentEventHandler _eventHandler_toroko_obj;

    [SerializeField, Range(1.0f, 10.0f)]
    public float toroko_duration;
    float frequency = 0.1f;

    public enum Awake_Toroko_point
    {
        Start,
        End
    }
    public Awake_Toroko_point awake_point = Awake_Toroko_point.End;

    public enum Toroko_flow
    {
        normal,
        rev
    }
    public Toroko_flow toroko_flow = Toroko_flow.normal;

    GameObject player_trans;
    bool on_start_point_flag = false;
    bool on_end_point_flag = false;
    bool on_toroko_obj = false;

    float duration = 0;
    // Start is called before the first frame update
    void Start()
    {
        splineAnimate.Duration = toroko_duration;
        StartCoroutine(FuncCoroutine());


        duration = splineAnimate.Duration / 12;
        StartCoroutine(DelayCoroutine(0.01f, () =>
        {
            if (awake_point == Awake_Toroko_point.Start )
            {
                splineAnimate.ElapsedTime += duration;
            }
            if (awake_point == Awake_Toroko_point.End)
            {
                splineAnimate.ElapsedTime =splineAnimate.Duration - duration;
            }

        }));


        _eventHandler_start_point = start_point.RequestEventHandlers();
        _eventHandler_start_point.CollisionStay += On_tri_en_st;
        _eventHandler_start_point.CollisionExit += On_tri_exit_st;

        _eventHandler_end_point = end_point.RequestEventHandlers();
        _eventHandler_end_point.CollisionStay += On_tri_en_en;
        _eventHandler_end_point.CollisionExit += On_tri_exit_en;

        _eventHandler_toroko_obj = toroko_obj.RequestEventHandlers();
        _eventHandler_toroko_obj.CollisionEnter += on_colli_en_toroko;
        _eventHandler_toroko_obj.CollisionExit += on_colli_exit_toroko;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {

            if(on_start_point_flag == true && splineAnimate.ElapsedTime < splineAnimate.Duration/12 + 0.1f)
            {
                player_trans.transform.position = toroko_obj.transform.position;
                player_trans.transform.parent = toroko_obj.transform;

            }
            if(on_end_point_flag == true && splineAnimate.ElapsedTime > splineAnimate.Duration - splineAnimate.Duration / 12)
            {
                player_trans.transform.position = toroko_obj.transform.position;
                player_trans.transform.parent = toroko_obj.transform;
            }
            if(on_toroko_obj == true && splineAnimate.ElapsedTime < splineAnimate.Duration / 12 + 0.1f)
            {
                player_trans.transform.position = start_point.transform.position;
                player_trans.transform.parent = null;
            }
            if(on_toroko_obj == true && splineAnimate.ElapsedTime > splineAnimate.Duration - splineAnimate.Duration / 12)
            {
                player_trans.transform.position = end_point.transform.position;
                player_trans.transform.parent = null;
            }

        }

        if(TIME_MANAGER.is_revtime == true)
        {
            if (toroko_flow == Toroko_flow.rev)
            {
                if (splineAnimate.Duration > splineAnimate.ElapsedTime + duration)
                {
                    splineAnimate.ElapsedTime += Time.deltaTime;
                }
            }
            else
            {
                if (splineAnimate.ElapsedTime > duration)
                {
                    splineAnimate.ElapsedTime -= Time.deltaTime;
                }
            }
        }
        else
        {
            if (toroko_flow == Toroko_flow.rev)
            {
                if (splineAnimate.ElapsedTime > duration)
                {
                    splineAnimate.ElapsedTime -= Time.deltaTime;
                }
            }
            else
            {
                if (splineAnimate.Duration > splineAnimate.ElapsedTime + duration)
                {
                    splineAnimate.ElapsedTime += Time.deltaTime;
                }
            }

        }

    }

    //遅延子ルーチン用
    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
    //擬似マルチスレッド処理
    IEnumerator FuncCoroutine()
    {
        while (true)
        {
            if (on_end_point_flag == true)
            {
                if (effect.isStopped)
                {
                    effect.Play();
                    //Debug.Log("true");
                }
            }
            else if (on_start_point_flag == true)
            {
                if (effect.isStopped)
                {
                    effect.Play();
                    //Debug.Log("true");
                }
            }
            else
            {
                if (effect.isPlaying == true)
                {
                    effect.Stop();
                    //Debug.Log("false");
                }
            }
            yield return new WaitForSeconds(frequency);
        }
    }

    /// <summary>
    /// 当たり判定関連
    /// </summary>
    /// <param name="other"></param>
    private void On_tri_en_st(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (splineAnimate.ElapsedTime < splineAnimate.Duration / 12 + 0.1f)
            {
                on_start_point_flag = true;
                player_trans = other.gameObject;
                //effect.Play();
                //Debug.Log("true");
            }
            else
            {
                on_start_point_flag = false;
            }
            
        }
    }

    private void On_tri_exit_st(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            on_start_point_flag = false;
            player_trans = other.gameObject;
            //effect.Stop();
            //Debug.Log("false");
            
        }
    }

    private void On_tri_en_en(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (splineAnimate.ElapsedTime > splineAnimate.Duration - splineAnimate.Duration / 12)
            {
                on_end_point_flag = true;
                player_trans = other.gameObject;
                //effect.Play();
                //Debug.Log("true");
            }
            else
            {
                on_end_point_flag = false;
            }
            
        }
    }

    private void On_tri_exit_en(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            on_end_point_flag = false;
            player_trans = other.gameObject;
            //effect.Stop();
            //Debug.Log("false");

        }
    }

    private void on_colli_en_toroko(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            on_toroko_obj = true;
            //Debug.Log("true");
        }
    }

    private void on_colli_exit_toroko(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            on_toroko_obj = false;
            //Debug.Log("exit");
        }
    }
}

