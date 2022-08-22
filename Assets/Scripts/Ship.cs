using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // core ship stats
    public float Health;
    public float Shields;
    public float Fuel;

    public float MaxHealth;
    public float MaxShields;
    public float MaxFuel;

    public float FuelConsumptionRate;

    public float MoveSpeed; // translational speed scalar
    public float RotationSpeed; // rotational speed scalar

    public Weapon[] Weapons;
    public Collider2D Hitbox;

    private float _translation; // value of current translation
    private float _rotation; // value of current rotation

    // tracks the ships translation from one frame to the next
    // used to maintain the ship's translational movement independently of rotation (i.e. when drifting)
    private Vector3 _position;
    private Vector3 _lastPosition;

    public Rigidbody2D Rigidbody;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void Move(float inputX, float inputY)
    {
        // drift ship if it is out of fuel
        if (Fuel < 0)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(StaticData.PlayerSpriteFileName);
            Rigidbody.drag = StaticData.PlayerDriftSpeedScalar;
            Rigidbody.angularDrag = StaticData.PlayerDriftSpeedScalar;

            // manually drift ship in a straight line (independent of rotation)
           // transform.position = new Vector3(
          //      transform.position.x + (StaticData.PlayerDriftSpeedScalar * (_position.x - _lastPosition.x)),
         //       transform.position.y + (StaticData.PlayerDriftSpeedScalar * (_position.y - _lastPosition.y)), 0
        //    );
        //    transform.Rotate(0, 0, _rotation);

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
            //transform.Translate(0, _translation, 0);
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
        //transform.Rotate(0, 0, _rotation);
        Rigidbody.AddTorque(_rotation, ForceMode2D.Impulse);

        // save last movement
        _lastPosition = _position;
        _position = transform.position;
    }
}
