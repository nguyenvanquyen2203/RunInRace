using UnityEngine;
using UnityEngine.Events;

public class MapMove : MonoBehaviour, IObserver
{
    private float mapSpeed = 1;
    private Vector3 direction;
    private Vector3 startPos = Vector3.up;
    public UnityEvent activeEvent;
    public void Intinialize(float speed, Vector3 pos)
    {
        mapSpeed = speed;
        startPos = pos;
        transform.position = startPos;
        //controller.AddObserver(this);
    }
    // Start is called before the first frame update
    private void Awake()
    {
        direction = Vector3.back;
        mapSpeed = 5;
    }
    private void OnEnable()
    {
        //activeEvent?.Invoke();
        //manager.AddObserver(this);
    }
    private void FixedUpdate()
    {
        if (transform.position.z < -10f) Disable();
        transform.position += direction * mapSpeed * Time.fixedDeltaTime;
    }
    private void Disable()
    {
        /*manager.AddMapPool(this);
        manager.SpawnMap(transform.position + direction * -30f);
        manager.RemoveObserver(this);*/
        gameObject.SetActive(false);
    }

    public void Notify()
    {
        mapSpeed = 0;
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