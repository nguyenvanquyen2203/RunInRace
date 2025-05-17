public class ScoreBoost : ItemObj, IItem
{
    public void CollectEvent(PlayerCollection collector)
    {
        collector.CollectScoreBoost();
        AudioManager.Instance.PlaySFX("CollectItem");
        PowerUpInformation.Instance.ActivePowerUp("ScoreBoost");
        gameObject.SetActive(false);
    }
}
