using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public Ship PlayerShip;

    public GameObject Base;
    public GameObject HealthBarEmpty;
    public GameObject HealthBarFill;
    public GameObject HealthBarCap;
    public GameObject FuelBarEmpty;
    public GameObject FuelBarFill;
    public GameObject FuelBarCap;
    public GameObject ShieldBarEmpty;
    public GameObject ShieldBarFill;
    public GameObject ShieldBarCap;

    private float _baseWidth;
    private float _capWidth;

    private SpriteRenderer _healthBarEmptySprite;
    private SpriteRenderer _fuelBarEmptySprite;
    private SpriteRenderer _shieldBarEmptySprite;

    private SpriteRenderer _healthBarFillSprite;
    private SpriteRenderer _fuelBarFillSprite;
    private SpriteRenderer _shieldBarFillSprite;

    // Start is called before the first frame update
    void Start()
    {
        _baseWidth = Base.GetComponent<SpriteRenderer>().size.x * Base.transform.localScale.x;
        _capWidth = HealthBarCap.GetComponent<SpriteRenderer>().size.x * HealthBarCap.transform.localScale.x;

        _healthBarEmptySprite = HealthBarEmpty.GetComponent<SpriteRenderer>();
        _fuelBarEmptySprite = FuelBarEmpty.GetComponent<SpriteRenderer>();
        _shieldBarEmptySprite = ShieldBarEmpty.GetComponent<SpriteRenderer>();

        _healthBarFillSprite = HealthBarFill.GetComponent<SpriteRenderer>();
        _fuelBarFillSprite = FuelBarFill.GetComponent<SpriteRenderer>();
        _shieldBarFillSprite = ShieldBarFill.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // scale health bars
        HealthBarEmpty.transform.localScale = new Vector3(PlayerShip.MaxHealth / 10, 3, 1);
        HealthBarFill.transform.localScale = new Vector3(PlayerShip.Health / 10, 3, 1);

        // calculate new health bar positions
        float healthBarEmptyBarSize = _healthBarEmptySprite.size.x * HealthBarEmpty.transform.localScale.x;
        float healthBarFillBarSize = _healthBarFillSprite.size.x * HealthBarFill.transform.localScale.x;
        HealthBarEmpty.transform.position = new Vector3(Base.transform.position.x + (_baseWidth / 2) + (healthBarEmptyBarSize / 2), HealthBarEmpty.transform.position.y, 1);
        HealthBarFill.transform.position = new Vector3(Base.transform.position.x + (_baseWidth / 2) + (healthBarFillBarSize / 2), HealthBarEmpty.transform.position.y, 0);
        HealthBarCap.transform.position = new Vector3(Base.transform.position.x + (_baseWidth / 2) + healthBarEmptyBarSize + (_capWidth / 2), HealthBarEmpty.transform.position.y, 0);

        // scale health bars
        FuelBarEmpty.transform.localScale = new Vector3(PlayerShip.MaxFuel / 10, 3, 1);
        FuelBarFill.transform.localScale = new Vector3(PlayerShip.Fuel / 10, 3, 1);

        // calculate new health bar positions
        float fuelBarEmptyBarSize = _fuelBarEmptySprite.size.x * FuelBarEmpty.transform.localScale.x;
        float fuelBarFillBarSize = _fuelBarFillSprite.size.x * FuelBarFill.transform.localScale.x;
        FuelBarEmpty.transform.position = new Vector3(Base.transform.position.x + (_baseWidth / 2) + (fuelBarEmptyBarSize / 2), FuelBarEmpty.transform.position.y, 1);
        FuelBarFill.transform.position = new Vector3(Base.transform.position.x + (_baseWidth / 2) + (fuelBarFillBarSize / 2), FuelBarEmpty.transform.position.y, 0);
        FuelBarCap.transform.position = new Vector3(Base.transform.position.x + (_baseWidth / 2) + fuelBarEmptyBarSize + (_capWidth / 2), FuelBarEmpty.transform.position.y, 0);
    }
}
