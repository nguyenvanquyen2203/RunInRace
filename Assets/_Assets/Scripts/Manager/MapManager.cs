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
    private Transform lastGround;
    //Spawn Random Map
    public void SpawnMap()
    {
        MapController map = RaceObjPoolCtrl.Instance.ActiveGround();
        map.ActiveMap(lastGround.position + Vector3.forward * 20f, mapInfor[Random.Range(0, mapInfor.Count)], speed);
        lastGround = map.transform;
    }
    public void SpawnDefaultMap()
    {
        for (int i = 0; i <= 2; i++)
        {
            MapController map = RaceObjPoolCtrl.Instance.ActiveGround();
            map.ActiveMap(Vector3.forward * i * 20f, mapInfor[mapInfor.Count - 1], speed);
            map.activeEvent?.Invoke();
            lastGround = map.transform;
        }
    }
    public void SetMapSpeed(float newSpeed)
    {
        speed = newSpeed;
        SetSpeed(speed);
    } 
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
