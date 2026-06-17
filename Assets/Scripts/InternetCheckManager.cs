using UnityEngine;
using UnityEngine.UI;

public class InternetCheckManager : MonoBehaviour
{
    public GameObject noInternetPanelPrefab; // Assign your "No Internet" panel prefab in the Inspector
    private GameObject noInternetPanelInstance; // Stores the instantiated panel
    private static InternetCheckManager instance; // Singleton instance

    private void Awake()
    {
        // Singleton pattern to make this GameObject persist across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Application.targetFrameRate = 60;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CheckInternetConnection();
    }

    private void OnEnable()
    {
        // Listen to scene changes to check connection status again
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        // Continuously check for internet connection changes
        CheckInternetConnection();
    }


    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        CheckInternetConnection();
    }

    private void CheckInternetConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            ShowNoInternetPanel();
        }
        else
        {
            HideNoInternetPanel();
        }
    }

    private void ShowNoInternetPanel()
    {
        Time.timeScale = 0;

        // Only instantiate if there's no existing panel
        if (noInternetPanelInstance == null)
        {
            Canvas canvas = FindObjectOfType<Canvas>(); // Finds the Canvas in the current scene
            if (canvas != null)
            {
                noInternetPanelInstance = Instantiate(noInternetPanelPrefab, canvas.transform);
            }
            else
            {
                Debug.LogWarning("No Canvas found in the scene!");
            }
        }
    }

    private void HideNoInternetPanel()
    {
        Time.timeScale = 1f;

        // Destroy the panel if the internet is available
        if (noInternetPanelInstance != null)
        {
            Destroy(noInternetPanelInstance);
        }
    }
}