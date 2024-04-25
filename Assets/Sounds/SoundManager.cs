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
        // 싱글톤 패턴 구현
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
        //컴포넌트 장착
        BgmSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // 초기 씬에 따라 음악 재생
        PlayMusicByScene(SceneManager.GetActiveScene().name);
        previousSceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        // 씬 전환 시 음악 재생(추후에 씬이 변경되었을때 특정함수만 호출되도록 변경할 예정)
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
