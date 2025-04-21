//Written by Swornashabi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    [SerializeField] AudioSource gunFire;
    [SerializeField] GameObject handgun;
    [SerializeField] bool canFire = true;
    [SerializeField] GameObject extraCross;
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
        extraCross.SetActive(true);
        handgun.GetComponent<Animator>().Play("HandgunFire");
        yield return new WaitForSeconds(0.5f);
        handgun.GetComponent<Animator>().Play("New State");
        extraCross.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        canFire = true;
    }
}
