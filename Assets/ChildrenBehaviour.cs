using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Animator OrangeAnimator = GetComponent<Animator>();
            OrangeAnimator.SetTrigger("Founded");
        }
    }

    public void DestroyChild()
    {
        Destroy(gameObject);
        GameObject.FindGameObjectWithTag("NpcChild").GetComponent<MissionLookForChildren>().HasFoundChild();
    }

}
