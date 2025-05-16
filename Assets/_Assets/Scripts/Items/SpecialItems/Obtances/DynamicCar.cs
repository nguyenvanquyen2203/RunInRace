using UnityEngine;

public class DynamicCar : RaceObj
{
    public float speed;
    private float _speed = 0;
    private void FixedUpdate()
    {
        transform.position += Vector3.back * _speed * Time.fixedDeltaTime;
    }
    public override void StartRaceObj()
    {
        base.StartRaceObj();
        _speed = speed;
    }
    public override void ActiveRaceObj(MapSetUp _setUp)
    {
        base.ActiveRaceObj(_setUp);
        _speed = 0;
    }
}
