using UnityEngine;

namespace MiniJameGam.InputReader
{
    public class InputReaderOldInputSystem : IInputReader
    {
        public float GetHorizontalInput()
        {
            return Input.GetAxis("Horizontal");
        }

        public float GetVerticalInput()
        {
            return Input.GetAxis("Vertical");
        }
    }
}