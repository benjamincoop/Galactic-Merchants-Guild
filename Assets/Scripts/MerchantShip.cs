using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantShip : Ship
{
    public GameObject HealthBar;
    public bool IsHostile = false;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        HealthBar.transform.localScale = new Vector3(MaxHealth / 10, 0.5f, 1);
    }

    // Update is called once per frame
    new void Update()
    {
        if (!GameManager.Instance.Paused)
        {
            base.Update();

            // update size of healthbar
            HealthBar.transform.localScale = new Vector3(Health / 10, 0.5f, 1);

        }

        if(IsHostile)
        {
            HealthBar.SetActive(true);
        } else
        {
            HealthBar.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "PlayerProjectile":
                TakeHit(collider.gameObject.GetComponent<Projectile>());
                break;
        }
    }
}
