using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{

    public GameObject PlayerCamera;

    public GameObject Projectile; // the projectile GameObject to clone
    public float PlayerFireDelay; // the speed at which player ship fires projectiles

    // ship speed scalars
    public float PlayerMovementSpeed;
    public float PlayerRotationSpeed;

    private float _fireTime = 0f; // the time since last projectile was fired
    private GameObject _newProjectile; // placeholder into which we clone new projectile objects

    private bool _mapMode = false; // hi/low camera zoom level

    // the current motion of the ship
    private float _translation;
    private float _rotation;

    // tracks the ships translation from one frame to the next
    // used to maintain the ship's translational movement independently of rotation (i.e. when drifting)
    private Vector3 _position;
    private Vector3 _lastPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Paused)
        {
            return;
        }

        HandleShooting();
        HandleMovement();

        if(Input.GetKeyDown("m"))
        {
            if(_mapMode)
            {
                PlayerCamera.GetComponent<Camera>().orthographicSize = 10;
                _mapMode = false;
            } else
            {
                PlayerCamera.GetComponent<Camera>().orthographicSize = 60;
                _mapMode = true;
            }
        }
    }

    void HandleMovement()
    {

        if(GameManager.Instance.Fuel < 0)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(StaticData.PlayerSpriteFileName);

            // manually drift ship in a straight line (independent of rotation)
            transform.position = new Vector3(
                transform.position.x + (StaticData.PlayerDriftSpeedScalar * (_position.x - _lastPosition.x)),
                transform.position.y + (StaticData.PlayerDriftSpeedScalar * (_position.y - _lastPosition.y)), 0
            );
            transform.Rotate(0, 0, _rotation);

            return;
        }

        _translation = Input.GetAxis("Vertical") * PlayerMovementSpeed * Time.deltaTime;
        _rotation = Input.GetAxis("Horizontal") * PlayerRotationSpeed * Time.deltaTime;

        if(_translation != 0)
        {
            GameManager.Instance.Fuel -= StaticData.PlayerFuelConsumptionRate * Time.deltaTime;
        }

        if (_translation > 0)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(StaticData.PlayerForwardSpriteFileName);
            transform.Translate(0, _translation, 0);
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
        transform.Rotate(0, 0, _rotation);

        _lastPosition = _position;
        _position = transform.position;
    }

    void HandleShooting()
    {
        _fireTime += Time.deltaTime;
        if (_fireTime > PlayerFireDelay && Input.GetButton("Fire1") && GameManager.Instance.Fuel > 0)
        {
            _newProjectile = Instantiate(Projectile, transform.position, transform.rotation) as GameObject;
            _newProjectile.GetComponent<ProjectileHandler>().IsClone = true;
            _fireTime = 0.0F;
        }
    }
}