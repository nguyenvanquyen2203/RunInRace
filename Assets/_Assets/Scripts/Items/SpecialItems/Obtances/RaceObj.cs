using UnityEngine;

public abstract class RaceObj : MonoBehaviour
{
    private string nameRaceObj;
    public void SetName(string nameRaceObj)
    {
        this.nameRaceObj = nameRaceObj;
    }
    public virtual void ActiveRaceObj()
    {
        gameObject.SetActive(true);
    }
    public string GetName() => nameRaceObj;
    protected virtual void OnDisable()
    {
        RaceObjPoolCtrl.Instance.AddPool(this);
        gameObject.SetActive(false);
    }
}
