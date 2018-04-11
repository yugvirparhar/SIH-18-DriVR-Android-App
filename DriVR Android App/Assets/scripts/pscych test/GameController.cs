using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Threading.Tasks;


public class GameController : MonoBehaviour
{

    ArrayList leaderBoard;

    private const int MaxScores = 100;
    private string logText = "";
    public InputField name;
    public InputField email;
    public InputField pass;
    public int score;
    public InputField aadhar;
    public float total;

    const int kMaxLogSize = 16382;
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;


    
    /// //////////////////////////////
   


    public Text resultText;
    public Text timetaken;
    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public GameObject uidisplay;

    private DataController dataController;
    private RoundData currentRoundData;
    private questionData[] questionPool;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore_LD, playerScore_RR;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        leaderBoard = new ArrayList();
        leaderBoard.Add("Firebase Top " + MaxScores.ToString() + " Scores");

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });

        ///////////////////////////////


        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();

        playerScore_LD = 0;
        playerScore_RR = 0;
        questionIndex = 0;

        ShowQuestion();
        isRoundActive = true;

    }



    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        questionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++) { 
        
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnsweButton answerButton = answerButtonGameObject.GetComponent<AnsweButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(int a, int b)
    {
       {
            playerScore_LD += a;
            playerScore_RR += b;
           scoreDisplayText.text = "Score: LD " + playerScore_LD.ToString() + ", RR " + playerScore_RR.ToString();
            Debug.Log("Sensibility" + playerScore_LD + " " + " Road rage" + playerScore_RR);
       }

        if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }
        else
        {
            EndRound();
            
        }

    }


    public void EndRound()
    {
        isRoundActive = false;
        timetaken.text ="Time Taken: "+ Mathf.Round(timeRemaining).ToString();
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
       //
        //uidisplay.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    public void displayResult(int a, int b)
    {
        playerScore_LD += a;
        playerScore_RR += b;
        if (playerScore_LD > playerScore_RR + 8)
        {
            resultText.text = " Well done, you are a calm, cool driver. You don't appear to be the type to jeopardize your own mental and physical well-being. Even in circumstances that would send many drivers into a blinding rage, you manage to be patient. With more people like you on the road, the streets would be a much safer place!";
        }
        else if (playerScore_RR > playerScore_LD + 8)
        {
            resultText.text = " Road Rage. One of the main problems with it is that most people afflicted by it don't recognize it the first step to steering clear of road rage is recognition of its existence.";
        }
        else if ((playerScore_LD - playerScore_RR) <= 8 || (playerScore_RR - playerScore_LD) <= 8)
        {
            resultText.text = "You are an average driver. Although there may be the rare occasion when you lose your temper, you seem to be capable of controlling yourself rather well.";
        }
        score = (playerScore_LD)*100 / (playerScore_RR + playerScore_LD) ;
        Debug.Log(score);

    }


    // Update is called once per frame
    void Update()
    {
        if (isRoundActive)
        {
            timeRemaining += Time.deltaTime;
            UpdateTimeRemainingDisplay();

            //if (timeRemaining <= 0f)
           // {
           //     EndRound();
           // }

        }
    }

    // Initialize the Firebase database:
    protected virtual void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        // NOTE: You'll need to replace this url with your Firebase App's database
        // path in order for the database connection to work correctly in editor.
        app.SetEditorDatabaseUrl("https://sihtestfb.firebaseio.com/");
        if (app.Options.DatabaseUrl != null) app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
        StartListener();
    }

    protected void StartListener()
    {
        FirebaseDatabase.DefaultInstance
          .GetReference("Leaders").OrderByChild("score")
          .ValueChanged += (object sender2, ValueChangedEventArgs e2) => {
              if (e2.DatabaseError != null)
              {
                  Debug.LogError(e2.DatabaseError.Message);
                  return;
              }
              Debug.Log("Received values for Leaders.");
              string title = leaderBoard[0].ToString();
              leaderBoard.Clear();
              leaderBoard.Add(title);
              if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0)
              {
                  foreach (var childSnapshot in e2.Snapshot.Children)
                  {
                      if (childSnapshot.Child("score") == null
                    || childSnapshot.Child("score").Value == null)
                      {
                          Debug.LogError("Bad data in sample.  Did you forget to call SetEditorDatabaseUrl with your project id?");
                          break;
                      }
                      else
                      {
                          Debug.Log("Leaders entry : " +
                        childSnapshot.Child("email").Value.ToString() + " - " +
                        childSnapshot.Child("score").Value.ToString());
                          leaderBoard.Insert(5, childSnapshot.Child("aadhar").Value.ToString()
                        + "  " + childSnapshot.Child("email").Value.ToString() + " " + childSnapshot.Child("pass").Value.ToString() + " " + childSnapshot.Child("score").Value.ToString() + " " + childSnapshot.Child("name").Value.ToString());
                      }
                  }
              }
          };
    }
    public void DebugLog(string s)
    {
        Debug.Log(s);
        logText += s + "\n";

        while (logText.Length > kMaxLogSize)
        {
            int index = logText.IndexOf("\n");
            logText = logText.Substring(index + 1);
        }
    }

    // A realtime database transaction receives MutableData which can be modified
    // and returns a TransactionResult which is either TransactionResult.Success(data) with
    // modified data or TransactionResult.Abort() which stops the transaction with no changes.
    TransactionResult AddScoreTransaction(MutableData mutableData)
    {
        List<object> leaders = mutableData.Value as List<object>;

        if (leaders == null)
        {
            leaders = new List<object>();
        }
        else if (mutableData.ChildrenCount >= MaxScores)
        {
            // If the current list of scores is greater or equal to our maximum allowed number,
            // we see if the new score should be added and remove the lowest existing score.
            long minScore = long.MaxValue;
            object minVal = null;
            foreach (var child in leaders)
            {
                if (!(child is Dictionary<string, object>))
                    continue;
                long childScore = (long)((Dictionary<string, object>)child)["score"];
                if (childScore < minScore)
                {
                    minScore = childScore;
                    minVal = child;
                }
            }
            // If the new score is lower than the current minimum, we abort.
            if (minScore > score)
            {
                return TransactionResult.Abort();
            }
            // Otherwise, we remove the current lowest to be replaced with the new score.
            leaders.Remove(minVal);
        }

        // Now we add the new score as a new entry that contains the email address and score.
        Dictionary<string, object> newScoreMap = new Dictionary<string, object>();
        newScoreMap["name"] = name.text;
        newScoreMap["aadhar"] = aadhar.text;
        newScoreMap["email"] = email.text;
        newScoreMap["pass"] = pass.text;
        newScoreMap["Sensibility_Factor"] = playerScore_LD;
        newScoreMap["Roadrage_Factor"] = playerScore_RR;
        newScoreMap["score"] = score;
        
       
       
        
        leaders.Add(newScoreMap);

        // You must set the Value to indicate data at that location has changed.
        mutableData.Value = leaders;
        return TransactionResult.Success(mutableData);
    }

    public void AddScore()
    {
        if (score == 0 || string.IsNullOrEmpty(email.text))
        {
            DebugLog("invalid score or email.");
            return;
        }
        DebugLog(String.Format("Attempting to add score {0} {1}",
          email, score));

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Leaders");

        DebugLog("Running Transaction...");
        // Use a transaction to ensure that we do not encounter issues with
        // simultaneous updates that otherwise might create more than MaxScores top scores.
        reference.RunTransaction(AddScoreTransaction)
          .ContinueWith(task => {
              if (task.Exception != null)
              {
                  DebugLog(task.Exception.ToString());
              }
              else if (task.IsCompleted)
              {
                  DebugLog("Transaction complete.");
              }
          });
    }

    public void updateDetails()
    {
        AddScore();
    }


}

