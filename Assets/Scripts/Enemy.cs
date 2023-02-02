using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject laserHitVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 4;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();   // 프로젝트에서 발견하는 첫 ScoreBoard를 return, 여러개가 있으면 충돌 발생해서 배열 사용해야함 
        AddRigidbody();
        
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(laserHitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints--;
        //Debug.Log($"{this.name} only has ** {hitPoints} **life");
    }

    void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

}
