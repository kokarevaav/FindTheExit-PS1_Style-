using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject canvas;

    [SerializeField] private bool[] inventory = { false, false, false };
    [SerializeField] private Image[] icons = new Image[3];
    [SerializeField] private Transform player;

    private Vector3 _playerPosition;

    // References
    public static GameObject PlayerInstance;

    private void Start()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(player.gameObject);
        PlayerInstance = GameObject.FindWithTag("Player");
    }
    
    private void Awake()
    {
        Instance = this;
        PlayerInstance = GameObject.FindWithTag("Player");
    }

    public void AddItem(int index)
    {
        if (inventory[index])
            return;
        
        inventory[index] = true;

        if (index == 1)
        {
            
        }
        
        icons[index].GetComponent<Image>().enabled = true;
    }

    public void RemoveItem(int index)
    {
        if (!inventory[index])
            return;
        
        inventory[index] = false;
        icons[index].GetComponent<Image>().enabled = false;
    }

    public bool CheckItem(int index)
    {
        return inventory[index];
    }

    public void SetPlayerPosition(Vector3 position)
    {
        _playerPosition = position;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        player.position = _playerPosition;
    }
}
