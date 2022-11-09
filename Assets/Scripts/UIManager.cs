using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Text = UnityEngine.UI.Text;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _playerScore;

    [SerializeField]
    private Text _enemyScore;
    void Start()
    {

    }

    void Update()
    {
        
    }

   public void OnGoalConceieved(string goalTag)
    {
        if (goalTag == "Enemy_Goal")
        {
            _enemyScore.text = "" + (int.Parse(_enemyScore.text) + 1);
        }
        else
        {
            _enemyScore.text = "" + (int.Parse(_enemyScore.text) + 1);
        }

    }

    
}
