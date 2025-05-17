using UnityEngine;

public class DynamicCar : RaceObj
{
    public float speed;
    private float _speed = 0;
    private void FixedUpdate()
    {
        transform.position += Vector3.back * _speed * Time.fixedDeltaTime;
    }
    public void StartRaceObj()
    {
        _speed = speed;
    }
    public override void ActiveRaceObj(MapSetUp _setUp)
    {
        base.ActiveRaceObj(_setUp);
        setUp.gameObject.GetComponent<MapController>().AddRaceObject(StartRaceObj);
        _speed = 0;
    }
}
