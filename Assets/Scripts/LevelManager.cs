using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    public bool gameActive;
    public float timer;

    public float wainToShowEndScreen=1.5f;
    void Start()
    {
        gameActive = true;
    }
    void Update()
    {
        //vi time.scale = 0 khi mo nang cap;
        if (gameActive == true)
        {
            timer += Time.deltaTime;
            UIController.instance.UpdateTimer(timer);
        }
    }

    public void EndLevel()
    {
        gameActive = false;
        StartCoroutine(endLevelCo());
    }

    IEnumerator endLevelCo()
    {
        yield return new WaitForSeconds(wainToShowEndScreen);
        float minute = Mathf.FloorToInt(timer / 60f);
        float seconds = Mathf.FloorToInt(timer % 60f);

        UIController.instance.endTimeText.text=minute.ToString()+" mins "+seconds.ToString("00"+" secs");
        UIController.instance.levelEndScreen.SetActive(true);
    }
}
