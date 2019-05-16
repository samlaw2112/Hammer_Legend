using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    [Tooltip("Force in x added to player by jet pack.")]
    public float jetPackStrengthX;
    [Tooltip("Force in y added to player by jet pack.")]
    public float jetPackStrengthY;
    [Tooltip("Maximum length of single jet pack boost in seconds.")]
    public float boostDuration;

    private bool jetPackOn = false;
    private bool boostAvailable = true;
    private float boostStartTime; // Stores start time of each jet pack boost
    private Rigidbody2D body;
    private ParticleSystem particleEffect;
    private AudioSource thrustSound;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        particleEffect = GetComponent<ParticleSystem>();
        thrustSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Nudges player upwards when finger pressed down
        if (jetPackOn && boostAvailable)
        {
            // if total jet pack boost time hasn't yet elapsed for this boost
            if (Time.time <= boostStartTime + boostDuration)
            {
                float time = Time.time - boostStartTime;
                body.AddForce((transform.up * jetPackStrengthY) + (transform.right * jetPackStrengthX));
            }  else { JetPackOff(); }
            
        }
    }


    // Turns jet pack on and particle system if boost is available
    public void JetPackOn()
    {
        if (boostAvailable)
        {
            jetPackOn = true;
            particleEffect.Play();
            thrustSound.Play();
        }
        else { return; }
        
    }

    // Turns off jetpack and acknowledges boost has been used
    public void JetPackOff()
    {
        jetPackOn = false;
        boostAvailable = false;
        particleEffect.Stop();
        thrustSound.Stop();
    }

    public void ResetBoost()
    {
        boostAvailable = true;
    }

    public void SetBoostStartTime()
    {
        boostStartTime = Time.time;
    }
}
