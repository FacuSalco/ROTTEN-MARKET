using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenBehaviour : MonoBehaviour
{
    private ParticleSystem Particles;
    private SkinnedMeshRenderer MeshRender;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Animator OrangeAnimator = GetComponent<Animator>();
            OrangeAnimator.SetTrigger("Founded");

            StartCoroutine(StartConfetti());
            StartCoroutine(DesactivateRenderer());
            StartCoroutine(DestroyGO());
        }
    }

    IEnumerator StartConfetti()
    {
        Particles = GetComponentInChildren<ParticleSystem>();

        yield return new WaitForSeconds(1.2f);

        Particles.Play();
    }

    IEnumerator DesactivateRenderer()
    {
        MeshRender = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

        yield return new WaitForSeconds(1.65f);

        MeshRender.enabled = false;
    }

    IEnumerator DestroyGO()
    {

        yield return new WaitForSeconds(5f);

        DestroyChild();

    }

    public void DestroyChild()
    {
        Destroy(gameObject);

        GameObject.FindGameObjectWithTag("NpcChild").GetComponent<MissionLookForChildren>().HasFoundChild();
    }

}
