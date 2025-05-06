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
                collision.gameObject.SetActive(false);
                return;
            }
            state.Death();
        }
    }
}
