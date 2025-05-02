using UnityEngine;

public class DynamicCar : RaceObj
{
    public float speed;
    private void FixedUpdate()
    {
        transform.position += Vector3.back * speed * Time.fixedDeltaTime;
    }
}
