using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    public ParticleSystem coinCollection;
    public MagnetZone magnetZone;
    public Shield shield;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Items"))
        {
            IItem item = other.GetComponent<IItem>();
            item.CollectEvent(this);
        }
    }
    public void CollectCoin(int coin)
    {
        coinCollection.Clear();
        coinCollection.Play();
    }
    public void CollectMagnet(float uptime)
    {
        magnetZone.gameObject.SetActive(true);
        CoinManager.Instance.SetTimeMagnet(uptime);
    }
    public void CollectShield(float uptime)
    {
        shield.gameObject.SetActive(true);
        shield.ActiveShield(uptime);
    }
}
