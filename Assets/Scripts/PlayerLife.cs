using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float reloadDelay;
    [SerializeField] private float lowestYPos;
    [SerializeField] private AudioSource deadSound;
    private bool isDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDead = false;     //coz you're not dead at the beginning of the game
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyTag"))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        deadSound.Play();

        //player can't move
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerController>().enabled = false;

        //player disappears from scene
        GetComponent<MeshRenderer>().enabled = false;

        //reload the scene after waiting the reloadDelay time
        Invoke("ReloadScene", reloadDelay);
    }

    /// <summary>
    /// Reload the current scene when the player dies
    /// </summary>
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Checks for player falling off the platform and calls the Die function
    /// </summary>
    void Update()
    {
        if(transform.position.y < lowestYPos && !isDead)
        {
            Die();
        }
    }
}
