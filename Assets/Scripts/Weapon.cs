using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /// <summary>
    /// The projectile GameObject to clone
    /// </summary>
    public GameObject Projectile;
    /// <summary>
    /// the speed at which the ship fires projectiles
    /// </summary>
    public float FireRate;
    /// <summary>
    /// the projectile's base damage
    /// </summary>
    public float Damage;
    /// <summary>
    /// the speed of the projectile
    /// </summary>
    public float MoveSpeed;
    /// <summary>
    /// // the maximum length of time that the projectile can exist
    /// </summary>
    public float TimeToLive;
    /// <summary>
    /// the list of GameObject tags that denote valid collison targets for projectiles
    /// </summary>
    public string[] Targets;

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
            projectile.IsClone = true;
            projectile.Damage = Damage;
            projectile.MoveSpeed = MoveSpeed;
            projectile.TimeToLive = TimeToLive;
            projectile.Targets = Targets;

            _fireTime = 0f;
        }
    }
}
