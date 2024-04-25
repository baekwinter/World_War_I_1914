using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : SingletonBase<UIManager>
{
    //�θ� UI
    public Transform parentsUI = null;
    private Dictionary<string, UIBase> _popups = new Dictionary<string, UIBase>();

    public GameObject GetPopup(string popupName)
    {
        ShowPopup(popupName);

        return _popups[popupName].gameObject;
    }

    public GameObject GetPopupObject(string popupName)
    {
        if (!_popups.ContainsKey(popupName))
        {
            return null;
        }

        return _popups[popupName].gameObject;
    }

    //�ش� �˾��� �����ϴ���
    public bool ExistPopup(string _key)
    {
        return _popups.ContainsKey(_key);
    }

    //�˾� �ҷ�����
    public UIBase ShowPopup(string popupname, Transform parents = null)
    {
        var obj = Resources.Load("Popups/" + popupname, typeof(GameObject)) as GameObject;
        if (!obj)
        {
            Debug.LogWarning($"Failed to ShowPopup({popupname})");
            return null;
        }

        //�̹� ����Ʈ�� �ش� �˾��� �����Ѵٸ� return
        if (_popups.ContainsKey(popupname))
        {
            ShowPopup(_popups[popupname].gameObject);
            return null;
        }

        return ShowPopupWithPrefab(obj, popupname, parents);
    }

    public T ShowPopup<T>(Transform parents = null) where T : UIBase
    {
        return ShowPopup(typeof(T).Name, parents) as T;
    }

    public UIBase ShowPopupWithPrefab(GameObject prefab, string popupName, Transform parents = null)
    {
        if (parentsUI != null)
            parents = parentsUI;

        string name = popupName;
        var obj = Instantiate(prefab, parents);
        obj.name = name;

        return ShowPopup(obj, popupName);
    }

    public UIBase ShowPopup(GameObject obj, string popupname)
    {
        var popup = obj.GetComponent<UIBase>();
        _popups.Add(popupname, popup);

        obj.SetActive(true);
        return popup;
    }

    public void ShowPopup(GameObject obj)
    {
        obj.SetActive(true);
    }
}