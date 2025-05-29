using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCoinManager : MonoBehaviour
{
    private MapSetUp setUp;
    private float speed;
    private float moveSpace;
    private float timeActive;
    int count = 0;
    int maxCount = 0;
    Vector3 spawnPos;
    int direction = 0;
    private void Awake()
    {
        setUp = GetComponent<MapSetUp>();
    }
    private void OnEnable()
    {
        if (setUp == null) setUp = GetComponent<MapSetUp>();
        moveSpace = 0;
        count = 0;
        speed = GameManager.Instance.GetSpeed();
        spawnPos = Vector3.zero + Vector3.forward * speed;
        maxCount = (int)((timeActive - 1) * speed) - 30;
        transform.position = Vector3.up * 6f;
        for (int i = 0; i < 30; i++) SpawnNextCoin();
    }
    public void ActiveAirCoin(float time)
    {
        timeActive = time;
        gameObject.SetActive(true);
    }
    private void FixedUpdate()
    {
        moveSpace += speed * Time.fixedDeltaTime;
        transform.position += speed * Vector3.back * Time.fixedDeltaTime;
        if (moveSpace >= 1f)
        {
            if (count <= maxCount)
            {
                count++;
                SpawnNextCoin();
                moveSpace -= 1;
            }
            else PlayerState.Instance.DisableRocket();
        } 
    }
    private void OnDisable()
    {
        setUp.DisableMap();
    }
    private void SpawnNextCoin()
    {
        if (Mathf.Abs(spawnPos.x) != 1.25f) direction = (int)Mathf.Round(Random.Range(-1f, 1f));
        spawnPos.x += direction * 1.25f;
        spawnPos.x = Mathf.Clamp(spawnPos.x, -2.5f, 2.5f);
        setUp.AddItem(RaceObjPoolCtrl.Instance.ActiveItemObject("Coin", spawnPos, transform, setUp));
        spawnPos.z += 1;
    }
}
