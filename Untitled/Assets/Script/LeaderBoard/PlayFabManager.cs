using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class PlayFabManager : MonoBehaviour
{
    [Header("LeaderBoardNameStuff")]
    public GameObject nameWindow;
    public GameObject mainUI;
    public TMP_InputField nameField;

    [Header("ScoreBoard")]
    public GameObject rowPrefab;
    public Transform rowsParent;

    [Header("eventTriggersOrChecks")]
    public bool saveWaveForLeaderBoard;
    public string playername;

    [Header("scripts")]
    public SaveAndLoad saveAndLoad;

    // Start is called before the first frame update
    void Start()
    {
        Login();

        saveAndLoad.LoadData();
        saveWaveForLeaderBoard = saveAndLoad.saveWaveForLeaderBoard;
    }

    public void DontSaveScores()
    {
        mainUI.SetActive(true);
        nameWindow.SetActive(false);

        playername = null;
        saveWaveForLeaderBoard = false;

        saveAndLoad.saveWaveForLeaderBoard = saveWaveForLeaderBoard;
        saveAndLoad.SaveData();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSucces, OnError);
    }

    void OnLoginSucces(LoginResult result)
    {
        playername = null;

        if(result.InfoResultPayload.PlayerProfile != null)
        {
            playername = result.InfoResultPayload.PlayerProfile.DisplayName;
        }

        if (playername == null || playername == SystemInfo.deviceUniqueIdentifier)
        {
            mainUI.SetActive(false);
            nameWindow.SetActive(true);
            saveWaveForLeaderBoard = true;

            saveAndLoad.saveWaveForLeaderBoard = saveWaveForLeaderBoard;

            saveAndLoad.SaveData();
        }
        Debug.Log("Logged in Succesfully as" + SystemInfo.deviceUniqueIdentifier);
    }

    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameField.text
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        nameWindow.SetActive(false);
        mainUI.SetActive(true);
        
        saveWaveForLeaderBoard = true;
        saveAndLoad.saveWaveForLeaderBoard = saveWaveForLeaderBoard;
        saveAndLoad.SaveData();
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Couldnt Log In");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderBoard(int waves)
    {
        if (saveWaveForLeaderBoard)
        {
            var request = new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Mars LeaderBoard Easy",
                    Value = waves
                }
            }
            };
            PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
        }
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");
    }

    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Mars LeaderBoard Easy",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }

    void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        foreach(Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in result.Leaderboard)
        {
            GameObject newRow = Instantiate(rowPrefab, rowsParent);
            TextMeshProUGUI[] texts = newRow.GetComponentsInChildren<TextMeshProUGUI>();

            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}
