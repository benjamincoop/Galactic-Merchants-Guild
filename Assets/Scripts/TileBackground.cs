using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBackground : MonoBehaviour
{
    /// <summary>
    /// The player GameObject. Background is expanded depending on player position.
    /// </summary>
    public GameObject Player;
    /// <summary>
    /// The background GameObject to tile
    /// </summary>
    public GameObject Background;
    /// <summary>
    /// The distance between background tiles along the X axis
    /// </summary>
    public int OffsetX = 30;
    /// <summary>
    /// The distance between background tiles along the Y axis
    /// </summary>
    public int OffsetY = 15;
    /// <summary>
    /// The position of background tiles on the Z axis
    /// </summary>
    public int DepthLayer = 3;

    private int _backgroundLayers = 1;
    private GameObject _newTile;

    private float _time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }

        if (Background == null)
        {
            Background = GameObject.Find("Background");
        }

        // spawn initial background tiles
        ExpandBackground();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if(_time > 0.5f)
        {
            if(CheckForExpansion())
            {
                ExpandBackground();
            }

            _time = 0f;
        }
    }

    // Returns true if the background needs to be expanded
    bool CheckForExpansion()
    {
        if(Player == null) { return false; }

        if(Mathf.Abs(Vector3.Distance(Player.transform.position, Vector3.zero)) > (OffsetY / 2) * _backgroundLayers)
        {
            return true;
        }

        return false;
    }

    // Expands the radius of the background
    void ExpandBackground()
    {
        int tilesNeeded = 8 * _backgroundLayers;
        int count = 0;

        Vector3 upperLeft = new Vector3(-1 * OffsetX * _backgroundLayers, OffsetY * _backgroundLayers, DepthLayer);
        Vector3 lowerRight = new Vector3(OffsetX * _backgroundLayers, -1 * OffsetY * _backgroundLayers, DepthLayer);

        // upper left to upper right
        for(int i = 0; i <= tilesNeeded/4; i++)
        {
            _newTile = Instantiate(Background, new Vector3(upperLeft.x + (OffsetX * i), upperLeft.y, DepthLayer), Quaternion.identity) as GameObject;
            count++;
        }

        // upper left to lower left
        for (int i = 1; i < tilesNeeded / 4; i++)
        {
            _newTile = Instantiate(Background, new Vector3(upperLeft.x, upperLeft.y - (OffsetY * i), DepthLayer), Quaternion.identity) as GameObject;
            count++;
        }

        // lower right to lower left
        for (int i = 0; i <= tilesNeeded / 4; i++)
        {
            _newTile = Instantiate(Background, new Vector3(lowerRight.x - (OffsetX * i), lowerRight.y, DepthLayer), Quaternion.identity) as GameObject;
            count++;
        }

        // lower right to upper right
        for (int i = 1; i < tilesNeeded / 4; i++)
        {
            _newTile = Instantiate(Background, new Vector3(lowerRight.x, lowerRight.y + (OffsetY * i), DepthLayer), Quaternion.identity) as GameObject;
            count++;
        }

        _backgroundLayers++;
       // Debug.Log(count);
    }
}
