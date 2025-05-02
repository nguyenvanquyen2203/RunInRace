using UnityEngine;

public class DynamicObj : RaceObj
{
    public override void ActiveRaceObj()
    {
        gameObject.SetActive(true);
    }
}
