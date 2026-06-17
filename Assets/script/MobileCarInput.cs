using UnityEngine;

public class MobileCarInput : MonoBehaviour
{
    public static float throttleInput;
    public static float steeringInput;
    public static bool nitroPressed;
    public static float verticalInput;


    // GAS
    public void GasDown()
    {
        throttleInput = 1f;
    }

    public void GasUp()
    {
        throttleInput = 0f;
    }

    // BRAKE
    public void BrakeDown()
    {
        throttleInput = -1f;
    }

    public void BrakeUp()
    {
        throttleInput = 0f;
    }

    // LEFT
    public void LeftDown()
    {
        steeringInput = -1f;
    }

    public void LeftUp()
    {
        steeringInput = 0f;
    }

    // RIGHT
    public void RightDown()
    {
        steeringInput = 1f;
    }

    public void RightUp()
    {
        steeringInput = 0f;
    }

    // NITRO
    public void NitroDown()
    {
        nitroPressed = true;
    }

    public void NitroUp()
    {
        nitroPressed = false;
    }
}