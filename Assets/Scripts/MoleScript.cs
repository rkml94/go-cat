using UnityEngine;
using System.Collections;

public class MoleScript : MonoBehaviour 
{
	public tk2dClippedSprite sprite;
	public AudioClip moleUp;
	public AudioClip moleDown;
	
	private float height;
	private float speed;
	private float timeLimit;
	private Rect spriteRec;
	private bool whacked;
	private float transformY;
	
	private Transform colliderTransform;

	public Transform ColliderTransform
	{
		get
		{
			return colliderTransform;
		}
	}
	
	// Trigger the mole.  It is now 'active' and the sprite is set to the default mole sprite, just in case it isn't.
	
	public void Trigger(float tl)
	{
		sprite.gameObject.SetActive (true);
		whacked = false;
		sprite.SetSprite("Mole_Normal");
		timeLimit = tl;
		StartCoroutine (MainLoop());
	}

	void Start()
	{
		timeLimit = 1.0f;
		speed = 2.0f;
		
		// Get the 'size' of the mole sprite
		Bounds bounds = sprite.GetUntrimmedBounds();
		height = bounds.max.y - bounds.min.y;
		
		// We want the mole to be fully clipped on the Y axis initially.
		spriteRec = sprite.ClipRect;
		spriteRec.y = 1.0f;
		sprite.ClipRect = spriteRec;

		colliderTransform = sprite.transform;
		
		//Move the mole sprite into the correct place relative to the hole
		Vector3 localPos = sprite.transform.localPosition;
		transformY = localPos.y;
		localPos.y = transformY - (height * sprite.ClipRect.y);
		sprite.transform.localPosition = localPos;
		
		sprite.gameObject.SetActive (false);
		
		// Add mole to the main game script's mole container
		MainGameScript.Instance.RegisterMole(this);
	}
	
	// Main loop for the sprite.  Move up, then wait, then move down again. Simple.
	private IEnumerator MainLoop()
	{
		yield return StartCoroutine(MoveUp());
		yield return StartCoroutine(WaitForHit());
		yield return StartCoroutine(MoveDown());
	}
	
	// As it 'moves up', we see more of the sprite and the position of it has to be adjusted so that the 'bottom' of the sprite is in line with the hole.
	private IEnumerator MoveUp()
	{	
		AudioSource.PlayClipAtPoint(moleUp, new Vector3());

		while(spriteRec.y > 0.0f)
		{
			spriteRec = sprite.ClipRect;
			float newYPos = spriteRec.y - speed * Time.deltaTime;
			spriteRec.y = newYPos < 0.0f ? 0.0f : newYPos;
			sprite.ClipRect = spriteRec;
			
			Vector3 localPos = sprite.transform.localPosition;
			localPos.y = transformY - (height * sprite.ClipRect.y);
			sprite.transform.localPosition = localPos;
			
			yield return null;
		}
	}
	
	// Give the player a chance to hit the mole.
	private IEnumerator WaitForHit()
	{
		float time = 0.0f;
		
		while(!whacked && time < timeLimit)
		{
			time += Time.deltaTime;
			yield return null;
		}
	}
	
	// Same as the MoveUp function but the other way around!	
	private IEnumerator MoveDown()
	{		
		while(spriteRec.y < 1.0f)
		{ 
			spriteRec = sprite.ClipRect;
			float newYPos = spriteRec.y + speed * Time.deltaTime;
			spriteRec.y = newYPos > 1.0f ? 1.0f : newYPos;
			sprite.ClipRect = spriteRec;
			
			Vector3 localPos = sprite.transform.localPosition;
			localPos.y = transformY - (height * sprite.ClipRect.y);
			sprite.transform.localPosition = localPos;
			
			yield return null;
		}

		AudioSource.PlayClipAtPoint(moleDown, new Vector3());
		sprite.gameObject.SetActive(false);
	}
	
	// Mole has been hit
	public void Whack()
	{
		whacked = true;
		sprite.SetSprite("Mole_Hit");
	}
	
	public bool Whacked
	{
		get
		{
			return whacked;	
		}
	}
}
