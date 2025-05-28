using UnityEngine;
using UnityEngine.Events;

public class MapController : MonoBehaviour, IMapObserver
{
    private int indexMap;
    private MapSetUp mapSetup;
    private float mapSpeed;
    [HideInInspector] public UnityEvent activeEvent;
    private void Awake()
    {
        mapSetup = GetComponent<MapSetUp>();
        if (mapSetup == null) mapSetup = gameObject.AddComponent<MapSetUp>();
    }
    public void SetIndex(int _index) => indexMap = _index;
    public void ActiveMap(Vector3 pos, MapInfor mapInfor, float speed)
    {
        mapSpeed = speed;
        gameObject.SetActive(true);
        transform.localPosition = pos;
        mapSetup.ActiveMap(mapInfor);
        MapManager.Instance.AddObserver(this);
    }
    private void FixedUpdate()
    {
        transform.position += Vector3.back * mapSpeed * Time.fixedDeltaTime;
        if (transform.position.z < -15f)
        {
            MapManager.Instance.SpawnMap(transform.position + Vector3.forward * 59f);
            DisableMap();
        }
    }
    public void DisableMap()
    {
        mapSetup.DisableMap();
        RaceObjPoolCtrl.Instance.AddGround(this, indexMap);
        MapManager.Instance.RemoveObserver(this);
        gameObject.SetActive(false);
        activeEvent.RemoveAllListeners();
    }
    public void StopRun() => mapSpeed = 0f;
    public void SetSpeed(float newSpeed)
    {
        mapSpeed = newSpeed;
    }

    public void Clear()
    {
        mapSetup.DisableMap();
        RaceObjPoolCtrl.Instance.AddGround(this, indexMap);
        gameObject.SetActive(false);
    }
    public void AddRaceObject(UnityAction action)
    {
        activeEvent.AddListener(action);
    }
    private void OnTriggerEnter(Collider other)
    {
        activeEvent?.Invoke();
    }
}
