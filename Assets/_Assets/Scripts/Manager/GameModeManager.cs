using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    private static GameModeManager instance;
    public static GameModeManager Instance { get { return instance; } }
    public Camera mainCamera;
    public GameObject directionalLight;
    public enum ModeType
    {
        DayMode,
        NightMode
    }
    private ModeType gameMode = ModeType.DayMode;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    public void SetDayMode()
    {
        gameMode = ModeType.DayMode;
    }
    public void SetNightMode()
    {
        gameMode = ModeType.NightMode;
    }
    public bool IsDay() => gameMode == ModeType.DayMode;
    public void ChangeGameMode()
    {
        if (gameMode == ModeType.NightMode)
        {
            directionalLight.SetActive(false);
            mainCamera.clearFlags = CameraClearFlags.SolidColor;
            mainCamera.backgroundColor = Color.black;
        }
        else
        {
            directionalLight.SetActive(true);
            mainCamera.clearFlags = CameraClearFlags.Skybox;
            mainCamera.backgroundColor = new Color(217, 60, 47, 0);
        }
        RaceObjPoolCtrl.Instance.ChangeGlow(gameMode);
    }
    public ModeType GetCurrentMode() => gameMode;
}
