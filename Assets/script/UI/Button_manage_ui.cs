using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Button_manage_ui : MonoBehaviour
{

    public GameObject current_pointer_obj;
    public TextMeshProUGUI stage_indication;
    public List<Sprite> stage_preview_list;
    public Image stage_preview;
    
    // Start is called before the first frame update
    void Start()
    {
        stage_indication.text = "STAGE\nSELECT";
        stage_preview.sprite = stage_preview_list[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 選択時処理
    /// </summary>
    public void touch_stage_select()
    {
        GameObject clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        string buttonName = clickedButton.name;
        //Debug.Log("Clicked button name: " + buttonName);
        current_pointer_obj.transform.position = clickedButton.transform.position;
        stage_indication.text = $"STAGE{buttonName}";
        stage_preview.sprite = stage_preview_list[int.Parse(buttonName)-1];
    }
}
