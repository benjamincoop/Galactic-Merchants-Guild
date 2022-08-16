using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudHandler : MonoBehaviour
{
    public int HealthSegments = 8;
    public int ShieldSegments = 8;
    public int FuelSegments = 8;

    private GameObject[] _healthBar;
    private GameObject[] _shieldBar;
    private GameObject[] _fuelBar;

    private Sprite _fuelSegmentSprite;
    private Sprite _emptySegmentSprite;

    // Start is called before the first frame update
    void Start()
    {
        _healthBar = GameObject.FindGameObjectsWithTag("HealthBar");
        _fuelBar = GameObject.FindGameObjectsWithTag("FuelBar");
        
        _fuelSegmentSprite = Resources.Load<Sprite>(StaticData.HudFuelSegment);
        _emptySegmentSprite = Resources.Load<Sprite>(StaticData.HudEmptySegment);
}

    // Update is called once per frame
    void Update()
    {
        // calculate number of bar segments to fill and update the sprites
        int numFilledSegments = (int)(FuelSegments * (GameManager.Instance.Fuel / StaticData.PlayerMaxFuel));
        for(int i = 0; i < FuelSegments; i++)
        {
            if(i <= numFilledSegments)
            {
                _fuelBar[i].GetComponent<SpriteRenderer>().sprite = _fuelSegmentSprite;
            } else
            {
                _fuelBar[i].GetComponent<SpriteRenderer>().sprite = _emptySegmentSprite;
            }
        }
    }
}
