using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
//quaq is of the smol brain
class Worpgun : MonoBehaviour
    {

    void Use()
    {

        if (transform.root.localScale.x < 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(GetComponent<CanShoot>().BarrelPosition, -transform.right, LayerMask.GetMask("Objects"));
            if (hit.collider == null) return;
            Instantiate(ModAPI.FindSpawnable("Decimator").Prefab.GetComponent<DecimatorBehaviour>().BlackHole, hit.point, Quaternion.identity);
            //            CatalogBehaviour.PerformMod("Decimator", ModAPI.FindSpawnable("Decimator").Prefab.GetComponent<DecimatorBehaviour>().BlackHole);
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(GetComponent<CanShoot>().BarrelPosition, transform.right, LayerMask.GetMask("Objects"));
            if (hit.collider == null) return;
            Instantiate(ModAPI.FindSpawnable("Decimator").Prefab.GetComponent<DecimatorBehaviour>().BlackHole , hit.point, Quaternion.identity);
            //            CatalogBehaviour.PerformMod("Decimator", ModAPI.FindSpawnable("Decimator").Prefab.GetComponent<DecimatorBehaviour>().BlackHole);
        }
    }
    }