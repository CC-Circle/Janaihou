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
    [SerializeField] private GameObject landingplace;
    private IComponentEventHandler _eventHandler_landingplace;
    

    [SerializeField, Range(1.0f, 10.0f)]
    public float toroko_duration;
    float frequency = 0.1f;
    public bool Set_middle_point = false;
    [SerializeField, Range(0.0f, 1.0f)]
    public float middle_point_volume = 0.5f;

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

    bool NoContactYetToroko = true;

    float duration = 0;
    // Start is called before the first frame update
    void Start()
    {
        splineAnimate.Duration = toroko_duration;
        StartCoroutine(FuncCoroutine());

        //トロッコ初期位置セット

        duration = splineAnimate.Duration / 12;
        
            StartCoroutine(DelayCoroutine(0.01f, () =>
            {
                if (awake_point == Awake_Toroko_point.Start)
                {
                    splineAnimate.ElapsedTime += duration;
                    if (Set_middle_point == true)
                    {
                        splineAnimate.ElapsedTime = -splineAnimate.ElapsedTime + toroko_duration * middle_point_volume;
                    }
                }
                if (awake_point == Awake_Toroko_point.End)
                {
                    splineAnimate.ElapsedTime = splineAnimate.Duration - duration;
                    if (Set_middle_point == true)
                    {
                        splineAnimate.ElapsedTime -= toroko_duration - (toroko_duration * middle_point_volume);
                    }
                }
            }));
       


        ///判定セット
        _eventHandler_start_point = start_point.RequestEventHandlers();
        _eventHandler_start_point.CollisionStay += On_tri_en_st;
        _eventHandler_start_point.CollisionExit += On_tri_exit_st;

        _eventHandler_end_point = end_point.RequestEventHandlers();
        _eventHandler_end_point.CollisionStay += On_tri_en_en;
        _eventHandler_end_point.CollisionExit += On_tri_exit_en;

        _eventHandler_toroko_obj = toroko_obj.RequestEventHandlers();
        _eventHandler_toroko_obj.CollisionEnter += on_colli_en_toroko;
        _eventHandler_toroko_obj.CollisionExit += on_colli_exit_toroko;

        _eventHandler_landingplace = landingplace.RequestEventHandlers();
        _eventHandler_landingplace.TriggerEnter += On_tri_en_landingplace;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {

            //キャラのトロッコ落下を防ぐ措置
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
                    if(Set_middle_point == false)
                    {
                        splineAnimate.ElapsedTime += Time.deltaTime;
                    }
                    else if (NoContactYetToroko == false)
                    {
                        splineAnimate.ElapsedTime += Time.deltaTime;
                    }
                    
                }
            }
            else
            {
                if (splineAnimate.ElapsedTime > duration)
                {
                    if (Set_middle_point == false)
                    {
                        splineAnimate.ElapsedTime -= Time.deltaTime;
                    }
                    else if (NoContactYetToroko == false )
                    {
                        splineAnimate.ElapsedTime -= Time.deltaTime;
                    }
                }
            }
        }
        else
        {
            if (toroko_flow == Toroko_flow.rev)
            {
                if (splineAnimate.ElapsedTime > duration)
                {
                    if (Set_middle_point == false)
                    {
                        splineAnimate.ElapsedTime -= Time.deltaTime;
                    }
                    else if (NoContactYetToroko == false )
                    {
                        splineAnimate.ElapsedTime -= Time.deltaTime;
                    }
                }
            }
            else
            {
                if (splineAnimate.Duration > splineAnimate.ElapsedTime + duration)
                {
                    if (Set_middle_point == false)
                    {
                        splineAnimate.ElapsedTime += Time.deltaTime;
                    }
                    else if (NoContactYetToroko == false )
                    {
                        splineAnimate.ElapsedTime += Time.deltaTime;
                    }
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
    /// <summary>
    /// エフェクト再生・停止タスク
    /// </summary>
    /// <returns></returns>
    IEnumerator FuncCoroutine()
    {
        while (true)
        {
            if (on_end_point_flag == true)
            {
                if (effect.isStopped)
                {
                    effect.Play();
                    
                }
            }
            else if (on_start_point_flag == true)
            {
                if (effect.isStopped)
                {
                    effect.Play();
                    
                }
            }
            else
            {
                if (effect.isPlaying == true)
                {
                    effect.Stop();
                    
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
                NoContactYetToroko = false;
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
                NoContactYetToroko = false;
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
                
        }
    }

    private void on_colli_exit_toroko(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            on_toroko_obj = false;
            player_trans.transform.parent = null;
            //Debug.Log("exit");
        }
    }

    private void On_tri_en_landingplace(Collider other)
    {
        //Debug.Log("true");
        if (other.gameObject.tag== "Player")
        {
            NoContactYetToroko = false;
            on_toroko_obj = true;

            player_trans = other.gameObject;
            player_trans.transform.position = toroko_obj.transform.position;
            player_trans.transform.parent = toroko_obj.transform;
            Debug.Log("true");
        }
    }
}
