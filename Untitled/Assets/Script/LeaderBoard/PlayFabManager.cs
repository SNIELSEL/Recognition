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
    public Transform[] leaderboardlistTransforms;
    public string[] leaderboardNamesList;
    public int currentSelectedLeaderboard;
    public int currentLeaderboardToSendDataTo;

    [Header("eventTriggersOrChecks")]
    public bool saveWaveForLeaderBoard;
    public bool DeniedName;
    public string playername;

    [Header("scripts")]
    public SaveAndLoad saveAndLoad;

    // Start is called before the first frame update
    void Start()
    {
        Login();

        saveAndLoad.LoadData();
        saveWaveForLeaderBoard = saveAndLoad.saveWaveForLeaderBoard;
        DeniedName = saveAndLoad.DeniedName;
    }

    public void DontSaveScores()
    {
        mainUI.SetActive(true);
        nameWindow.SetActive(false);

        playername = null;
        saveWaveForLeaderBoard = false;
        DeniedName = true;

        saveAndLoad.DeniedName = DeniedName;
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

        if (playername == null && !DeniedName|| playername == SystemInfo.deviceUniqueIdentifier && !DeniedName)
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
        DeniedName = false;

        saveAndLoad.DeniedName = DeniedName;
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
                    StatisticName = leaderboardNamesList[currentLeaderboardToSendDataTo],
                    Value = waves
                }
            }
            };
            PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
        }
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent to " + leaderboardNamesList[currentLeaderboardToSendDataTo]);
    }

    public void SetLeaderboardTogetDataFrom(int numberToSetIntsTo)
    {
        currentLeaderboardToSendDataTo = numberToSetIntsTo;
    }

    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = leaderboardNamesList[currentLeaderboardToSendDataTo],
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }

    public void SetSelectedLeaderboardInt(int numberToSetIntsTo)
    {
        currentSelectedLeaderboard = numberToSetIntsTo;
    }

    void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        foreach(Transform item in leaderboardlistTransforms[currentSelectedLeaderboard])
        {
            Destroy(item.gameObject);
        }

        foreach(var item in result.Leaderboard)
        {
            GameObject newRow = Instantiate(rowPrefab, leaderboardlistTransforms[currentSelectedLeaderboard]);
            TextMeshProUGUI[] texts = newRow.GetComponentsInChildren<TextMeshProUGUI>();

            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
}
