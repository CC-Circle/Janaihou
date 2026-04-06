using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.EventSystems;
using System;

public class Button_manage_ui : MonoBehaviour
{
    public GameObject current_pointer_obj;
    public TextMeshProUGUI stage_indication;
    public List<Sprite> stage_preview_list;
    public Image stage_preview;

    [SerializeField] Image transition_image;
    [SerializeField] float Duration = 0.5f;
    [SerializeField] float Start_Delay = 0.1f;
    [SerializeField] float Scene_change_Delay = 2f;

    [SerializeField] List<GameObject> stageButtons;   // 左から順に登録
    [SerializeField] float stickThreshold = 0.5f;     // スティック判定
    [SerializeField] float stickNeutralThreshold = 0.2f;

    string buttonName;
    int currentIndex = 0;
    bool stickInUse = false;
    bool isStarting = false;

    void Start()
    {
        stage_indication.text = "STAGE\nSELECT";
        stage_preview.sprite = stage_preview_list[5];

        if (stageButtons != null && stageButtons.Count > 0)
        {
            currentIndex = 0;
            SelectStage(currentIndex);
        }
    }

    void Update()
    {
        if (isStarting) return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizontal);
        // 左スティックを倒した瞬間だけ選択移動
        Debug.Log("Stick:" + stickInUse); 
        if (!stickInUse)
        {

            if (horizontal > stickThreshold)
            {
                Debug.Log("select:L");
                MoveSelection(1);
                stickInUse = true;
            }
            else if (horizontal < -stickThreshold)
            {
                Debug.Log("select:R");
                MoveSelection(-1);
                stickInUse = true;
            }
        }

        // スティックを中央に戻したら次の入力を許可
        if (Mathf.Abs(horizontal) < stickNeutralThreshold)
        {
            stickInUse = false;
        }

        // Fire2 で決定
        if (Input.GetButtonDown("Fire2"))
        {
            touch_start_button();
        }
    }

    void MoveSelection(int dir)
    {
        if (stageButtons == null ) return;

        currentIndex += dir;

        if (currentIndex < 0)
        {
            currentIndex = 0;
        }
        else if (currentIndex >= stageButtons.Count)
        {
            currentIndex = stageButtons.Count - 1;
        }

        SelectStage(currentIndex);
    }

    void SelectStage(int index)
    {
        Debug.Log("select:"+index);
        GameObject selectedButton = stageButtons[index];
        EventSystem.current.SetSelectedGameObject(selectedButton);

        buttonName = selectedButton.name;
        current_pointer_obj.transform.position = selectedButton.transform.position;
        stage_indication.text = $"STAGE\n{buttonName}";

        if (buttonName == "TUTORIAL")
        {
            stage_preview.sprite = stage_preview_list[5];
        }
        else
        {
            int stageIndex = int.Parse(buttonName) - 1;
            stage_preview.sprite = stage_preview_list[stageIndex];
        }
    }

    /// <summary>
    /// 選択時処理
    /// </summary>
    public void touch_stage_select()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        if (clickedButton == null) return;

        buttonName = clickedButton.name;
        current_pointer_obj.transform.position = clickedButton.transform.position;
        stage_indication.text = $"STAGE\n{buttonName}";

        for (int i = 0; i < stageButtons.Count; i++)
        {
            if (stageButtons[i] == clickedButton)
            {
                currentIndex = i;
                break;
            }
        }

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
        if (isStarting) return;
        isStarting = true;

        var sequence = DOTween.Sequence();

        DOVirtual.DelayedCall(
            Start_Delay,
            () => {
                sequence.Append(transition_image.DOFillAmount(1, Duration));
            }
        );

        DOVirtual.DelayedCall(
            Scene_change_Delay,
            () => {
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
                        isStarting = false;
                        break;
                }
            }
        );
    }
}