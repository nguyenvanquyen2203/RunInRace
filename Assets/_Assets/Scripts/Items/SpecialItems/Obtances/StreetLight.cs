public class StreetLight : RaceObj
{
    private LightSwitch lightSw;
    private void Awake()
    {
        lightSw = GetComponent<LightSwitch>();
    }
    public void StartRaceObj()
    {
        if (!GameModeManager.Instance.IsDay()) lightSw.ActiveLight();
    }
    public override void ActiveRaceObj(MapSetUp _setUp)
    {
        base.ActiveRaceObj(_setUp);
        setUp.gameObject.GetComponent<MapController>().AddRaceObject(StartRaceObj);
    }
}
