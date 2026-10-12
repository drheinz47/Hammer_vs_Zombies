using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    int counter = 0;

    public UiController uiController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter++;
        if(counter >= 70)
        {
            SpawnZombie();
            counter = 0;
        }
    }

    public void SpawnZombie()
    {
        float distance = Random.Range(3f, 8f);
        Vector2 randomPosition = Random.insideUnitCircle.normalized;
        Vector2 actualPosition = randomPosition * distance;
        float angle = Vector2.SignedAngle(Vector2.right, actualPosition);
        Quaternion rotation = Quaternion.Euler(0, 0, angle + 90f);
        GameObject instance = Instantiate(zombiePrefab, actualPosition, rotation, transform);
        ZombieLife zombieLife = instance.GetComponent<ZombieLife>();
        zombieLife.onCapture += ProduceGameOver;
    }

    public void ProduceGameOver()
    {
        uiController.GameOver();
        gameObject.SetActive(false);
    }
}
