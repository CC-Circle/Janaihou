using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Cont_ripple_OnOff : MonoBehaviour
{
    [SerializeField] VisualEffect effect;

    private bool called_play_falg = false;
    private bool called_stop_falg = false;


    // Start is called before the first frame update
    void Start()
    {
        effect.SendEvent("StopPlay");
        called_stop_falg = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (called_play_falg == true)
        {
            called_play_falg = false;
            effect.SendEvent("OnPlay");

        }
        if (called_stop_falg == true)
        {
            called_stop_falg = false;
            effect.SendEvent("StopPlay");

        }

    }

    /// <summary>
    /// <para>ki43: 水面表現有効化</para>
    /// <para>判定:river.OnTrigerEnterに依存</para>
    /// </summary>
    public void ripple_start()
    {
        //effect.SendEvent("OnPlay");
        called_play_falg = true;
        //Debug.Log("called_play");
    }

    /// <summary>
    /// <para>ki43: 水面表現無効化</para>
    /// <para>判定:river.OnTrigerExitに依存</para>
    /// </summary>
    public void ripple_stop()
    {
        //effect.SendEvent("StopPlay");
        called_stop_falg = true;
        //Debug.Log("called_stop");
    }
}
