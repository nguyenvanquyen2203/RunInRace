using UnityEngine;

public class ParticleChild : MonoBehaviour
{
    private ParticleEffects ctrl;
    private ParticleSystem pS;
    private void Awake()
    {
        pS = GetComponent<ParticleSystem>();
    }
    public void SetCtrl(ParticleEffects _ctrl) => ctrl = _ctrl;
    public void ActiveParticle()
    {
        gameObject.SetActive(true);
        pS.Play();
    }
    private void OnDisable() => ctrl.AddParticle();
}
