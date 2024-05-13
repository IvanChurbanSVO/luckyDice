using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace luckyDice
{
    internal class Game
    {
        private int[] bets = new int[6];
        private int balance = 50;
        public void Bet(int index, Button button, Label label)
        {  
            if (balance <= 0)
            {
                return;
            }
            index--;
            bets[index]++;
            button.Text = bets[index].ToString();
            balance--;
            label.Text ="Balance " + balance.ToString();
        }

        public void Start(params PictureBox[] pictures) 
        {
            for (int i = 0; i < pictures.Length; i++)
            {
                int index = new Random().Next(1,7);
                pictures[i].Image = chooseImage(index);
                balance += bets[index-1]*2;
            }
        }
        public void Clear(Label label, params Button[] button)
        {
            label.Text = "Balance " + balance.ToString();
            for (int i = 0;i < button.Length;i++)
            {
                button[i].Text = "0";
                bets[i] = 0;
            }
        }
        private Bitmap chooseImage(int index)
        {
            return index switch
            {
                1 => Resource1._1,
                2 => Resource1._2,
                3 => Resource1._3,
                4 => Resource1._4,
                5 => Resource1._5,
                6 => Resource1._6
            };
    }
    }
}
