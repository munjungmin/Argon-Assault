using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem explosionVFX;
    //[SerializeField] GameObject colliders;

    void OnTriggerEnter(Collider other) {
        
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        // 폭발 파티클 
        explosionVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        transform.Find("Collider").gameObject.SetActive(false);
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
