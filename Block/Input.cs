using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TetrisFinal1
{
    class Input
    {
        // setare taste
        public Input()
        {
            leftKeyPressed = false;
            rightKeyPressed = false;
            rotateKeyPressed = false;
            downKeyPressed = false;
        }

        // procesez tasta apasata si setez valoarea 
        public void processKey(char key, Boolean pressed)
        {
            if (key == downKey)
            {
                downKeyPressed = pressed;
            }
            else if (key == leftKey)
            {
                leftKeyPressed = pressed;
            }
            else if (key == rightKey)
            {
                rightKeyPressed = pressed;
            }
            else if (key == rotateKey)
            {
                rotateKeyPressed = pressed;
            }
        }

        
        // mutare stanga
        public readonly char leftKey = 'a';

        // mutare dreapta
        public readonly char rightKey = 'd';

        // rotire
        public readonly char rotateKey = 'w';

        // mutare in jos
        public readonly char downKey = 's';


        // metoda pentru a vedea daca tastele sunt apasate sau nu
        public Boolean leftKeyPressed { get; set; }

        public Boolean rightKeyPressed { get; set; }

        public Boolean rotateKeyPressed { get; set; }

        public Boolean downKeyPressed { get; set; }


    }
}