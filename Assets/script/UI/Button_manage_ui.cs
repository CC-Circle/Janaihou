using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_manage_ui : MonoBehaviour
{

    public GameObject current_pointer_obj;
    public TextMeshProUGUI stage_indication;
    public List<Sprite> stage_preview_list;
    public Image stage_preview;

    string buttonName;

    // Start is called before the first frame update
    void Start()
    {
        stage_indication.text = "STAGE\nSELECT";
        stage_preview.sprite = stage_preview_list[5];
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
        buttonName = clickedButton.name;
        //Debug.Log("Clicked button name: " + buttonName);
        current_pointer_obj.transform.position = clickedButton.transform.position;
        stage_indication.text = $"STAGE\n{buttonName}";
        if (buttonName == "TUTORIAL")
        {
            stage_preview.sprite = stage_preview_list[5];
        }
        else
        {
            stage_preview.sprite = stage_preview_list[int.Parse(buttonName) - 1];
        }
    }

    public void touch_start_button()
    {
        
        switch (buttonName)
        {
            case "1":
                SceneManager.LoadScene("Takumi");
                break;
            case "2":
                SceneManager.LoadScene("Takumi 1");
                break;
            case "3":
                SceneManager.LoadScene("Takumi 2");
                break;
            case "4":
                SceneManager.LoadScene("Takumi 3");
                break;
            case "5":
                SceneManager.LoadScene("Takumi4");
                break;
            case "TUTORIAL":
                SceneManager.LoadScene("Tutorial");
                break;

            default:
                break;
        }
    }
}
