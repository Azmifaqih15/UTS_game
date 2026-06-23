using UnityEngine;

public class MobileCarInput : MonoBehaviour
{
    public static float horizontalInput;
    public static float verticalInput;

    public static bool isBraking;
    public static bool nitroPressed;

    // GAS
    public void GasDown()
    {
        verticalInput = 1f;
    }

    public void GasUp()
    {
        verticalInput = 0f;
    }

    // REM
    public void BrakeDown()
    {
        isBraking = true;
    }

    public void BrakeUp()
    {
        isBraking = false;
    }

    // KIRI
    public void LeftDown()
    {
        horizontalInput = -1f;
    }

    public void LeftUp()
    {
        horizontalInput = 0f;
    }

    // KANAN
    public void RightDown()
    {
        horizontalInput = 1f;
    }

    public void RightUp()
    {
        horizontalInput = 0f;
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