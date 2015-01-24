using UnityEngine;
using System.Collections;

public class myAudioPlayOneShot : MonoBehaviour
{	
		private float clipEnd;
		public void MyPlayOneShot (AudioClip sound)
		{
				if (Time.time > clipEnd) { 
						audio.PlayOneShot (sound);	
						clipEnd = Time.time + sound.length; 
				}
		}
}
