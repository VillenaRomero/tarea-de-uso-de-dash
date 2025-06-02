using UnityEngine;
using UnityEngine.UI;

public class playermoved : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float rotationSpeed = 5f;

    [Header("Vida")]
    [SerializeField] private int currentLife = 20;

    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;

    [Header("Dash")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.3f;
    public float dashCooldown = 1f;
    public float dashStaminaCost = 25f;

    [Header("Estamina")]
    public float stamina = 100f;
    public float maxStamina = 100f;
    public float staminaRegenRate = 15f;
    public Slider staminaSlider;

    // Internos
    private bool isDashing = false;
    private float dashTimeLeft = 0f;
    private float lastDashTime = -999f;

    void Start()
    {
        if (staminaSlider != null)
        {
            staminaSlider.maxValue = maxStamina;
            staminaSlider.value = stamina;
        }
    }

    void Update()
    {
        if (isDashing)
        {
            DoDash();
        }
        else
        {
            Moved();
            PlayerRotation();
            RegenerateStamina();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)&& !isDashing&& stamina >= dashStaminaCost&& Time.time >= lastDashTime + dashCooldown)
        {
            StartDash();
        }

        UpdateStaminaUI();

        if (Input.GetKeyDown(KeyCode.R))
        {
            Fire();
        }
    }

    void Moved()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) direction += transform.forward;
        if (Input.GetKey(KeyCode.S)) direction -= transform.forward;
        if (Input.GetKey(KeyCode.A)) direction -= transform.right;
        if (Input.GetKey(KeyCode.D)) direction += transform.right;

        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    void PlayerRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * rotationSpeed, 0f);
    }

    void StartDash()
    {
        isDashing = true;
        dashTimeLeft = dashDuration;
        stamina -= dashStaminaCost;
        lastDashTime = Time.time;
    }

    void DoDash()
    {
        transform.position += transform.forward * dashSpeed * Time.deltaTime;
        dashTimeLeft -= Time.deltaTime;

        if (dashTimeLeft <= 0f)
        {
            isDashing = false;
        }
    }

    void RegenerateStamina()
    {
        if (stamina < maxStamina)
        {
            stamina += staminaRegenRate * Time.deltaTime;
            if (stamina > maxStamina) stamina = maxStamina;
        }
    }

    void UpdateStaminaUI()
    {
        if (staminaSlider != null)
        {
            staminaSlider.value = stamina;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletForce;
    }

    public void TakeDamage() => currentLife--;
    public void TakeDamage(int damage) => currentLife -= damage;
}