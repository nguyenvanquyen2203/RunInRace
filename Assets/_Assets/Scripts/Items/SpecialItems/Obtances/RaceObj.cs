using UnityEngine;

public abstract class RaceObj : MonoBehaviour
{
    [HideInInspector] public MapSetUp setUp;
    private string nameRaceObj;
    public void SetName(string nameRaceObj)
    {
        this.nameRaceObj = nameRaceObj;
    }
    public virtual void ActiveRaceObj(MapSetUp _setUp)
    {
        setUp = _setUp;
        gameObject.SetActive(true);
    }
    public string GetName() => nameRaceObj;
    public virtual void DisableObj()
    {
        setUp.DisableObj(this);
        /*RaceObjPoolCtrl.Instance.AddPool(this);
        gameObject.SetActive(false);*/
    }
}
