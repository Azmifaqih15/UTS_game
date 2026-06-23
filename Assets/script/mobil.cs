using UnityEngine;

public class mobil : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBrakeForce;
    private float currentMotorForce;
    private bool isBraking;
    private bool nitroPressed;
    private Rigidbody rb;
    

    // =========================
    // SETTINGS
    // =========================
    [Header("Car Settings")]
    [SerializeField] private float normalMotorForce = 1500f;
    [SerializeField] private float nitroMotorForce = 2500f;
    [SerializeField] private float brakeForce = 3000f;
    [SerializeField] private float maxSteerAngle = 30f;
    [SerializeField] private ParticleSystem nitroFlame;

    // =========================
    // WHEEL COLLIDERS
    // =========================
    [Header("Wheel Colliders")]
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    // =========================
    // WHEEL VISUALS
    // =========================
    [Header("Wheel Transforms")]
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private void Start()
    {
        currentMotorForce = normalMotorForce;

        if (nitroFlame != null)
        {
            nitroFlame.Stop();
        }
    }

    private void FixedUpdate()
    {
        // Cek apakah balapan sudah dimulai
        if (!RaceCountdown.raceStarted)
        {
            rearLeftWheelCollider.motorTorque = 0;
            rearRightWheelCollider.motorTorque = 0;

            frontLeftWheelCollider.brakeTorque = brakeForce;
            frontRightWheelCollider.brakeTorque = brakeForce;
            rearLeftWheelCollider.brakeTorque = brakeForce;
            rearRightWheelCollider.brakeTorque = brakeForce;

            return;
        }

        GetInput();

        // Nitro ON/OFF
        if (MobileCarInput.nitroPressed)
        {
            currentMotorForce = nitroMotorForce;

            if (nitroFlame != null && !nitroFlame.isPlaying)
            {
                nitroFlame.Play();
            }
        }
        else
        {
            currentMotorForce = normalMotorForce;

            if (nitroFlame != null && nitroFlame.isPlaying)
            {
                nitroFlame.Stop();
            }
        }

        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    // =========================
    // INPUT
    // =========================
    private void GetInput()
    {
        if (!RaceCountdown.raceStarted)
        {
            horizontalInput = 0f;
            verticalInput = 0f;
            isBraking = true;
            return;
        }

        horizontalInput = MobileCarInput.horizontalInput;
        verticalInput = MobileCarInput.verticalInput;

        isBraking = MobileCarInput.isBraking;
    }

    // =========================
    // MOTOR
    // =========================
    private void HandleMotor()
    {
        // RWD (penggerak belakang)
        rearLeftWheelCollider.motorTorque = verticalInput * currentMotorForce;
        rearRightWheelCollider.motorTorque = verticalInput * currentMotorForce;

        // Brake
        currentBrakeForce = isBraking ? brakeForce : 0f;

        ApplyBraking();
    }

    // =========================
    // BRAKING
    // =========================
    private void ApplyBraking()
    {
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        frontRightWheelCollider.brakeTorque = currentBrakeForce;

        rearLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;
    }

    // =========================
    // STEERING
    // =========================
    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;

        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    // =========================
    // UPDATE WHEELS
    // =========================
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);

        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        // Ambil posisi & rotasi WheelCollider
        wheelCollider.GetWorldPose(out pos, out rot);

        // Update posisi roda
        wheelTransform.position = pos;

        // FIX roda kanan terbalik
        if (wheelTransform.name.Contains("FR") || wheelTransform.name.Contains("RR"))
        {
            wheelTransform.rotation = rot * Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            wheelTransform.rotation = rot;
        }
    }
}