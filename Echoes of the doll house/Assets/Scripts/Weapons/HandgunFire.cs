//Written by Swornashabi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    [SerializeField] AudioSource gunFire;
    [SerializeField] GameObject handgun;
    [SerializeField] bool canFire = true;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (canFire == true)
            {
                canFire = false;
                StartCoroutine(FiringGun());
            }
        }
    }

    IEnumerator FiringGun()
    {
        gunFire.Play();
        handgun.GetComponent<Animator>().Play("HandgunFire");
        yield return new WaitForSeconds(0.5f);
        handgun.GetComponent<Animator>().Play("New State");
        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }
}
