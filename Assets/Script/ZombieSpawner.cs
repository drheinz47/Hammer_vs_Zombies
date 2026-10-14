using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    int counter = 0;
    int wave = 0;
    public Difficulty difficulty = new Difficulty();

    public UiController uiController;

    public float minDistance = 3f;
    public float maxDistance = 8f;

    public event System.Action raiseDifficulty; //too ez make it harder
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(counter >= difficulty.frequency)
        {
            GameObject instance = SpawnZombie();
            SetupZombieInstance(instance); //and sub to its oncapture
            counter = 0;
            WaveCheck(); //raise difficulty if wave passed
        }
        else{counter++;}
    }

    public void SetupZombieInstance(GameObject instance)
    {
        ZombieLife zombieLife = instance.GetComponent<ZombieLife>();
        zombieLife.difficulty = SetDifficulty(difficulty);
        zombieLife.difficulty.lives = Random.Range(1, difficulty.lives+1);
        SubscribeToOnCapture(zombieLife);
    }
    public Difficulty SetDifficulty(Difficulty difficulty)
    {
        Difficulty instanceDifficulty = new Difficulty();
        instanceDifficulty.level = difficulty.level;
        instanceDifficulty.speed = difficulty.speed;
        instanceDifficulty.lives = difficulty.lives;
        instanceDifficulty.frequency = difficulty.frequency;
        return instanceDifficulty;
    }
    public void SubscribeToOnCapture(ZombieLife zombieLife)
    {
        zombieLife.onCapture += ProduceGameOver;
    }
    public GameObject SpawnZombie()
    {
        Vector2 position = PickPosition();
        Quaternion angle = PickAngle(position);
        return Instantiate(zombiePrefab, position, angle, transform);
    }
    public Vector2 PickPosition()
    {
        float distance = Random.Range(minDistance, maxDistance);
        Vector2 randomPosition = Random.insideUnitCircle.normalized;
        return randomPosition * distance;
    }
    public Quaternion PickAngle(Vector2 position)
    {
        float angle = Vector2.SignedAngle(Vector2.right, position);
        return Quaternion.Euler(0, 0, angle + 90f);
    }
    public void ProduceGameOver()
    {
        uiController.GameOver();
        gameObject.SetActive(false);
    }
    public void WaveCheck()
    {
        int waveSize = Random.Range(1,3);
        if(wave == waveSize)
        {
            raiseDifficulty?.Invoke();
            wave = 0;
            counter = - 70;
        }
        else{wave++;}
    }
}
