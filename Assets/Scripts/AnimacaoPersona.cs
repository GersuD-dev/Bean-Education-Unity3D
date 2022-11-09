using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPersona : MonoBehaviour
{
    Animator animator;

    public static bool pulo;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Trampolim"))
        {
            animator.SetBool("Pulo", true);
        }
        else
        {
            animator.SetBool("Pulo", false);
        }
    }
}
