using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] Transform _weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    //[SerializeField] float weaponRotationSpeed = 2f;
    Transform _target;

    
    
    
    void Start()
    {
        _target = FindObjectOfType<Enemy>().transform;
    }
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            
            //float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            Vector3 directionVector = transform.position - enemy.transform.position;
            float targetDistance = directionVector.sqrMagnitude;

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }

        }
        _target = closestTarget;
    }
    void AimWeapon()
    {
        if(_target == null) { Attack(false); return;}
        
        float targetDistance = Vector3.Distance(transform.position, _target.position);

        _weapon.LookAt(_target);
        // Quaternion startRotation = _weapon.transform.rotation;
        // Quaternion endRotation = Quaternion.LookRotation(_target.position - _weapon.transform.position);
        // _weapon.transform.rotation = Quaternion.Lerp(startRotation, endRotation, Time.deltaTime * weaponRotationSpeed);

        bool isRange = targetDistance < range ? true : false;
        Attack(isRange);
        // if(targetDistance < range)
        // {
        //     Attack(true);
        // }
        // else
        // {
        //     Attack(false);
        // }
        
       
    }
    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
