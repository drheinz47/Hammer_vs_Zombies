using UnityEngine;
using UnityEngine.UIElements;

public class ZombieLife : MonoBehaviour
{
    public event System.Action onCapture;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5f;
        Vector2 targetPosition = new Vector2(0,0);
        transform.position = Vector2.MoveTowards(
        transform.position,
        targetPosition,
        speed * Time.deltaTime);
        float distance = Vector2.Distance(transform.position,targetPosition);
        if (distance < 0.5f)
        {
            onCapture?.Invoke();
        }
    }

    public void DeathByHammer()
    {
        Destroy(gameObject);
    }
}
