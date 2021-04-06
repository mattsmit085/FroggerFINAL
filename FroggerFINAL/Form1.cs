using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.IO;

namespace FroggerFINAL
{
    public partial class Form1 : Form
    {
        // VARIABLES
        int score = 0;
        bool onLog = false;

        //LISTS
        List<int> car1XList = new List<int>();
        List<int> car2XList = new List<int>();
        List<int> car1XRList = new List<int>();
        List<int> car2XRList = new List<int>();
        List<int> carSpeedList = new List<int>();
        List<int> log1XList = new List<int>();
        List<int> log2XList = new List<int>();
        List<int> log1XRList = new List<int>();
        List<int> logSpeedList = new List<int>();

        // PLAYER PROPERTIES
        int heroX = 157;
        int heroY = 510;
        int heroHeight = 50;
        int heroWidth = 30;
        int deathCount = 0;

        //IMAGES
        Image car1;
        Image car2;
        Image car3;
        Image truck;
        Image frog1;
        Image LOG = Properties.Resources.LOG;

        // OBSTACLE MOVEMENT
        int obst1Y = 452;
        int obst2Y = 396;
        int obst3Y = 337;
        int obst4Y = 282;

        int log1Y = 220;
        int log2Y = 160;
        int log3Y = 100;

        // PLAYER MOVEMENT
        bool upDown = false;
        bool downDown = false;
        bool leftDown = false;
        bool rightDown = false;
        bool moveOk = true;
        bool spaceDown = false;
        bool escDown = false;

        //SCENE
        string scene = "title";

        //SPEED
        int obst1Speed = 1;
        int obst2Speed = 2;
        int obst3Speed = 3;
        int obst4Speed = 4;
        int log1Speed = 2;
        int log2Speed = 1;
        int log3Speed = 4;

        //BRUSHES
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush goldBrush = new SolidBrush(Color.Gold);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        //SCORES
        List<string> highscore = File.ReadAllLines("highscore.txt").ToList();

        //COUNTERS
        int r1c = 149;
        int r2c = 149;
        int r3c = 149;
        int r4c = 149;
        int r5c = 149;
        int r6c = 149;
        int r7c = 119;
        int counter = 0;
        int countermax = 50;
        int countermin = 1;
        //RAND GENERATION
        Random RandGen = new Random();

        //RECTANGLES
        Rectangle heroRec;
        Rectangle obst1Rec;
        Rectangle obst2Rec;
        Rectangle obst3Rec;
        Rectangle obst4Rec;
        Rectangle log1Rec;
        Rectangle log2Rec;
        Rectangle log3Rec;

        public Form1()
        {
            InitializeComponent();
            gameTitle();
        }

        //METHODS
        public void gameInitialize()
        {
            gameOver.Visible = false;
            titleText.Text = "";
            subtitleText.Text = "";

            score = 0;

            scene = "running";

            heroX = 157;
            heroY = 510;

            obst1Y = 452;
            obst2Y = 396;
            obst3Y = 337;
            obst4Y = 282;

            log1Y = 171;
            log2Y = 115;
            log3Y = 59;

            obst1Speed = 1;
            obst2Speed = 2;
            obst3Speed = 3;
            obst4Speed = 4;
            log1Speed = 2;
            log2Speed = 1;
            log3Speed = 4;

            car1 = Properties.Resources.Car;
            car2 = Properties.Resources.Car2;
            car3 = Properties.Resources.Car3;
            truck = Properties.Resources.Truck;
            frog1 = Properties.Resources.FrogIDLE;
            froggerTimer.Enabled = true;

        }

        //SOUNDS
        SoundPlayer JumpSound = new SoundPlayer(Properties.Resources.jump);
        SoundPlayer NextLevelSound = new SoundPlayer(Properties.Resources.nextlevel);
        SoundPlayer DeathSound = new SoundPlayer(Properties.Resources.death);
        SoundPlayer EndSound = new SoundPlayer(Properties.Resources.GameOver);


        //FILES
       // string filePath = @"C:\FroggerTemp\highscores.txt";
        public void gameTitle()
        {
            Cursor.Hide();
            Form2 F2 = new Form2();
            F2.Show();
            arroLabel.Visible = false;
            titleText.Text = "FROGGER 2:\nElectric Boogaloo";
            subtitleText.Text = $"\n Space - Play || Esc - Quit\n HIGH SCORE: {highscore.Last()}";
        }

