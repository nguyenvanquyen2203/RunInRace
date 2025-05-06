public class CoinItem : RaceObj, IItem
{
    public int coinValue;
    public void CollectEvent(PlayerCollection collector)
    {
        collector.CollectCoin(coinValue);
        GameManager.Instance.GetCoin();
        AudioManager.Instance.PlaySFX("CollectCoin");
        DisableObj();
    }
    private void OnEnable()
    {
        CoinManager.Instance?.Register(this);
    }
    public override void DisableObj()
    {
        CoinManager.Instance.Unregister(this);
        base.DisableObj();
    }
}
