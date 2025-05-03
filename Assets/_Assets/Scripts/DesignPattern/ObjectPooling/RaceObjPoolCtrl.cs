using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaceObjPoolCtrl : MonoBehaviour
{
    private static RaceObjPoolCtrl instance;
    public static RaceObjPoolCtrl Instance { get { return instance; } }
    public List<RaceObject> raceObjs;
    public MapController ground;
    //public int numberPool;
    private Dictionary<string, Queue<RaceObj>> racePools = new Dictionary<string, Queue<RaceObj>>();
    private Queue<MapController> grounds = new Queue<MapController>();
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        foreach (var raceObj in raceObjs)
        {
            CreateRacePool(raceObj);
        }
        for (int i = 0; i < 10; i++)
        {
            MapController map = Instantiate(ground, transform);
            map.gameObject.SetActive(false);
            grounds.Enqueue(map);
        }
    }
    public RaceObj GetRaceObject(string nameRaceObj)
    {
        if (racePools.TryGetValue(nameRaceObj, out Queue<RaceObj> value))
        {
            if (value.Count <= 0) CreateRacePool(nameRaceObj, 1);
            return value.Dequeue();
        }
        else Debug.LogError("Existn't race object with name " + nameRaceObj);
        return null;
    }
    private void CreateRacePool(RaceObject raceObj)
    {
        if (racePools.ContainsKey(raceObj.nameGO)) Debug.LogError($"Exist race object with name {raceObj.nameGO}, can't create race Obj pool");
        else
        {
            Queue<RaceObj> listRaceObj = new Queue<RaceObj>();
            racePools.Add(raceObj.nameGO, listRaceObj);
            for (int i = 0; i < raceObj.numberPool; i++)
            {
                RaceObj raceObject = Instantiate(raceObj.go, transform);
                raceObject.SetName(raceObj.nameGO);
                raceObject.gameObject.SetActive(false);
            }
        }
    }
    private void CreateRacePool(string nameRaceObj, int number)
    {
        if (!racePools.ContainsKey(nameRaceObj)) Debug.LogError("Existn't race object with name " + nameRaceObj);
        else
        {
            RaceObject raceObj = raceObjs.FirstOrDefault(e => e.nameGO == nameRaceObj);
            if (racePools.TryGetValue(raceObj.nameGO, out Queue<RaceObj> value))
            {
                for (int i = 0; i < number; i++)
                {
                    RaceObj raceObject = Instantiate(raceObj.go, transform);
                    raceObject.SetName(raceObj.nameGO);
                    raceObject.gameObject.SetActive(false);
                    value.Enqueue(raceObject);
                }
            }
        }
    }
    public RaceObj ActiveRaceObject(string nameRaceObj, Vector3 activePos, Transform parent, MapSetUp setUp)
    {
        RaceObj raceObj = GetRaceObject(nameRaceObj);
        raceObj.transform.parent = parent;
        raceObj.transform.localPosition = activePos;
        raceObj.ActiveRaceObj(setUp);
        return raceObj;
    }
    public void AddPool(RaceObj raceObj)
    {
        if (!racePools.ContainsKey(raceObj.GetName())) Debug.LogError($"Exist race object with name {raceObj.GetName()}, can't add race Obj to pool");
        else
        {
            racePools[raceObj.GetName()].Enqueue(raceObj);
        }
    }
    public void AddGround(MapController _map) => grounds.Enqueue(_map);
    public MapController ActiveGround() => grounds.Dequeue();
}
