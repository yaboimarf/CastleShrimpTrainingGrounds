using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    Animator M_Animator;
    // Start is called before the first frame update
    void Start()
    {
        M_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            M_Animator.SetTrigger("Jump");
        }

        if (Input.GetKey(KeyCode.W))
        {
            M_Animator.SetTrigger("walk");
        }       
    }
}
