using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public int animalsKilled = 0;
    private GameObject[] animalObjects;

    private void Start()
    {
        // Get all game objects with the "Animals" tag
        animalObjects = GameObject.FindGameObjectsWithTag("Animal");
    }

    void Update()
    {
        // Check if all Animal have been killed
        int totalAnimals = animalObjects.Length;

        if (animalsKilled == totalAnimals)
        {
            Debug.Log("You have killed all the animals!");
            EndGame();
        }
    }

    void EndGame()
    {
        // Add your end game logic here
        Debug.Log("Game Over");
        SceneTransitionManager.singleton.GoToSceneAsync(2);
        // For example, you can display a game over screen or quit the application
        // ShowGameOverScreen();
        // Application.Quit();
    }
}
