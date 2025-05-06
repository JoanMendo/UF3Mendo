using UnityEngine;
using System.Collections.Generic;

public class TriggerSizeAndAnimatorModifier : MonoBehaviour
{
    public float reducedScaleFactor = 0.5f;
    public float increasedAnimatorSpeed = 2f;
    public float cooldown = 0.5f;

    private Dictionary<GameObject, OriginalState> originalStates = new Dictionary<GameObject, OriginalState>();
    private Dictionary<GameObject, float> lastToggleTime = new Dictionary<GameObject, float>();

    private class OriginalState
    {
        public Vector3 originalScale;
        public float originalAnimatorSpeed;
        public bool isReduced;
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleObject(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleObject(other.gameObject);
    }

    private void HandleObject(GameObject obj)
    {
        // Solo objetos con Rigidbody
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb == null) return;

        // Verificar cooldown
        if (lastToggleTime.ContainsKey(obj) && Time.time - lastToggleTime[obj] < cooldown)
            return;

        lastToggleTime[obj] = Time.time;

        // Obtener Animator
        Animator animator = obj.GetComponent<Animator>();

        // Guardar estado original si es necesario
        if (!originalStates.ContainsKey(obj))
        {
            originalStates[obj] = new OriginalState
            {
                originalScale = obj.transform.localScale,
                originalAnimatorSpeed = animator != null ? animator.speed : 1f,
                isReduced = false
            };
        }

        var state = originalStates[obj];

        // Cambiar estado
        if (!state.isReduced)
        {
            obj.transform.localScale = state.originalScale * reducedScaleFactor;
            if (animator != null)
                animator.speed = increasedAnimatorSpeed;
        }
        else
        {
            obj.transform.localScale = state.originalScale;
            if (animator != null)
                animator.speed = state.originalAnimatorSpeed;
        }

        state.isReduced = !state.isReduced;
    }
}
