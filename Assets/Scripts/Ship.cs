using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D Rigidbody;

    /// <summary>
    /// The current health of the ship
    /// </summary>
    public float Health;
    /// <summary>
    /// The maximum health the ship can have
    /// </summary>
    public float MaxHealth;
    /// <summary>
    /// The current shield level of the ship
    /// </summary>
    public float Shields;
    /// <summary>
    /// The maximum shield level the ship can have
    /// </summary>
    public float MaxShields;
    /// <summary>
    /// The current fuel level of the ship
    /// </summary>
    public float Fuel;
    /// <summary>
    /// The maximum fuel the ship can hold
    /// </summary>
    public float MaxFuel;
    /// <summary>
    /// The rate at which the ship consumes fuel while moving
    /// </summary>
    public float FuelConsumptionRate;
    /// <summary>
    /// The translational speed of the ship while moving
    /// </summary>
    public float MoveSpeed;
    /// <summary>
    /// The rotational speed of the ship while turning
    /// </summary>
    public float RotationSpeed;
    /// <summary>
    /// The Weapon objects the ship is equipped with
    /// </summary>
    public Weapon[] Weapons;

    private float _translation; // value of current translation
    private float _rotation; // value of current rotation

    // tracks the ships translation from one frame to the next
    // used to maintain the ship's translational movement independently of rotation (i.e. when drifting)
    private Vector3 _position;
    private Vector3 _lastPosition;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (Health < 1)
        {
            Particle.CreateParticle(StaticData.EnemyShipBroken1, transform.position, 2, 5, Random.insideUnitCircle.normalized * Random.value * 5, Random.value * 5);
            Particle.CreateParticle(StaticData.EnemyShipBroken2, transform.position, 2, 5, Random.insideUnitCircle.normalized * Random.value * 5, Random.value * 5);
            Particle.CreateParticle(StaticData.EnemyShipBroken3, transform.position, 2, 5, Random.insideUnitCircle.normalized * Random.value * 5, Random.value * 5);
            Particle.CreateParticle(StaticData.EnemyShipBroken4, transform.position, 2, 5, Random.insideUnitCircle.normalized * Random.value * 5, Random.value * 5);
            Particle.CreateParticle(StaticData.EnemyShipBroken5, transform.position, 2, 5, Random.insideUnitCircle.normalized * Random.value * 5, Random.value * 5);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log(Health);
        }
    }

    public void Move(float inputX, float inputY)
    {
        // drift ship if it is out of fuel
        if (Fuel < 0)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(StaticData.PlayerSpriteFileName);
            Rigidbody.drag = StaticData.PlayerDriftSpeedScalar;
            Rigidbody.angularDrag = StaticData.PlayerDriftSpeedScalar;

            return;
        }

        // calculate new movement
        _translation = inputX * MoveSpeed * Time.deltaTime;
        _rotation = inputY * RotationSpeed * Time.deltaTime;

        if (_translation != 0)
        {
            Fuel -= FuelConsumptionRate * Time.deltaTime;
        }

        if (_translation > 0)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(StaticData.PlayerForwardSpriteFileName);
            Rigidbody.AddForce(transform.up * _translation, ForceMode2D.Impulse);
        }
        else
        {
            if (_rotation > StaticData.PlayerRightTurnAnimThreshold)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(StaticData.PlayerRightTurnSpriteFileName);
            }
            else if (_rotation < StaticData.PlayerLeftTurnAnimThreshold)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(StaticData.PlayerLeftTurnSpriteFileName);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(StaticData.PlayerSpriteFileName);
            }
        }
        Rigidbody.AddTorque(_rotation, ForceMode2D.Impulse);

        // save last movement
        _lastPosition = _position;
        _position = transform.position;
    }
}
