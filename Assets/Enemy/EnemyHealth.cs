using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints = 0;
    Enemy _enemy;
    
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    private void Start() 
    {
        _enemy = GetComponent<Enemy>(); //Aynı objelerse GetCompenent
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
    }
    void ProcessHit()
    {
        currentHitPoints--;
        if(currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            _enemy.RewardGold();
        }
    }
}
