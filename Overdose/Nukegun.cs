using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

    class Nukegun : MonoBehaviour
    {

    void Use()
    {

        if (transform.root.localScale.x < 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(GetComponent<CanShoot>().BarrelPosition, -transform.right, LayerMask.GetMask("Objects"));
            if (hit.collider == null) return;
            ExplosionCreator.CreateFragmentationExplosion(35, hit.point, 9999999, 9999999, true, true);
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(GetComponent<CanShoot>().BarrelPosition, transform.right, LayerMask.GetMask("Objects"));
            if (hit.collider == null) return;
            ExplosionCreator.CreateFragmentationExplosion(35, hit.point, 9999999, 9999999, true, true);
        }
       }
    }