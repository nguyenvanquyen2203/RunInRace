using System.Collections.Generic;
using UnityEngine;

public class MapSetUp : MonoBehaviour
{
    private RaceObjPoolCtrl racePool;

    private List<RaceObj> raceObjs = new List<RaceObj>();
    private List<ItemObj> itemObjs = new List<ItemObj>();
    private void Awake()
    {
        racePool = RaceObjPoolCtrl.Instance;
    }
    public void ActiveMap(MapInfor mapInfor)
    {
        raceObjs.Clear();
        foreach (var raceObj in mapInfor.raceObjs)
        {
            raceObjs.Add(racePool.ActiveRaceObject(raceObj.raceObjName, raceObj.localPosition, transform, this));
        }
        foreach (var raceObj in mapInfor.itemObjs)
        {
            itemObjs.Add(racePool.ActiveItemObject(raceObj.raceObjName, raceObj.localPosition, transform, this));
        }
    }
    public void DisableMap()
    {
        foreach (var raceObj in raceObjs)
        {
            RaceObjPoolCtrl.Instance.AddPool(raceObj);
            raceObj.gameObject.SetActive(false);
        }
        raceObjs.Clear();
    }
    public void DisableObj(RaceObj obj)
    {
        RaceObjPoolCtrl.Instance.AddPool(obj);
        raceObjs.Remove(obj);
        obj.gameObject.SetActive(false);
    }
    public void DisableObj(ItemObj obj)
    {
        RaceObjPoolCtrl.Instance.AddPool(obj);
        itemObjs.Remove(obj);
        obj.gameObject.SetActive(false);
    }
}
