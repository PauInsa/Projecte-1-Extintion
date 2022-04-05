using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public int damage;
	[SerializeField] string targetTag;
	[SerializeField] LayerMask layerMask = ~0;

	private void OnTriggerEnter2D(Collider2D other)
	{

		if ((targetTag == string.Empty || other.CompareTag(targetTag)) && HasLayer(layerMask, other.gameObject.layer))
		{
			HP hp = other.GetComponent<HP>();
			if (hp!= null)
            {
				hp.DamageReceived(damage);
				Destroy(gameObject);
            }
		}
	}

	public static bool HasLayer(LayerMask layerMask, int layer)
	{
		return layerMask == (layerMask | (1 << layer));
	}

}
