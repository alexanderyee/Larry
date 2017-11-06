using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public static int currentHealth = 10;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    //public Text healthText;
    static bool damaged;
    Animator anim;                                              // Reference to the Animator component.
    static AudioSource playerAudio;                                    // Reference to the AudioSource component.
    PlayerMovement playerMovement;                              // Reference to the player's movement.
    static bool isDead;                                                // Whether the player is dead.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    void Start () {
        //healthText.text = currentHealth.ToString ();
        healthSlider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (damaged)
        { //damageImage.color = flashColor;
        } else
        {
           // damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
		//healthText.text = "HP: " + currentHealth.ToString ();
	}
    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            //Death();
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;


        // Tell the animator that the player is dead.
        anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        playerAudio.clip = deathClip;
        playerAudio.Play();

        // Turn off the movement and shooting scripts.
        playerMovement.enabled = false;
    }

public static void ResetHealth(){
    currentHealth = 10;
	}
}
