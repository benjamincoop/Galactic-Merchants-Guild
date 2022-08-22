using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        if (!GameManager.Instance.Paused)
        {
            base.Update();
            foreach(var weapon in Weapons)
            {
                weapon.FireWeapon();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(gameObject.name + " : " + Time.time);
    }
}
