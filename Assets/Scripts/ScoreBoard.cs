using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;  // 초기화 안해도 0으로 지정
   
    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        Debug.Log($"Score is now: {score}");
    }
}
