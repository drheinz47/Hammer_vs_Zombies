using UnityEngine;
using System.Collections;

public class DifficultyController : MonoBehaviour
{
    public ZombieSpawner zombieSpawner;
    Difficulty difficulty = new Difficulty();
    void Start()
    {
        zombieSpawner.raiseDifficulty += SetDifficulty;
        SetDifficulty();
    }
    public void SetDifficulty()
    {
        difficulty.speed = Mathf.Min(2 * (1 + difficulty.level/4f), 8);
        if(difficulty.level > 12){difficulty.lives = 3;}
        else if(difficulty.level > 3){difficulty.lives = 2;}
        else{difficulty.lives = 1;}
        if(difficulty.level > 18)
        {
            difficulty.frequency = Mathf.Max(100 - (difficulty.level - 18), 20);
        }
        else
        {
            difficulty.frequency = 100;
        }
        zombieSpawner.difficulty = difficulty;
        difficulty.level++;
    }
}

[System.Serializable]
public class Difficulty
{
    public int level = 0;
    public float speed = 2;
    public int lives = 1;
    public int frequency = 100;
}
