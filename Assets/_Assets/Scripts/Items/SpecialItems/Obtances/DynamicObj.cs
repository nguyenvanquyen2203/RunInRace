using UnityEngine;

public class DynamicObj : RaceObj
{
    public override void ActiveRaceObj(MapSetUp _setUp)
    {
        gameObject.SetActive(true);
    }
}
