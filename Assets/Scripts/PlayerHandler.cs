using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{

    public GameObject PlayerCamera;

    public GameObject Projectile;
    public float PlayerFireDelay;
    public float PlayerMovementSpeed;
    public float PlayerRotationSpeed;

    private float _fireTime = 0f;
    private GameObject _newProjectile;
    private bool _mapMode = false;

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
            return;
        }

        float translation = Input.GetAxis("Vertical") * PlayerMovementSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * PlayerRotationSpeed * Time.deltaTime;

        if(translation != 0 || rotation != 0)
        {
            GameManager.Instance.Fuel -= StaticData.PlayerFuelConsumptionRate * Time.deltaTime;
            Debug.Log(GameManager.Instance.Fuel);
        }

        if (translation > 0)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(StaticData.PlayerForwardSpriteFileName);
            transform.Translate(0, translation, 0);
        }
        else
        {
            if (rotation > StaticData.PlayerRightTurnAnimThreshold)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(StaticData.PlayerRightTurnSpriteFileName);
            }
            else if (rotation < StaticData.PlayerLeftTurnAnimThreshold)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(StaticData.PlayerLeftTurnSpriteFileName);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(StaticData.PlayerSpriteFileName);
            }
        }
        transform.Rotate(0, 0, rotation);
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