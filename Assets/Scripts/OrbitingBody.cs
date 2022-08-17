using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingBody : MonoBehaviour
{
    public GameObject OrbitalParent;
    public Vector3 OrbitalRadius;
    public float OrbitalSpeed;
    public string PlanetName;

    private float _time = 0f;

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

        HandleMovement();
    }

    void HandleMovement()
    {
        Vector3 orbitalVector = Vector3.zero;

        _time += OrbitalSpeed * Time.deltaTime;
        transform.position = Vector3.Scale(new Vector3(Mathf.Cos(_time), Mathf.Sin(_time), 1), OrbitalRadius);

        if (OrbitalParent)
        {
            transform.position += new Vector3(OrbitalParent.transform.position.x, OrbitalParent.transform.position.y, 0);
        }
    }
}
