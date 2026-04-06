using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    void Start()
    {
        //Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
        // フルスクリーンにしたい場合は↓
         Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen);
    }
}