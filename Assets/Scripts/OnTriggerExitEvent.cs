using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerExitEvent : MonoBehaviour
{
	[SerializeField] string targetTag;
	[SerializeField] LayerMask layerMask = ~0;
	public UnityEvent onTriggerExit;
	public UnityEvent<Collider2D> onTriggerExitWithCollider;

	public bool oneShot;
	public bool skipEvents;

	private void OnTriggerExit2D(Collider2D other)
	{
		if (skipEvents) return;

		if (targetTag == string.Empty || other.CompareTag(targetTag))
		{
			if (oneShot)
				skipEvents = true;

			onTriggerExit?.Invoke();
			onTriggerExitWithCollider?.Invoke(other);
		}
	}

	public static bool HasLayer(LayerMask layerMask, int layer)
	{
		return layerMask == (layerMask | (1 << layer));
	}
}
