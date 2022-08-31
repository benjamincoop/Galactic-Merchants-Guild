using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    public static float PlayerDriftSpeedScalar = 0.05f;
    public static float PlayerMaxFuel = 100.0f;

    public static float PlayerRightTurnAnimThreshold = 0.0005f;
    public static float PlayerLeftTurnAnimThreshold = -0.0005f;

    public static string BackgroundSpriteFileName = "Art/Environment/bg_stars";

    public static string PlayerSpriteFileName = "Art/Player/tiny_ship";
    public static string PlayerForwardSpriteFileName = "Art/Player/tiny_ship_both_thrusters";
    public static string PlayerLeftTurnSpriteFileName = "Art/Player/tiny_ship_left_thruster";
    public static string PlayerRightTurnSpriteFileName = "Art/Player/tiny_ship_right_thruster";

}