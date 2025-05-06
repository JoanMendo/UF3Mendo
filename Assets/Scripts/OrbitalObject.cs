using UnityEngine;

public class OrbitAtFixedRadius : MonoBehaviour
{

    public Transform targetToOrbit;


    public float rotationSpeed = 50f;


    public float orbitRadius = 3f;

    private bool isOrbiting = false;
    private float currentAngle = 0f;

    void Update()
    {
        if (isOrbiting && targetToOrbit != null)
        {
            currentAngle += rotationSpeed * Time.deltaTime;
            float radians = currentAngle * Mathf.Deg2Rad;

            // Calcula la nueva posición con respecto al centro y radio
            Vector3 offset = new Vector3(Mathf.Sin(radians), 0.5f, Mathf.Cos(radians)) * orbitRadius;
            transform.position = targetToOrbit.position + offset;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == targetToOrbit)
        {
            StartOrbit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == targetToOrbit)
        {
            StartOrbit();
        }
    }

    private void StartOrbit()
    {
        if (targetToOrbit == null) return;

        isOrbiting = true;

        // Calcular el ángulo inicial respecto al target
        Vector3 direction = (transform.position - targetToOrbit.position).normalized;
        currentAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Reubicar al objeto en el radio exacto
        transform.position = targetToOrbit.position + direction * orbitRadius;
    }
}
