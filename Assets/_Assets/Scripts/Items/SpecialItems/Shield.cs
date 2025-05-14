using UnityEngine;

public class Shield : MonoBehaviour
{
    private PlayerState playerState;
    private float activeTime;
    private void Start()
    {
        playerState = PlayerState.Instance;
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (activeTime <= 0) DisableShield();
        transform.position = playerState.transform.position + Vector3.up * 0.75f;
        activeTime -= Time.fixedDeltaTime;
    }
    public void ActiveShield(float uptime)
    {
        transform.position = playerState.transform.position + Vector3.up * 0.75f;
        gameObject.SetActive(true);
        activeTime = uptime;
        playerState.GetShiled();
        PowerUpInformation.Instance.ActivePowerUp("Shield");
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obtance")) return;
        if (collision.GetContact(0).normal.z > -.5f) return;
        if (activeTime > 0f)
        {
            AudioManager.Instance.PlaySFX("DestroyItem");
            GameManager.Instance.ActiveExplostion(collision.transform.position);
            collision.gameObject.SetActive(false);
            DisableShield();
        }
    }*/
    public void DisableShield()
    {
        //playerState.DisableShiled();
        activeTime = 0;
        gameObject.SetActive(false);
        PowerUpInformation.Instance.CancelPU("Shield");
        return;
    }
}