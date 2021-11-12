using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

class antibomb : MonoBehaviour
{

    void Use()
    {
        ExplosionCreator.CreateFragmentationExplosion(35, this.transform.position, -9, -9, true, true);
        Destroy(gameObject);
    }
}