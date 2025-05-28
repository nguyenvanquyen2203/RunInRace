using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaceObjPoolCtrl : MonoBehaviour
{
    private static RaceObjPoolCtrl instance;
    public static RaceObjPoolCtrl Instance { get { return instance; } }
    public List<RaceObject> raceObjs;
    public List<ItemObject> itemObjs;
    public MapController ground;
    //public int numberPool;
    private Dictionary<string, Queue<RaceObj>> racePools = new Dictionary<string, Queue<RaceObj>>();
    private Dictionary<string, List<ItemObj>> itemPools = new Dictionary<string, List<ItemObj>>();
    private Queue<MapController> grounds = new Queue<MapController>();
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        foreach (var raceObj in raceObjs)
        {
            CreateRacePool(raceObj);
        }
        foreach (var itemObj in itemObjs)
        {
            CreateItemPool(itemObj);
        }
        for (int i = 0; i < 10; i++)
        {
            MapController map = Instantiate(ground, transform);
            map.gameObject.SetActive(false);
            map.gameObject.name = i.ToString();
            grounds.Enqueue(map);
        }
    }
    private RaceObj GetRaceObject(string nameRaceObj)
    {
        if (racePools.TryGetValue(nameRaceObj, out Queue<RaceObj> value))
        {
            if (value.Count <= 0) CreateRacePool(nameRaceObj, 1);
            return value.Dequeue();
        }
        else Debug.LogError("Existn't race object with name " + nameRaceObj);
        return null;
    }
    private ItemObj GetItemObject(string nameRaceObj)
    {
        if (itemPools.TryGetValue(nameRaceObj, out List<ItemObj> value))
        {
            if (value.Count <= 0) CreateItemPool(nameRaceObj, 1);
            ItemObj temp = value[0];
            value.RemoveAt(0);
            return temp;
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
                listRaceObj.Enqueue(raceObject);
            }
        }
    }
    private void CreateItemPool(ItemObject itemObj)
    {
        if (itemPools.ContainsKey(itemObj.nameGO)) Debug.LogError($"Exist race object with name {itemObj.nameGO}, can't create race Obj pool");
        else
        {
            List<ItemObj> listRaceObj = new List<ItemObj>();
            itemPools.Add(itemObj.nameGO, listRaceObj);
            for (int i = 0; i < itemObj.numberPool; i++)
            {
                ItemObj raceObject = Instantiate(itemObj.go, transform);
                raceObject.SetName(itemObj.nameGO);
                raceObject.gameObject.SetActive(false);
                listRaceObj.Add(raceObject);
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
    private void CreateItemPool(string nameItemObj, int number)
    {
        if (!itemPools.ContainsKey(nameItemObj)) Debug.LogError("Existn't race object with name " + nameItemObj);
        else
        {
            ItemObject itemObj = itemObjs.FirstOrDefault(e => e.nameGO == nameItemObj);
            if (itemPools.TryGetValue(itemObj.nameGO, out List<ItemObj> value))
            {
                for (int i = 0; i < number; i++)
                {
                    ItemObj itemObject = Instantiate(itemObj.go, transform);
                    itemObject.SetName(itemObj.nameGO);
                    itemObject.gameObject.SetActive(false);
                    Material material = itemObjs.Find(x => x.nameGO == nameItemObj).glowM;
                    if (GameModeManager.Instance.IsDay()) material = itemObjs.Find(x => x.nameGO == nameItemObj).nonGlowM;
                    itemObject.SetMaterial(material);
                    value.Add(itemObject);
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
    public ItemObj ActiveItemObject(string nameRaceObj, Vector3 activePos, Transform parent, MapSetUp setUp)
    {
        ItemObj itemObj = GetItemObject(nameRaceObj);
        itemObj.transform.parent = parent;
        itemObj.transform.localPosition = activePos;
        itemObj.ActiveRaceObj(setUp);
        return itemObj;
    }
    public void AddPool(RaceObj raceObj)
    {
        if (!racePools.ContainsKey(raceObj.GetName())) Debug.LogError($"Exist race object with name {raceObj.GetName()}, can't add race Obj to pool");
        else
        {
            raceObj.gameObject.SetActive(false);
            racePools[raceObj.GetName()].Enqueue(raceObj);
        }
    }
    public void AddPool(ItemObj itemObj)
    {
        if (!itemPools.ContainsKey(itemObj.GetName())) Debug.LogError($"Exist race object with name {itemObj.GetName()}, can't add race Obj to pool");
        else
        {
            itemObj.gameObject.SetActive(false);
            itemPools[itemObj.GetName()].Add(itemObj);
        }
    }
    public void AddGround(MapController _map)
    {
        grounds.Enqueue(_map);
    }
    public MapController ActiveGround()
    {
        return grounds.Dequeue();
    } 
    public void ChangeGlow(GameModeManager.ModeType modeType)
    {
        if (modeType == GameModeManager.ModeType.DayMode)
        {
            foreach (var items in itemPools)
            {
                Material material = itemObjs.Find(x => x.nameGO == items.Key).nonGlowM;
                foreach (var item in items.Value) item.SetMaterial(material);
            }
        }
        else
        {
            foreach (var items in itemPools)
            {
                Material material = itemObjs.Find(x => x.nameGO == items.Key).glowM;
                foreach (var item in items.Value) item.SetMaterial(material);
            }
        }
    }
}
