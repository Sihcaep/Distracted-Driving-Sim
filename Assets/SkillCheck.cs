using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Import the UnityEngine namespace
using UnityEngine.UI; // Import the UnityEngine.UI namespace

public class SkillCheck : MonoBehaviour
{
    // The UI elements for the skill check
    public Image skillCheckImage;
    public Image successZoneImage;
    public Image pointerImage;

    // The speed of the pointer rotation in degrees per second
    public float pointerSpeed = 360f;

    // The angle range of the success zone in degrees
    public float successZoneAngle = 45f;

    // The key to press when the pointer is in the success zone
    public KeyCode skillCheckKey = KeyCode.Space;

    // The event to invoke when the skill check is successful
    public UnityEngine.Events.UnityEvent onSuccess;

    // The event to invoke when the skill check is failed
    public UnityEngine.Events.UnityEvent onFailure;

    // The current angle of the pointer in degrees
    private float pointerAngle;


    // A flag to indicate whether the skill check is active or not
    private bool isActive;

    // The audio source component for playing sounds
    public AudioSource audioSource;
    // The audio clip for the success sound
    public AudioClip startingSound;
    public AudioClip successSound;

    // The audio clip for the failure sound
    public AudioClip failureSound;
    public float timeLimit = 1.3f;
    private float timeLeft;

    void Start()
    {
        // Hide the UI elements at the start
        skillCheckImage.gameObject.SetActive(false);
        successZoneImage.gameObject.SetActive(false);
        pointerImage.gameObject.SetActive(false);

        // Set the initial angle of the pointer and the success zone to zero
        pointerAngle = 0f;
        successZoneAngle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // If the skill check is active, update the pointer and check for input
        if (isActive)
        {
            // Rotate the pointer by the speed multiplied by the time delta
            pointerAngle += pointerSpeed * Time.deltaTime;

            // Wrap the pointer angle between 0 and 360 degrees
            pointerAngle = Mathf.Repeat(pointerAngle, 360f);

            // Set the rotation of the pointer image based on the angle
            pointerImage.transform.rotation = Quaternion.Euler(0f, 0f, -pointerAngle);
            timeLeft -= Time.deltaTime;
            // Check if the user pressed the skill check key
            if (Input.GetKeyDown(skillCheckKey) || timeLeft <= 0f)
            {
                // Calculate the difference between the pointer angle and the success zone angle
                float angleDifference = Mathf.Abs(pointerAngle - successZoneAngle);

                // Check if the difference is within half of the success zone range
                if (angleDifference <= 20 && timeLeft > 0f)
                {
                    // The skill check is successful, invoke the success event and stop the skill check
                    audioSource.PlayOneShot(successSound);
                    onSuccess.Invoke();
                    Debug.Log("Success");
                    StopSkillCheck();
                }
                else
                {
                    // The skill check is failed, invoke the failure event and stop the skill check
                    audioSource.PlayOneShot(failureSound);
                    onFailure.Invoke();
                    Debug.Log("Failed");
                    StopSkillCheck();
                }
            }
        }
    }

    // A public method to start the skill check with a random position for the success zone
    public void StartSkillCheck()
    {
        // Set the active flag to true
        audioSource.PlayOneShot(startingSound);
        isActive = true;
        timeLeft = timeLimit;
        // Show the UI elements
        skillCheckImage.gameObject.SetActive(true);
        successZoneImage.gameObject.SetActive(true);
        pointerImage.gameObject.SetActive(true);

        // Pick a random angle for the success zone between 0 and 360 degrees
        successZoneAngle = Random.Range(0f, 360f);

        // Set the rotation of the success zone image based on the angle and range
        successZoneImage.transform.rotation = Quaternion.Euler(0f, 0f, -successZoneAngle);
        successZoneImage.fillAmount = successZoneAngle / 360f;
    }

    // A public method to stop the skill check and hide the UI elements
    public void StopSkillCheck()
    {
        // Set the active flag to false
        isActive = false;

        // Hide the UI elements
        skillCheckImage.gameObject.SetActive(false);
        successZoneImage.gameObject.SetActive(false);
        pointerImage.gameObject.SetActive(false);
    }
}