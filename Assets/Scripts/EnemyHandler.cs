using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public GameObject Projectile; // the projectile GameObject to clone
    public float FireDelay; // the speed at which the ship fires projectiles

    private float _fireTime = 0f; // the time since last projectile was fired
    private GameObject _newProjectile; // placeholder into which we clone new projectile objects

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
    }

    void HandleShooting()
    {
        _fireTime += Time.deltaTime;
        if (_fireTime > FireDelay)
        {
            _newProjectile = Instantiate(Projectile, transform.position, transform.rotation) as GameObject;
            _newProjectile.GetComponent<ProjectileHandler>().IsClone = true;
            _fireTime = 0.0F;
        }
    }
}
