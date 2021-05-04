using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class Menu : MonoBehaviour
{
    public int point;
    public int life;

    [SerializeField]
    private Text pointText;
    [SerializeField]
    private Text lifeText;
    [SerializeField]
    private GameObject menu;
    public Toggle music;
    public AudioSource sound;

    bool isPaused = false;

    private void Awake()
    {
        Pause();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void musicChange(bool soundOption)
    {
        if (soundOption == true)
        {
            sound.Play();
        }
        else if (soundOption == false)
        {
            sound.Stop();
        }
    }

    public void Pause()
    {
        menu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Unpause()
    {
        menu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        isPaused = false;
    }

    public bool isGamePaused()
    {
        return isPaused;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }
    public void SaveGame()
    {
        Save save = CreateSaveGameObjects();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        point = 0;
        life = 0;
        pointText.text = "Points: " + point;
        lifeText.text = "Lives: " + life;

    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            file.Close();
        }
    }
    public void JSONSave()
    {
        Save save = CreateSaveGameObjects();
        string json = JsonUtility.ToJson(save);
    }
    public Save CreateSaveGameObjects()
    {
        Save save = new Save();
        save.lives = life;
        save.points = point;
        return save;
    }
}
