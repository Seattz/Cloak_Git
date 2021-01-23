using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CloakController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);   
    AudioSource audioSource;

    public GameObject pickupParticles;

    public int scoreValue = 0;
    public Text score;
    public Text winText;
    public Text loseText;

    public AudioClip musicClipOne;
    public AudioSource musicSource;
    public GameObject backgroundMusic;
    public GameObject winMusic;
    public GameObject loseMusic;
    public GameObject Timer;

    // Start is called before the first frame update
    void Start()
    {
        winMusic.SetActive(false);
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        audioSource= GetComponent<AudioSource>();

        scoreValue = 0;
        score.text = "Score: " + scoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (scoreValue == 3)
        {
            winText.text = "You Win! Game created by Chase Rook.";
            backgroundMusic.SetActive(false);
            winMusic.SetActive(true);

            Destroy(Timer);

        }   
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.2f * horizontal * Time.deltaTime;
        position.y = position.y + 3.2f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void Collect()
    {
        GameObject cloak_final = Instantiate(pickupParticles, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
    }

    public void ChangeScore(int amount)
    {
        scoreValue += 1;
        score.text = "Score: " + scoreValue.ToString();
    } 
}
