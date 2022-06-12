using UnityEngine;
using UnityEngine.Events;
public class TriggerTeleporter : MonoBehaviour
{
	[SerializeField] string targetTag;
	[SerializeField] LayerMask layerMask = ~0;
	public UnityEvent<Vector2> onTriggerTeleport;
	public UnityEvent<Vector2, float> onTriggerTeleportWithDelay;
	public bool oneShot;
	public bool skipEvents;
	[SerializeField] Transform targetTransform;
	[SerializeField] float delayTime;
	public AudioSource audioSource;

		
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (skipEvents) return;

		if ((targetTag == string.Empty || other.CompareTag(targetTag)) && HasLayer(layerMask, other.gameObject.layer))
		{
			if (oneShot)
				skipEvents = true;

			if(onTriggerTeleport != null)
				onTriggerTeleport.Invoke(targetTransform.position);

			onTriggerTeleportWithDelay?.Invoke(targetTransform.position, delayTime);
			audioSource.Play();
		}
	}

	public static bool HasLayer(LayerMask layerMask, int layer)
	{
		return layerMask == (layerMask | (1 << layer));
	}
}