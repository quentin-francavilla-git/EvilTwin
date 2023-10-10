using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public enum TriggerType {isAttacking, isDamaged, isDying};

    public Animator animator;

    public void ResetVariable(TriggerType variableType)
    {
        if (variableType == TriggerType.isAttacking)
            animator.SetBool("isAttacking", false);
        else if (variableType == TriggerType.isDamaged)
            animator.SetBool("isDamaged", false);
        else if (variableType == TriggerType.isDying)
            animator.SetBool("isDying", false);
    }

    public void DestroyObject()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
