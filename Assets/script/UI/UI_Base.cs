using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Base : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI debug_text;

    // Start is called before the first frame update
    void Start()
    {
        debug_text.text = $"debug message\n" +
            $"screen size \n" +
            $"w{Screen.width} x h{Screen.height}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
