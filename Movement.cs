using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrust = 3f;
    [SerializeField] float rotationthrust = 1f;
    AudioSource audioSource;
    //Play the music
    bool m_Play;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool m_ToggleChange;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        //Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        m_Play = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Check to see if you just set the toggle to positive
        if (m_Play == true && m_ToggleChange == true)
        {
            //Play the audio you attach to the AudioSource component
            audioSource.Play();
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
        //Check if you just set the toggle to false
        if (m_Play == false && m_ToggleChange == true)
        {
            //Stop the audio
            audioSource.Stop();
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
        ProcessThrust();
        ProcessRotation();
      
    }
    void ProcessThrust()

    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
         rb.AddRelativeForce(Vector3.up * Time.deltaTime * thrust);
            
            
        }
        
    }
        void ProcessRotation()
    {     
    if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationthrust);
        }

        else  if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotationthrust);
        }
            
    }

     void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing so the physics system can take over
    }
}
