public class Magnet : RaceObj, IItem
{
    public void CollectEvent(PlayerCollection collector)
    {
        collector.CollectMagnet();
        gameObject.SetActive(false);
        PowerUpInformation.Instance.ActivePowerUp("Magnet");
    }
}
