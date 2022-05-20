using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile
{
    public int score;
    public int lives;
    public int profileRef;

    //might need to be changed to actual values from saved data
    public Profile (int profileNo) {
        score = 0;
        lives = 3;
        profileRef = profileNo;
    }
}
