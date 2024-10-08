using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]Animator animator;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") == 0)
          {  animator.SetTrigger(Input.GetAxis("Horizontal") >0 ? "Right":Input.GetAxis("Horizontal") <0 ? "Left": "RightIdle");
             animator.ResetTrigger("Up");
              animator.ResetTrigger("Down");}
        if(Input.GetAxis("Horizontal") == 0 &&Mathf.Floor( Input.GetAxis("Vertical")) == 0){
            foreach (AnimatorControllerParameter param in animator.parameters){
                animator.SetTrigger($"{param.name}");
            }
        }
        if (Input.GetAxis("Vertical") != 0)
             {animator.ResetTrigger("Right");
              animator.ResetTrigger("Left");
            animator.SetTrigger(Input.GetAxis("Vertical") >0 ? "Up": Input.GetAxis("Vertical") <0 ? "Down" : "DownIdle");}
          if(Input.GetAxis("Vertical") == 0){
            animator.SetTrigger("UpIdle");
        }
    }
}
