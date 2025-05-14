using UnityEngine;

public class PlayerContact : MonoBehaviour
{
    PlayerState state;
    private void Awake()
    {
        state = GetComponent<PlayerState>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obtance"))
        {
            if (collision.GetContact(0).normal.z > -.5f) return;
            if (state.IsShield())
            {
                AudioManager.Instance.PlaySFX("DestroyItem");
                GameManager.Instance.ActiveExplostion(collision.transform.position);
                collision.gameObject.SetActive(false);
                state.DisableShiled();
                //return;
            }
            else state.Death();
        }
    }
}
