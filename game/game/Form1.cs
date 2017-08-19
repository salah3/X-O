using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        enum GameType { x , o };
        GameType start_game = GameType.x;
        int numOf_played = 0;
        Button[,] btns = new Button[3, 3];
        public Form1()
        {
            InitializeComponent();
            btns[0, 0] = bttn1;
            btns[0, 1] = bttn2;
            btns[0, 2] = bttn3;
            btns[1, 0] = bttn4;
            btns[1, 1] = bttn5;
            btns[1, 2] = bttn6;
            btns[2, 0] = bttn7;
            btns[2, 1] = bttn8;
            btns[2, 2] = bttn9;

            foreach (Button btn in btns)

                btn.Click += new EventHandler(btn_Click);

        }
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text != "")
                return;
            numOf_played++;
            btn.Text = start_game.ToString();
            if (theWineer())
            {
                MessageBox.Show(" player "   +   start_game.ToString() +  "  is win  ");
                NewGame();
                return;
            }
            if (numOf_played == 9)
            {
                MessageBox.Show("the players equals");
                NewGame();
            }
            anotherGame();
        }

        void NewGame ()
        {
            foreach (Button btn in btns)
                btn.Text = "";
            numOf_played = 0; 

 
        }
        void anotherGame()
        {
            if (start_game == GameType.x)
                start_game = GameType.o;
            else
                start_game = GameType.x;

        }
        bool theWineer()
        {
            for (int i = 0; i <= 2; i++)
            {

                if (btns[0, i].Text == start_game.ToString() 
                    && btns[0, i].Text == btns[1, i].Text
                    &&
                    btns[1, i].Text == btns[2, i].Text)
                    return true;

                if (btns[i, 0].Text == start_game.ToString() && btns[i, 0].Text == btns[i, 1].Text &&
                    btns[i,1].Text == btns[i,2].Text)
                    return true;

            }

            if (btns[0, 0].Text == start_game.ToString()
                && btns[0, 0].Text == btns[1, 1].Text
                &&
                btns[1, 1].Text == btns[2, 2].Text)
                return true;

            if (btns[0, 2].Text == start_game.ToString()
                && btns[0, 2].Text == btns[1, 1].Text
                &&
                btns[1, 1].Text == btns[2, 0].Text)
                return true;
            
                return false;



        }

       
        
    
        
    }
}