        public void obstMove()
        {
            for (int i = 0; i < log1XList.Count(); i++)
            { log1XList[i] -= log1Speed; }
            for (int i = 0; i < log2XList.Count(); i++)
            { log2XList[i] += log2Speed; }
            for (int i = 0; i < log1XRList.Count(); i++)
            { log1XRList[i] -= log3Speed; }
            for (int i = 0; i < car1XList.Count(); i++)
            { car1XList[i] += obst1Speed; }
            for (int i = 0; i < car1XRList.Count(); i++)
            { car1XRList[i] -= obst2Speed; }
            for (int i = 0; i < car2XList.Count(); i++)
            { car2XList[i] += obst3Speed; }
            for (int i = 0; i < car2XRList.Count(); i++)
            { car2XRList[i] -= obst4Speed; }
        }
        public void gameEnd()
        {
            if (deathCount == 4)
            {
                EndSound.Play();
                scene = "end";
                titleText.Text = "";
                scoreCounterLabel.Text = "";
                subtitleText.Text = $"SCORE:{score}\nSpace - Restart || Esc - Menu";
                gameOver.Visible = true;
                deathCount = 0;
                obst3Y = -50;
                obst2Y = -50;
                obst1Y = -50;
                obst4Y = -50;
                countermax = 50;
                countermin = 1;

                if (score >= Convert.ToInt32(highscore.Last()))
                {
                    File.WriteAllText("highscore.txt", Convert.ToString(score));
                    subtitleText.Text += $"\nHighscore!: {score}";
                }
            }
        }
        public void heroDead()
        {
            DeathSound.Play();
            frog1 = Properties.Resources.FrogIDLE;
            heroX = 157;
            heroY = 510;
            deathCount++;
            onLog = false;

        }
        public void addObst()
        {
            r1c++;
            if (r1c >= 200)
            {
                car1XList.Add(0);
                r1c = RandGen.Next(countermin, countermax);
            }

            r2c++;
            if (r2c >= 150)
            {
                car1XRList.Add(400);
                r2c = RandGen.Next(countermin, countermax);
            }

            r3c++;
            if (r3c >= 150)
            {
                car2XList.Add(0);
                r3c = RandGen.Next(countermin, countermax);
            }

            r4c++;
            if (r4c >= 150)
            {
                car2XRList.Add(400);
                r4c = RandGen.Next(countermin, countermax);
            }

            r5c++;
            if (r5c == 150)
            {
                log1XList.Add(400);
                r5c = RandGen.Next(1, 50);
            }

            r6c++;
            if (r6c == 200)
            {
                log2XList.Add(0);
                r6c = RandGen.Next(1, 50);
            }

            r7c++;
            if (r7c == 120)
            {
                log1XRList.Add(400);
                r7c = RandGen.Next(1, 50);
            }


        }
        public void heroMove()
        {
            // MOVEMENT
            if (upDown == true && counter >= 3 && moveOk == true)
            {
                JumpSound.Play();
                heroY -= 56;
                counter = 0;
                moveOk = false;
                frog1 = Properties.Resources.frogJUMP;
            }
            if (downDown == true && counter >= 3 && moveOk == true)
            {
                JumpSound.Play();
                heroY += 56;
                counter = 0;
                moveOk = false;
                frog1 = Properties.Resources.frogBjump;
            }
            if (rightDown == true && counter >= 3 && moveOk == true)
            {
                JumpSound.Play();
                heroX += 38;
                counter = 0;
                moveOk = false;
                frog1 = Properties.Resources.frogRjump;
            }
            if (leftDown == true && counter >= 3 && moveOk == true)
            {
                JumpSound.Play();
                heroX -= 38;
                counter = 0;
                moveOk = false;
                frog1 = Properties.Resources.frogLjump;
            }

            //FORM COLLISION
            if (heroY >= 505)
            {
                heroY = 505;
            }
            if (heroY <= 3)
            {
                heroY = 505;
                score++;
                obst1Speed++;
                obst2Speed++;
                obst3Speed++;
                obst4Speed++;
                countermax += 20;
                countermin += 20;
                arroLabel.Visible = true;

                NextLevelSound.Play();

                arroLabel.Image = Properties.Resources.arro1;
                Thread.Sleep(25);
                Refresh();
                arroLabel.Image = Properties.Resources.arro2;
                Thread.Sleep(25);
                Refresh();
                arroLabel.Image = Properties.Resources.arro3;
                Thread.Sleep(25);
                Refresh();
                arroLabel.Image = Properties.Resources.arro4;
                Thread.Sleep(25);
                Refresh();
                arroLabel.Image = Properties.Resources.arro5;
                Thread.Sleep(25);
                arroLabel.Image = null;
                Thread.Sleep(25);
                Refresh();
                arroLabel.Visible = false;
            }
            if (heroX >= 350 - heroWidth)
            {
                heroX = 350;
            }
            if (heroX <= 5)
            {
                heroX = 5;
            }
            for (int i = 0; i < log1XList.Count(); i++)
            {
                log1Rec = new Rectangle(log1XList[i], log1Y, heroWidth * 2, heroHeight);
                if (heroRec.IntersectsWith(log1Rec))
                {
                    heroX -= log1Speed;
                }
            }

            for (int i = 0; i < log1XRList.Count(); i++)
            {
                log3Rec = new Rectangle(log1XRList[i], log3Y, heroWidth * 2, heroHeight);
                if (heroRec.IntersectsWith(log3Rec))
                {
                    heroX -= log3Speed;
                }
            }

            for (int i = 0; i < log2XList.Count(); i++)
            {
                log2Rec = new Rectangle(log2XList[i], log2Y, heroWidth * 2, heroHeight);
                if (heroRec.IntersectsWith(log2Rec))
                {
                    heroX += log2Speed;
                }
            }

        }
        public void obstCollision()
        {

            heroRec = new Rectangle(heroX, heroY, heroWidth, heroHeight);

            //RECTANGLE CREATION
            for (int i = 0; i < car1XList.Count(); i++)
            {
                obst1Rec = new Rectangle(car1XList[i], obst1Y, heroWidth * 2, heroHeight);
                if (heroRec.IntersectsWith(obst1Rec))
                {
                    frog1 = Properties.Resources.FrogDEAD;
                    Refresh();
                    Thread.Sleep(1000);
                    Refresh();
                    heroDead();
                    return;
                }
            }

            for (int i = 0; i < car2XList.Count(); i++)
            {
                obst2Rec = new Rectangle(car2XList[i], obst2Y, heroWidth * 2, heroHeight);
                if (heroRec.IntersectsWith(obst2Rec))
                {
                    frog1 = Properties.Resources.FrogDEAD;
                    Refresh();
                    Thread.Sleep(1000);
                    Refresh();
                    heroDead();
                    return;
                }
            }

            for (int i = 0; i < car1XRList.Count(); i++)
            {
                obst3Rec = new Rectangle(car1XRList[i], obst3Y, heroWidth * 2, heroHeight);
                if (heroRec.IntersectsWith(obst3Rec))
                {
                    frog1 = Properties.Resources.FrogDEAD;
                    Refresh();
                    Thread.Sleep(1000);
                    Refresh();
                    heroDead();
                    return;
                }
            }
            for (int i = 0; i < car2XRList.Count(); i++)
            {
                obst4Rec = new Rectangle(car2XRList[i], obst4Y, heroWidth * 2, heroHeight);
                if (heroRec.IntersectsWith(obst4Rec))
                {
                    frog1 = Properties.Resources.FrogDEAD;
                    Refresh();
                    Thread.Sleep(1000);
                    Refresh();
                    heroDead();
                    return;
                }
            }

            //WATER SECTION
            Console.WriteLine(heroY);
            if (heroY == 169)
            {
                for (int i = 0; i < log1XList.Count(); i++)
                {
                    log1Rec = new Rectangle(log1XList[i], log1Y, heroWidth * 2, heroHeight);
                    if (heroRec.IntersectsWith(log1Rec))
                    {
                        onLog = true;
                        break;
                    }
                }
                if (onLog == false)
                {
                    frog1 = Properties.Resources.frogD1;
                    Thread.Sleep(50);
                    Refresh();
                    frog1 = Properties.Resources.frogd2;
                    Thread.Sleep(50);
                    Refresh();
                    frog1 = Properties.Resources.frogd3;
                    Thread.Sleep(50);
                    Refresh();
                    heroDead();
                }
            }
            if (heroY == 113)
            {
                for (int i = 0; i < log2XList.Count(); i++)
                {
                    log2Rec = new Rectangle(log2XList[i], log2Y, heroWidth * 2, heroHeight);
                    if (heroRec.IntersectsWith(log2Rec))
                    {
                        onLog = true;
                        break;
                    }
                }
                if (onLog == false)
                {
                    frog1 = Properties.Resources.frogD1;
                    Thread.Sleep(50);
                    Refresh();
                    frog1 = Properties.Resources.frogd2;
                    Thread.Sleep(50);
                    Refresh();
                    frog1 = Properties.Resources.frogd3;
                    Thread.Sleep(50);
                    Refresh();
                    heroDead();
                }
            }

            if (heroY == 57)
            {
                for (int i = 0; i < log1XRList.Count(); i++)
                {
                    log3Rec = new Rectangle(log1XRList[i], log3Y, heroWidth * 2, heroHeight);
                    if (heroRec.IntersectsWith(log3Rec))
                    {
                        onLog = true;
                        break;
                    }
                }
                if (onLog == false)
                {
                    frog1 = Properties.Resources.frogD1;
                    Thread.Sleep(50);
                    Refresh();
                    frog1 = Properties.Resources.frogd2;
                    Thread.Sleep(50);
                    Refresh();
                    frog1 = Properties.Resources.frogd3;
                    Thread.Sleep(50);
                    Refresh();
                    heroDead();
                }
            }
            //END GOAL
            Rectangle goalRec = new Rectangle(0, 0, 400, 56);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (scene == "running")
            {


                // LOGS

                for (int i = 0; i < log1XList.Count(); i++)
                {
                    // e.Graphics.FillRectangle(redBrush, log1XList[i], log1Y, heroWidth * 2, heroHeight);
                    e.Graphics.DrawImage(LOG, log1XList[i], log1Y, heroWidth * 2, heroHeight);
                }

                for (int i = 0; i < log2XList.Count(); i++)
                {
                    //  e.Graphics.FillRectangle(redBrush, log2XList[i], log2Y, heroWidth * 2, heroHeight);
                    e.Graphics.DrawImage(LOG, log2XList[i], log2Y, heroWidth * 2, heroHeight);
                }

                for (int i = 0; i < log1XRList.Count(); i++)
                {
                    // e.Graphics.FillRectangle(redBrush, log1XRList[i], log3Y, heroWidth * 2, heroHeight);
                    e.Graphics.DrawImage(LOG, log1XRList[i], log3Y, heroWidth * 2, heroHeight);
                }


                // CARS

                for (int i = 0; i < car1XList.Count(); i++)
                {
                    // e.Graphics.FillRectangle(redBrush, car1XList[i], obst1Y, heroWidth * 2, heroHeight);
                    e.Graphics.DrawImage(car1, car1XList[i], obst1Y, heroWidth * 2, heroHeight);
                }

                for (int i = 0; i < car2XList.Count(); i++)
                {
                    // e.Graphics.FillRectangle(redBrush, car2XList[i], obst2Y, heroWidth * 2, heroHeight);
                    e.Graphics.DrawImage(car2, car2XList[i], obst2Y, heroWidth * 2, heroHeight);
                }

                for (int i = 0; i < car1XRList.Count(); i++)
                {
                    //  e.Graphics.FillRectangle(redBrush, car1XRList[i], obst3Y, heroWidth * 2, heroHeight);
                    e.Graphics.DrawImage(car3, car1XRList[i], obst3Y, heroWidth * 2, heroHeight);
                }

                for (int i = 0; i < car2XRList.Count(); i++)
                {
                    //   e.Graphics.FillRectangle(redBrush, car2XRList[i], obst4Y, heroWidth * 2, heroHeight);
                    e.Graphics.DrawImage(truck, car2XRList[i], obst4Y, heroWidth * 4, heroHeight);
                }

                // HERO
                //  e.Graphics.FillRectangle(whiteBrush, heroX, heroY, heroWidth, heroHeight);
                e.Graphics.DrawImage(frog1, heroX, heroY, heroWidth, heroHeight);

                //END AREA
                e.Graphics.FillRectangle(goldBrush, 0, 0, 400, 56);
            }
        }

        private void froggerTimer_Tick(object sender, EventArgs e)
        {
            deathLabel.Text = $"DEATHS: {deathCount}";

            onLog = false;
            if (counter >= 8)
            {
                frog1 = Properties.Resources.FrogIDLE;
            }
            obstMove();
            addObst();
            counter++;

            //SCORE UPDATER
            scoreCounterLabel.Text = $"SCORE: {score}";

            heroMove();
            obstCollision();
            gameEnd();
            Refresh();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceDown = true;
                    if (scene == "title" || scene == "end") { gameInitialize(); }
                    break;
                case Keys.Escape:
                    if (scene == "title") { Application.Exit(); }
                   else if (scene == "end") { gameTitle(); }
                    escDown = true;
                    break;
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;

            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            moveOk = true;

            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceDown = false;
                    if (scene == "title" || scene == "end") { gameInitialize(); }
                    break;
                case Keys.Escape:
                    if (scene == "title" || scene == "end") { Application.Exit(); }
                    escDown = false;
                    break;
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
            }
        }
    }
}


