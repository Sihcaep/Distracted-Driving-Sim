using UnityEngine;
using System.Collections;

public class SkillCheckTester : MonoBehaviour
{
    // The reference to the skill check script
    public SkillCheck skillCheck;

    // The minimum and maximum time interval for starting the skill check
    public float minTime = 3f;
    public float maxTime = 5f;

    // The current time until the next skill check
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the timer with a random value
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease the timer by the elapsed time
        timer -= Time.deltaTime;

        // Check if the timer reaches zero or below
        if (timer <= 0f)
        {
            // Start a new skill check using the skill check script
            skillCheck.StartSkillCheck();

            // Reset the timer with a new random value
            timer = Random.Range(minTime, maxTime);
        }
    }
}
// using UnityEngine;

// public class SkillCheckTester : MonoBehaviour
// {
//     // The key for triggering the skill check
//     public KeyCode skillCheckKey = KeyCode.S;

//     // The reference to the skill check script
//     public SkillCheck skillCheck;

//     // Update is called once per frame
//     void Update()
//     {
//         // Check if the key is pressed

//         if (Input.GetKeyDown(skillCheckKey))
//         {
//             // Start a new skill check using the skill check script
//             skillCheck.StartSkillCheck();
//         }
//     }
// }
