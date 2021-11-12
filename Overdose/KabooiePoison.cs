using UnityEngine;
using System;
class KabooiePoison : PoisonSpreadBehaviour
{
	public override void Start()
	{
		ExplosionCreator.CreateFragmentationExplosion(35U, this.Limb.transform.position, Mathf.Abs(base.GetFingerprintValue()) * 8f, base.GetFingerprintValue() * 25f, base.GetFingerprintValue() < 0.5f, base.GetFingerprintValue() > 0.9f);
	}

	public KabooiePoison()
	{
	}
}
