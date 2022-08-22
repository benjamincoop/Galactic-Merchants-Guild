using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    //public static float ProjectileMovementSpeed = 20.0f;

    //public static float PlayerMovementSpeed = 10.0f;
    //public static float PlayerRotationSpeed = -100.0f;
    public static float PlayerDriftSpeedScalar = 0.05f;
    //public static float PlayerFireDelay = 0.25f;
    public static float PlayerMaxFuel = 100.0f;
    //public static float PlayerFuelConsumptionRate = 10f;

    public static float PlayerRightTurnAnimThreshold = 0.0005f;
    public static float PlayerLeftTurnAnimThreshold = -0.0005f;

    public static string BackgroundSpriteFileName = "Art/Environment/bg_stars";

    public static string PlayerSpriteFileName = "Art/Player/tiny_ship";
    public static string PlayerForwardSpriteFileName = "Art/Player/tiny_ship_both_thrusters";
    public static string PlayerLeftTurnSpriteFileName = "Art/Player/tiny_ship_left_thruster";
    public static string PlayerRightTurnSpriteFileName = "Art/Player/tiny_ship_right_thruster";

    public static string HudHealthSegment = "Art/UI/red_fill_bar";
    public static string HudFuelSegment = "Art/UI/green_fill_bar";
    public static string HudEmptySegment = "Art/UI/bar_segment";

    public static string EnemyShipBroken1 = "Art/NPCs/Enemies/BrokenShip1";
    public static string EnemyShipBroken2 = "Art/NPCs/Enemies/BrokenShip2";
    public static string EnemyShipBroken3 = "Art/NPCs/Enemies/BrokenShip3";
    public static string EnemyShipBroken4 = "Art/NPCs/Enemies/BrokenShip4";
    public static string EnemyShipBroken5 = "Art/NPCs/Enemies/BrokenShip5";

}