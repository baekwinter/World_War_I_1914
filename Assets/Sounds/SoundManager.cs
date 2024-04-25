using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip introMusicClip;
    public AudioClip lobbyMusicClip;
    public AudioClip battleMusicClip;
    public AudioClip selectMusicClip;

    public AudioSource BgmSource;


    private string previousSceneName;

    void Awake()
    {
        // �̱��� ���� ����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);       
            }
        }
        //������Ʈ ����
        BgmSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // �ʱ� ���� ���� ���� ���
        PlayMusicByScene(SceneManager.GetActiveScene().name);
        previousSceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        // �� ��ȯ �� ���� ���(���Ŀ� ���� ����Ǿ����� Ư���Լ��� ȣ��ǵ��� ������ ����)
        if (SceneManager.GetActiveScene().name != previousSceneName)
        {
            PlayMusicByScene(SceneManager.GetActiveScene().name);
            previousSceneName = SceneManager.GetActiveScene().name;
        }
    }

    void PlayMusicByScene(string sceneName)
    {
        switch (sceneName)
        {
            case "Intro_Scene":
                PlayIntroMusic();
                break;
            case "Lobby_Scene":
                PlayLobbyMusic();
                break;
            case "ChapterSelect_Scene":
                PlaySelectMusic();
                break;
            case "Chapter1_Battle_Scene":
                PlayBattleMusic();
                break;
            default:
                StopAllMusic();
                break;
        }
    }

    void PlayIntroMusic()
    {
        BgmSource.clip = introMusicClip;
        BgmSource.Play();
    }

    void PlayLobbyMusic()
    {
        BgmSource.clip = lobbyMusicClip;
        BgmSource.Play();
    }

    void PlayBattleMusic()
    {
        BgmSource.clip = battleMusicClip;
        BgmSource.Play();
    }

    void PlaySelectMusic()
    {
        BgmSource.clip = selectMusicClip;
        BgmSource.Play();
    }

    void StopAllMusic()
    {
        BgmSource.Stop();
    }
}
