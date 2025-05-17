using UnityEngine;

public abstract class RaceObj : MonoBehaviour
{
    [HideInInspector] public MapSetUp setUp;
    protected string nameRaceObj;
    public void SetName(string nameRaceObj)
    {
        this.nameRaceObj = nameRaceObj;
    }
    public virtual void ActiveRaceObj(MapSetUp _setUp)
    {
        setUp = _setUp;
        //setUp.gameObject.GetComponent<MapController>().AddRaceObject(StartRaceObj);
        gameObject.SetActive(true);
    }
    public string GetName() => nameRaceObj;
    public virtual void DisableObj()
    {
        setUp.DisableObj(this);
    }
    //public virtual void StartRaceObj() { }
}
