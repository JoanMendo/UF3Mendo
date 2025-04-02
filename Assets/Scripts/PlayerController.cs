using UnityEngine;

public class PlayerController : MonoBehaviour
{
   

    

    private PlayerInputData playerInputData = new PlayerInputData();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerInput(PlayerInputData data)
    {
        playerInputData = data;
    }
}
