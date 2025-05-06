using UnityEngine;

public class MapController : MonoBehaviour, IMapObserver
{
    private MapSetUp mapSetup;
    private float mapSpeed;
    private void Awake()
    {
        mapSetup = GetComponent<MapSetUp>();
        if (mapSetup == null) mapSetup = gameObject.AddComponent<MapSetUp>();
    }
    public void ActiveMap(Vector3 pos, MapInfor mapInfor, float speed)
    {
        mapSpeed = speed;
        gameObject.SetActive(true);
        transform.localPosition = pos;
        mapSetup.ActiveMap(mapInfor);
        _MapManager.Instance.AddObserver(this);
    }
    private void FixedUpdate()
    {
        //if (transform.position.z < -10f) DisableMap();
        transform.position += Vector3.back * mapSpeed * Time.fixedDeltaTime;
        if (transform.position.z < -10f)
        {
            _MapManager.Instance.SpawnMap(transform.position + Vector3.forward * 39f);
            DisableMap();
        }
    }
    public void DisableMap()
    {
        mapSetup.DisableMap();
        RaceObjPoolCtrl.Instance.AddGround(this);
        _MapManager.Instance.RemoveObserver(this);
        gameObject.SetActive(false);
    }
    public void StopRun() => mapSpeed = 0f;
    public void SetSpeed(float newSpeed)
    {
        mapSpeed = newSpeed;
    }

    public void Clear()
    {
        Debug.LogWarning("Disable Map " + gameObject.name);
        mapSetup.DisableMap();
        RaceObjPoolCtrl.Instance.AddGround(this);
        gameObject.SetActive(false);
    }
}
