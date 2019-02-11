using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorController : MonoBehaviour
{
    [SerializeField]
    BallSpawnerControl spawner;

    [SerializeField]
    ScoreController score;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        score.updateScore();
        spawner.CmdCreateBall();
    }
}
