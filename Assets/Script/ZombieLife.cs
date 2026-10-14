using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class ZombieLife : MonoBehaviour
{
    public float speed = 5f;
    public event System.Action onCapture;
    public Difficulty difficulty = new Difficulty();
    int lives;
    public Sprite[] textures;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lives = difficulty.lives;
        SelectSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
        GoToMiddle();
    }
    
    public void GoToMiddle()
    {
        
        Vector2 targetPosition = new Vector2(0,0);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, difficulty.speed * Time.deltaTime);
        float distance = Vector2.Distance(transform.position,targetPosition);
        if (distance < 0.5f)
        {
            onCapture?.Invoke();
        }
    }

    public void SelectSprite()
    {
        GetComponent<SpriteRenderer>().sprite = textures[lives-1];
    }

    public void DeathByHammer()
    {
        if(lives == 1)
        {
            Destroy(gameObject);
        }
        else
        {
            lives--;
            SelectSprite();
        }
    }
}
