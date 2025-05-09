using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class HandGunDamage : MonoBehaviour
{
    public int DamageAmount = 5;
    public float TargetDistance;
    public float AllowedRange = 15.0f;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit Shot;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
            {
                TargetDistance = Shot.distance;
                if (TargetDistance < AllowedRange)
                {
                    Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        
    }
}
