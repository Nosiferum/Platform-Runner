using UnityEngine;

namespace DogukanKarabiyik.PlatformRunner.Managers
{
    public class MenuCanvasManager : MonoBehaviour
    {
        private void DeactivateParent()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StaticGameManager.GameStart();
                DeactivateParent();
            }
        }
    }
}

