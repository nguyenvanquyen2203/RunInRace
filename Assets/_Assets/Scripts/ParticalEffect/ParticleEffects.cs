using System.Collections.Generic;
using UnityEngine;

public class ParticleEffects : MonoBehaviour
{
    public List<ParticleChild> pSes;
    private int countPar = 0;
    private float speed;
    public void Initialize()
    {
        foreach (var pS in pSes) pS.SetCtrl(this);
    }
    public void ActiveEffect(Vector3 pos, float _speed)
    {
        gameObject.SetActive(true); 
        countPar = 0;
        speed = _speed;
        transform.position = pos;
        foreach (var pS in pSes) pS.ActiveParticle();
        AudioManager.Instance.PlaySFX("Explosion");
    }
    public void AddParticle()
    {
        countPar++;
        //if (countPar == pSes.Count) gameObject.SetActive(false);
    }
    private void Awake()
    {
        Initialize();
    }
    private void FixedUpdate()
    {
        transform.position += Vector3.back * speed * Time.fixedDeltaTime;
    }
}
