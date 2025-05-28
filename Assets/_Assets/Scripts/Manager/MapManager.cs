using System.Collections.Generic;
using UnityEngine;
public class MapManager : MapSubject, IGameStateObserver
{
    private static MapManager instance;
    public static MapManager Instance { get { return instance; } }
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
    //Spawn Random Map
    public void SpawnMap(Vector3 spawnPos)
    {
        MapController map = RaceObjPoolCtrl.Instance.ActiveGround();
        map.ActiveMap(spawnPos, mapInfor[Random.Range(0, mapInfor.Count)], speed);
    }
    public void SpawnDefaultMap(Vector3 spawnPos)
    {
        MapController map = RaceObjPoolCtrl.Instance.ActiveGround();
        map.ActiveMap(spawnPos, mapInfor[mapInfor.Count - 1], speed);
        map.activeEvent?.Invoke();
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
    //Run Map - Call when play game  
    public void StartState()
    {
        StartRun();
    }
    //Stop Map - Call when game over
    public void OverState()
    {
        StopRun();
    }
}
