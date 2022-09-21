using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playTime : MonoBehaviour
{
	public Text TimerText;
	public Text TimerAfterDeathText;
	public Text ScoreText;
		public Text scoreAfterDeathText;
	public Text weaponReload;

	public bool playing;
	private float Timer;
	public float TimerAfterDeath;
    private void Awake()
    {
		playing = true;
    }
    void Update()
	{

		if (playing)
		{
			//this is how the timer is working
			Timer += Time.deltaTime;
			int minutes = Mathf.FloorToInt(Timer / 60F);
			int seconds = Mathf.FloorToInt(Timer % 60F);
			int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
			TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
			//displaying score
		ScoreText.text = FindObjectOfType<playerMovement>().Score.ToString();
			scoreAfterDeathText.text = FindObjectOfType<playerMovement>().Score.ToString();
			TimerAfterDeath = Timer;
		TimerAfterDeathText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
if (FindObjectOfType<playerMovement>().endlessMode)
		{
			if (FindObjectOfType<shotMechanism>().canShoot)
			{
				weaponReload.fontStyle = FontStyle.Bold;
				weaponReload.color = Color.green;
				weaponReload.text = "Weapon Ready";
			}
			else
			{
				weaponReload.fontStyle = FontStyle.Bold;
				weaponReload.color = Color.red;
				weaponReload.text = "Reloading......";
			}
		}
		}
		
	}
}
