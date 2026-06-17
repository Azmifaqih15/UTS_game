using UnityEngine;
using System.Collections;

public class CarNitro : MonoBehaviour
{
    public float normalSpeed = 1000f;
    public float nitroSpeed = 3000f;

    public float nitroDuration = 3f;

    public ParticleSystem nitroFlame;

    private Rigidbody rb;

    private bool isNitroActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (nitroFlame != null)
        {
            nitroFlame.Stop();
        }
    }

    void Update()
    {
        if (MobileCarInput.nitroPressed && !isNitroActive)
        {
            StartCoroutine(ActivateNitro());
        }
    }

    void FixedUpdate()
    {
        float move = MobileCarInput.verticalInput;

        float speed = isNitroActive ? nitroSpeed : normalSpeed;

        rb.AddForce(transform.forward * move * speed * Time.fixedDeltaTime);
    }

    IEnumerator ActivateNitro()
    {
        isNitroActive = true;

        Debug.Log("Nitro Aktif");

        if (nitroFlame != null)
        {
            nitroFlame.Play();
        }

        yield return new WaitForSeconds(nitroDuration);

        isNitroActive = false;

        if (nitroFlame != null)
        {
            nitroFlame.Stop();
        }
    }
}