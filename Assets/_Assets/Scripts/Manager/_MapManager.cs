using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MapManager : MapSubject, IGameStateObserver
{
    private static _MapManager instance;
    public static _MapManager Instance { get { return instance; } }
    public List<MapInfor> mapInfor;
    private float speed;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GameManager.Instance.AddObserver(this);
    }
    public void SpawnMap(Vector3 spawnPos)
    {
        MapController map = RaceObjPoolCtrl.Instance.ActiveGround();
        map.ActiveMap(spawnPos, mapInfor[Random.Range(0, mapInfor.Count)], speed);
    }
    public void SetMapSpeed(float newSpeed) => speed = newSpeed;
    public void StartRun()
    {
        SetSpeed(speed);
    }
    public void StopRun()
    {
        SetSpeed(0f);
    }

    public void StartState()
    {
        StartRun();
    }

    public void OverState()
    {
        StopRun();
    }
}
