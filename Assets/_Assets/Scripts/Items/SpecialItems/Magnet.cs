public class Magnet : RaceObj, IItem
{
    public void CollectEvent(PlayerCollection collector)
    {
        collector.CollectMagnet(5f);
        gameObject.SetActive(false);
        PowerUpManager.Instance.ActivePowerUp("Magnet");
    }
}
