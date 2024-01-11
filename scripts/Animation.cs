using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        Transform childTransform = transform.Find("Joints");
        // Get the Animator component
        animator = childTransform.GetComponent<Animator>();
    }

    void ResetHitParameter()
    {
        // Set "Hit" back to false
        animator.SetBool("Hit", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
           animator.SetBool("Hit", true);
            // Invoke a method to set "Hit" back to false after 2 seconds
            Invoke("ResetHitParameter", 1.0f);
        }

    }
}
