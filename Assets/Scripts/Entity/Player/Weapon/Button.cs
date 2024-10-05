using UnityEngine;

public class Button : MonoBehaviour
{
    /// <summary> パネルを開く </summary>
    /// <param name="obj"> 開きたいメニューパネル </param>
    public void ShowMenu(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void DeleteMenu(GameObject obj)
    {
        obj.SetActive(false);
    }

}
