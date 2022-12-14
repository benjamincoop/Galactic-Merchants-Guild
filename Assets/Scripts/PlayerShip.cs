using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : Ship
{
    public int Money;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        Debug.Log(Money);
        if (!GameManager.Instance.Paused)
        {
            base.Update();

            Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            if (Input.GetButton("Fire1") && Fuel > 0)
            {
                foreach (var weapon in Weapons)
                {
                    weapon.FireWeapon();
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "EnemyProjectile":
            case "Asteroid":
                TakeHit(collider.gameObject.GetComponent<Projectile>());
                break;
            case "Pickup":
                switch(collider.gameObject.GetComponent<Pickup>().Type)
                {
                    case "Coin":
                        Money += 1;
                        break;
                    case "Fuel":
                        if (Fuel + 50 < MaxFuel)
                        {
                            Fuel += 50;
                        }
                        else
                        {
                            Fuel = MaxFuel;
                        }
                        break;
                }
                break;
        }
    }
}