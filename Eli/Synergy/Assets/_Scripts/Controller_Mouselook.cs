using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class Controller_Mouselook : MonoBehaviour
{

    [HideInInspector] public Transform t;
    private float current_mouse_x, current_mouse_y;
    private float x_rotation, y_rotation;
    public int Team;
    private float[] team_x = {0f, 0f, 0f, 0f};
    private float[] team_y = {0f, 90f, 180f, 270f};
    public float Sensitivity = 100f;
    public AudioClip sound;

    // Use this for initialization
    void Start()
    {
        t = transform;

        /*        for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                        t.rotation = Quaternion.Euler(0f, 0f, 0f);
                    else if (i == 1)
                        t.rotation = Quaternion.Euler(0f, 90f, 0f);
                    else if (i == 2)
                        t.rotation = Quaternion.Euler(0f, 180f, 0f);
                    else if (i == 3)
                        t.rotation = Quaternion.Euler(0f, 270f, 0f);

                    team_x[i] = t.localEulerAngles.x;
                    team_y[i] = t.localEulerAngles.y;
                }
        */
        Team = 1;
    }

    // Update is called once per frame
    void Update()
    {
        team_check();

        x_rotation = team_x[Team-1];
        y_rotation = team_y[Team-1];

        current_mouse_x = Input.GetAxis("Mouse X");                     //Get this frame's mouse coordinates and add them to the current rotations
        x_rotation += current_mouse_x * Sensitivity * Time.deltaTime;
        x_rotation = x_rotation % 360;


        current_mouse_y = -Input.GetAxis("Mouse Y");
        y_rotation += current_mouse_y * Sensitivity * Time.deltaTime;

        y_rotation = Mathf.Clamp(y_rotation, -80f, 80f);                //clamp y rotation bewteen 80 and -80 degrees (so you can't look all the way up and backwards)

        team_x[Team-1] = x_rotation;
        team_y[Team-1] = y_rotation;

        Quaternion new_rotation = Quaternion.Euler(y_rotation, x_rotation, 0f);     //rotate the camera in both x and y directions.... 
        t.rotation = new_rotation;
     }

    private void team_check()
    {
        int old_team = Team;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            Team = 1;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            Team = 2;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            Team = 3;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            Team = 4;
        }

        if(old_team != Team)
        {
            GetComponent<AudioSource>().PlayOneShot(sound, 1f);
        }       
    }

    //Locks the cursor
    public void lock_cursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Unlock_cursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

}
