using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Projectile; // the projectile GameObject to clone
    public float FireRate; // the speed at which the ship fires projectiles
    public float Damage; // the projectile's base damage
    public float MoveSpeed; // the speed of the projectile
    public float TimeToLive; // the maximum length of time that the projectile can exist

    private float _fireTime = 0f; // the time since last projectile was fired
    private GameObject _newProjectile; // placeholder into which we clone new projectile objects

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _fireTime += Time.deltaTime;
    }

    public void FireWeapon()
    {
        if (_fireTime > FireRate)
        {
            _newProjectile = Instantiate(Projectile, transform.position, transform.rotation) as GameObject; // duplicate projectile sprite

            // apply properties to projectile based on weapon
            Projectile projectile = _newProjectile.GetComponent<Projectile>();
            projectile.SetIsClone(true);
            projectile.SetDamage(Damage);
            projectile.SetMoveSpeed(MoveSpeed);
            projectile.SetTimeToLive(TimeToLive);

            _fireTime = 0f;
        }
    }
}
