using UnityEngine;
     
public class KeepPlayingMusic : MonoBehaviour
{  
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}   