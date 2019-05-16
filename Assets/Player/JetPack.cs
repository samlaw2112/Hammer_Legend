using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    [Tooltip("Force in x added to player by jet pack.")]
    public float JetPackStrengthX;
    [Tooltip("Force in y added to player by jet pack.")]
    public float JetPackStrengthY;

    private bool jetPackOn = false;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Nudges player upwards when finger pressed down
        if (jetPackOn)
        {
            body.AddForce((transform.up * JetPackStrengthY) + (transform.right * JetPackStrengthX));

        }
    }


    public void JetPackOn()
    {
        jetPackOn = true;
    }

    // Nudges player upwards when finger pressed down
    public void JetPackOff()
    {
        jetPackOn = false;
    }
}
