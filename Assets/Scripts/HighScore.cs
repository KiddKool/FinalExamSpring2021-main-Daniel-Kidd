using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class HighScore : MonoBehaviour
{

    public Text ScoreBoard;
    private int points = Points.newPoints;
    private string namedisplay = NameDisplay.currentName;
    private string path = Directory.GetCurrentDirectory() + "/Assets/HighScore.txt";

    private void Awake()
    {

        BestScoreEntry bestScoreEntry = new BestScoreEntry { score = points, name = namedisplay };
        string JSONstring = File.ReadAllText(path);
        HighScoreTable highScoreTable = JsonUtility.FromJson<HighScoreTable>(JSONstring);
        if (highScoreTable == null)
        {
            highScoreTable = new HighScoreTable()
            {
                ScoreList = new List<BestScoreEntry>()
            };
        }
        highScoreTable.ScoreList.Add(bestScoreEntry);

        for (int i = 0; i < highScoreTable.ScoreList.Count; i++)
        {
            for (int j = i + 1; j < highScoreTable.ScoreList.Count; j++)
            {
                if (highScoreTable.ScoreList[j].score > highScoreTable.ScoreList[i].score)
                {
                    BestScoreEntry temp = highScoreTable.ScoreList[i];
                    highScoreTable.ScoreList[i] = highScoreTable.ScoreList[j];
                    highScoreTable.ScoreList[j] = temp;
                }
            }
        }
        string JSON = JsonUtility.ToJson(highScoreTable);
        File.WriteAllText(path, JSON);
        ScoreDisplay(highScoreTable);
    }

    public void ScoreDisplay(HighScoreTable highScoreTable)
    {

        string scores = "";
        for (int i = 0; i < highScoreTable.ScoreList.Count; i++)
        {
            if (i == 10)
            {
                break;
            }
            int rank = i + 1;
            string rankString = rank.ToString();
            string name = highScoreTable.ScoreList[i].name;
            string score = highScoreTable.ScoreList[i].score.ToString();
            scores += rankString + "   " + score + "     " + name + "\n";
        }
        Debug.Log(scores);
        ScoreBoard.text = scores;
    }



    public class HighScoreTable
    {
        public List<BestScoreEntry> ScoreList;
    }


    [System.Serializable]
    public class BestScoreEntry
    {
        public int score;
        public string name;
    }

    public void ClearTable()
    {
        Points.newPoints = 0;
        NameDisplay.currentName = "";
        string cleared = "";
        File.WriteAllText(path, cleared);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

