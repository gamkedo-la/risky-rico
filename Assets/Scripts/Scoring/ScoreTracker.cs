using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public struct Score 
{
    public int value;
    public string holder;
    public string message;
}

public class ScoreTracker : MonoBehaviour
{
    [Tooltip("The score the player currently has at the time of a game over")]
    [SerializeField] private IntVariable _playerScore;

    [Tooltip("The list of high scores the player or NPCs have achieved")]
    [SerializeField] private List<Score> _highScores = new List<Score>();
    
    [Tooltip("Messages to display when the player reaches a specific score")]
    [SerializeField] private IntStringDictionary _scoreMessageMap = new IntStringDictionary();
    
    [Tooltip("The limit to how many elements are allowed in the high score list")]
    [Range(5, 10)]
    [SerializeField] private int _maxScoreCount = 5;

    public void UpdateScoreList()
    {
        // get the player's score and the lowest score to compare them
        int currentScore = _playerScore.Value;

        _highScores.Sort(CompareScoreValues);

        Score lowestScore = _highScores[_highScores.Count - 1];

        // only add a new score to the list if player's score is at least higher than the lowest score
        if (lowestScore.value < currentScore)
        {
            // get the location of the lowest score (to be replaced)
            int indexOfLowestScore = _highScores.IndexOf(lowestScore);

            // create a new score object
            Score newScore = new Score();
            newScore.value = currentScore;
            newScore.holder = "Rico";
            newScore.message = GetScoreMessage(currentScore);

            // replace the lowest score with the new score
            _highScores[indexOfLowestScore] = newScore;

            // re-sort the list
            _highScores.Sort(CompareScoreValues);
        }

        // reset the player's score
        _playerScore.Value = 0;

        // restrict the high score list to its maximum list
        if (_highScores.Count > _maxScoreCount)
        {
            _highScores.RemoveAt(_highScores.Count - 1);
        }

    }

    string GetScoreMessage(int score)
    {
        return "";
    }

    public int CompareScoreValues(Score a, Score b)
    {
        if (a.value == b.value) return 0;
        return a.value > b.value ? 1 : -1;
    }
}