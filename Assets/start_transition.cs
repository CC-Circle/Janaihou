using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class start_transition : MonoBehaviour
{

    [SerializeField] Image transition_image;
    [SerializeField] float Duration = 0.5f;
    [SerializeField] float Start_Delay = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transition_image.DOFillAmount(1, 0)); 
        DOVirtual.DelayedCall(
            Start_Delay,   //
            () => {
                sequence.Append(transition_image.DOFillAmount(0, Duration));   
            }
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
