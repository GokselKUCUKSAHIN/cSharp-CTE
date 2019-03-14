using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweaper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClearArrays();
        }
        int mineCount = 50;
        int FlagCount = 0;
        bool load = false;
        bool start = false;

        bool[,] rev = new bool[20, 20];
        byte[,] map = new byte[20, 20];
        bool[,] mine = new bool[20, 20];
        int[,] numbers = new int[20, 20];
        List<int> lsX = new List<int>();
        List<int> lsY = new List<int>();
        Graphics g;
        Bitmap bmp;
        Bitmap plate = new Bitmap("sprite.bmp");
        List<Bitmap> sprites = new List<Bitmap>();
        Pen pen = new Pen(Color.FromArgb(255, 127, 127, 127), 0.5f);
        Color fgColor = Color.Snow;
        Color bgColor = Color.FromArgb(255, 51, 51, 51);
        Color backGround;

        private void ClearArrays()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    map[i, j] = 0;
                    mine[i, j] = false;
                    numbers[i, j] = 0;
                    rev[i, j] = false;
                }
            }
        }
        private void Draw()
        {
            g = Graphics.FromImage(bmp);
            g.Clear(bgColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //AA
            //
            //Code Here
            //
            DrawSquare();
            DrawMines();
            if (start)
            {
                DrawText();
            }
            DrawText();
            //DrawGrid();
            this.Text += " Flag(" + FlagCount.ToString() + " )-";
            pictureBox1.Image = bmp;
            g.Dispose();
        }
        private void DrawGrid()
        {
            for (int i = 25; i < 526; i += 25)
            {
                Point start = new Point(25, i);
                Point end = new Point(525, i);
                g.DrawLine(pen, start, end);
            }
            for (int i = 25; i < 526; i += 25)
            {
                Point start = new Point(i, 25);
                Point end = new Point(i, 525);
                g.DrawLine(pen, start, end);
            }
        }
        private void DrawSquare()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (map[i, j] == 0)
                    {
                        //açılmamış
                        g.DrawImage(sprites[0], (i + 1) * 25, (j + 1) * 25, 25f, 25f);
                    }
                    else if (map[i, j] == 1)
                    {
                        //açılmış
                        g.DrawImage(sprites[3], (i + 1) * 25, (j + 1) * 25, 25f, 25f);
                    }
                    else if (map[i, j] == 2)
                    {
                        //bayrak
                        g.DrawImage(sprites[1], (i + 1) * 25, (j + 1) * 25, 25f, 25f);
                    }
                }
            }
        }
        private void DrawText()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (mine[i, j] == false && rev[i, j] == true)
                    {
                        if (numbers[i, j] == 0)
                        {
                            //draw void
                            TriggerZero(i, j);
                        }
                        else
                        {
                            Point Loc = new Point(((i + 1) * 25), ((j + 1) * 25));
                            g.DrawImage(sprites[numbers[i, j] + 3], Loc.X, Loc.Y, 25, 25);
                        }
                    }
                }
            }
        }
        private void DrawMines()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (mine[i, j] == true && rev[i, j] == true)
                    {
                        g.DrawImage(sprites[2], (i + 1) * 25, (j + 1) * 25, 25, 25);
                    }
                }
            }
        }
        private void ShowAllMines()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    rev[i, j] = true;
                }
            }
            Draw();
        }
        private void ClickScreen(Point e, bool Click)
        {
            Point loc = GetLocation(e.X, e.Y);
            if (e.X >= 25 && e.X <= 525)
            {
                if (e.Y >= 25 && e.Y <= 525)
                {
                    //
                    if (map[loc.Y, loc.X] == 1)
                    {
                        //açılmışsa
                        if (Click == true)
                        {
                            //sol
                            //do nothing
                        }
                        else
                        {
                            //sağ
                            if (rev[loc.Y, loc.X] == false)
                            {
                                map[loc.Y, loc.X] = 2;
                            }
                        }
                    }
                    else if (map[loc.Y, loc.X] == 2)
                    {
                        //flag
                        if (Click == true)
                        {
                            //do nothing
                        }
                        else
                        {
                            map[loc.Y, loc.X] = 0;
                        }
                    }
                    else
                    {
                        //0
                        //açılmamış
                        if (Click == true)
                        {
                            map[loc.Y, loc.X] = 1;
                            rev[loc.Y, loc.X] = true;
                            if (mine[loc.Y, loc.X] == true)
                            {
                                //you died;
                                ShowAllMines();
                            }
                        }
                        else
                        {
                            if (rev[loc.Y, loc.X] == false)
                            {
                                map[loc.Y, loc.X] = 2;
                            }
                        }
                    }
                }
            }
        }
        private Point GetLocation(int x, int y)
        {
            int rx = x / 25;
            int ry = y / 25;
            return new Point(ry - 1, rx - 1);
        }
        private void RandMine(Point except)
        {
            Random r = new Random();
            int count = mineCount;
            while (count != 0)
            {
                int row = r.Next(0, 20);
                System.Threading.Thread.Sleep(1);
                int colm = r.Next(0, 20);
                if (mine[row, colm] == false && (row != except.X && colm != except.Y))
                {
                    mine[row, colm] = true;
                    count--;
                }
            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    numbers[i, j] = CountMine(new Point(i, j));
                }
            }
        }
        private int CountMine(Point p)
        {
            int x = p.X;
            int y = p.Y;
            int count = 0;
            if (x >= 0 && x <= 19)
            {
                if (y >= 0 && y <= 19)
                {
                    if (x - 1 >= 0)
                    {
                        if (y - 1 >= 0)
                        {
                            if (mine[x - 1, y - 1] == true)
                            {
                                count++;
                            }
                        }
                    }
                    if (x - 1 >= 0)
                    {
                        if (mine[x - 1, y] == true)
                        {
                            count++;
                        }
                    }
                    if (x - 1 >= 0)
                    {
                        if (y + 1 <= 19)
                        {
                            if (mine[x - 1, y + 1] == true)
                            {
                                count++;
                            }
                        }
                    }
                    if (y - 1 >= 0)
                    {
                        if (mine[x, y - 1] == true)
                        {
                            count++;
                        }
                    }
                    if (y + 1 <= 19)
                    {
                        if (mine[x, y + 1] == true)
                        {
                            count++;
                        }
                    }
                    if (x + 1 <= 19)
                    {
                        if (y - 1 >= 0)
                        {
                            if (mine[x + 1, y - 1] == true)
                            {
                                count++;
                            }
                        }
                    }
                    if (x + 1 <= 19)
                    {
                        if (mine[x + 1, y] == true)
                        {
                            count++;
                        }
                    }
                    if (x + 1 <= 19)
                    {
                        if (y + 1 <= 19)
                        {
                            if (mine[x + 1, y + 1] == true)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        this.Text = "LEFT";
                        Draw();
                        //sol tik

                        if (!start)
                        {
                            ClearArrays();
                            RandMine(GetLocation(e.Location.Y, e.Location.X));
                            start = true;
                        }
                        ClickScreen(e.Location, true);


                        Draw();
                        Draw();
                        if (CheckGame(mineCount))
                        {
                            this.BackColor = Color.Red;
                        }
                        Point BEta = GetLocation(e.Location.Y, e.Location.X);//beta
                        this.Text += " (" + BEta.Y + ", " + BEta.X + ")";//beta
                        break;
                    }
                case MouseButtons.Right:
                    {
                        this.Text = "RIGHT";
                        //sağ tik

                        if (start)
                        {
                            ClickScreen(e.Location, false);
                            Draw();
                            this.Text += " (" + e.Location.X + ", " + e.Location.Y + ")";
                        }
                        if (CheckGame(mineCount))
                        {
                            this.BackColor = Color.Red;
                            this.Text = "YOU WON!";
                        }
                        break;
                    }
                default:
                    {
                        this.Text = "DEFAULT";
                        //orta tik
                        break;
                    }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GameStart();
        }
        private void GameStart()
        {
            if (load == false)
            {
                bmp = new Bitmap(551, 551);
                load = true;
                LoadSprites();
                backGround = this.BackColor;
                //loading...
            }
            Draw();
        }
        private void LoadSprites()
        {
            //plate = new Bitmap(pictureBox1.Width + 1, pictureBox1.Height + 1);
            for (int y = 0; y < 192; y += 64)
            {
                for (int x = 0; x < 256; x += 64)
                {
                    //25,25 sprite size
                    Rectangle Rekt = new Rectangle(x, y, 64, 64);
                    sprites.Add(plate.Clone(Rekt, plate.PixelFormat));
                }
            }
        }
        private bool CheckGame(int winLimit)
        {
            int fcount = 0;
            bool win = true;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (map[i, j] == 2)
                    {
                        fcount++;
                        if (mine[i, j] != true)
                        {
                            win = false;
                        }
                    }
                }
            }
            FlagCount = fcount;
            if (win && fcount == winLimit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void ResetGame()
        {
            ClearArrays();
            GameStart();
            start = false;
            this.BackColor = backGround;
        }

        /*beta*/

        //Check
        private bool CheckLeft(int i, int j)
        {
            //i,j-1
            if (numbers[i, j - 1] == 0 && rev[i, j - 1] == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckTop(int i, int j)
        {
            //i-1,j
            if (numbers[i - 1, j] == 0 && rev[i - 1, j] == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckRight(int i, int j)
        {
            //i,j+1
            if (numbers[i, j + 1] == 0 && rev[i, j + 1] == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckBottom(int i, int j)
        {
            //i+1,j
            if (numbers[i + 1, j] == 0 && rev[i + 1, j] == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Open Functions
        private void TopLeft_(int i, int j)
        {
            //i-1, j-1
            rev[i - 1, j - 1] = true;
            map[i - 1, j - 1] = 1;
        }
        private void Top_(int i, int j)
        {
            //i-1, j
            rev[i - 1, j] = true;
            map[i - 1, j] = 1;
        }
        private void TopRight_(int i, int j)
        {
            //i-1,j+1
            rev[i - 1, j + 1] = true;
            map[i - 1, j + 1] = 1;
        }
        private void Right_(int i, int j)
        {
            //i,j+1
            rev[i, j + 1] = true;
            map[i, j + 1] = 1;
        }
        private void BottomRight_(int i, int j)
        {
            //i+1,j+1
            rev[i + 1, j + 1] = true;
            map[i + 1, j + 1] = 1;
        }
        private void Bottom_(int i, int j)
        {
            //i+1,j
            rev[i + 1, j] = true;
            map[i + 1, j] = 1;
        }
        private void BottomLeft_(int i, int j)
        {
            //i+1,j-1
            rev[i + 1, j - 1] = true;
            map[i + 1, j - 1] = 1;
        }
        private void Left_(int i, int j)
        {
            //i,j-1
            rev[i, j - 1] = true;
            map[i, j - 1] = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
        private void TriggerZero2(int i, int j)
        {
            rev[i, j] = true;
            g.DrawImage(sprites[3], (i + 1) * 25, (j + 1) * 25, 25, 25);
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (j + y < 0 || j + y > 19) 
                    {
                        //OutOfRange
                    }
                    else if (i + x < 0 || i + x > 19) 
                    {
                        //OutOfRange
                    }
                    else
                    {
                        if (numbers[i + x, j + y] == 0 && rev[i + x, j + y] == false) 
                        {
                            TriggerZero(i + x, j + y);
                        }
                        else
                        {
                            rev[i + x, j + y] = true;
                            map[i + x, j + y] = 1;
                        }
                    }
                }
            }
        }
        private void TriggerZero(int i, int j)
        {
            rev[i, j] = true;
            //tmp = new Rectangle((i + 1) * 25, (j + 1) * 25, 25, 25);
            //g.FillRectangle(zero, tmp);
            g.DrawImage(sprites[3], (i + 1) * 25, (j + 1) * 25, 25, 25);
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (i - 1 < 0 || i + 1 > 19)
                    {
                        //OutOfRange
                        if (j + 1 <= 19 && j - 1 >= 0)
                        {
                            if (numbers[i, j + y] == 0 && rev[i, j + y] == false)
                            {
                                TriggerZero(i, j + y);
                            }
                            else
                            {
                                rev[i, j + y] = true;
                                map[i, j + y] = 1;
                            }
                        }
                    }
                    else
                    {
                        if (j - 1 < 0 || j + 1 > 19)
                        {
                            //OutOfRange
                            if (i + 1 <= 19 && i - 1 >= 0)
                            {
                                if (numbers[i + x, j] == 0 && rev[i + x, j] == false)
                                {
                                    TriggerZero(i + x, j);
                                }
                                else
                                {
                                    rev[i + x, j] = true;
                                    map[i + x, j] = 1;
                                }
                            }
                        }
                        else
                        {
                            //in squares
                            if (numbers[i + x, j + y] == 0 && rev[i + x, j + y] == false)
                            {
                                TriggerZero(i + x, j + y);
                            }
                            else
                            {
                                rev[i + x, j + y] = true;
                                map[i + x, j + y] = 1;
                            }
                        }
                    }
                }
            }


            /*
            lsX.Add(i);
            lsY.Add(j);
            //4 yönü kontrol et
            for (int cont = 0; cont < lsX.Count; cont++)
            {
                if(lsX[cont]-1 == -1)
                {
                    if (lsY[cont] - 1 == -1)
                    {
                        //sol üst köşe 
                        //
                        //sağ ve altını kontrol et 
                        if(CheckBottom(lsY[cont],lsX[cont]))
                        {
                            lsX.Add(lsX[cont] + 1);
                            lsY.Add(lsY[cont]);
                        }
                        if (CheckRight(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont]);
                            lsY.Add(lsY[cont] + 1);
                        }
                        //ve etrafını aç
                        Right_(lsY[cont], lsX[cont]);
                        Bottom_(lsY[cont], lsX[cont]);
                        BottomRight_(lsY[cont], lsX[cont]);
                    }
                    else if (lsY[cont] + 1 == 20)
                    {
                        //sağ üst köşe
                        //
                        //sol ve altını kontrol et
                        if (CheckBottom(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont] + 1);
                            lsY.Add(lsY[cont]);
                        }
                        if (CheckLeft(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont]);
                            lsY.Add(lsY[cont] - 1);
                        }
                        //ve etrafını aç
                        Left_(lsY[cont], lsX[cont]);
                        Bottom_(lsY[cont], lsX[cont]);
                        BottomLeft_(lsY[cont], lsX[cont]);
                    }
                    else
                    {
                        //üst kenar
                        //
                        //sol, sağ ve altını kontrol et
                        if (CheckBottom(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont] + 1);
                            lsY.Add(lsY[cont]);
                        }
                        if (CheckLeft(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont]);
                            lsY.Add(lsY[cont] - 1);
                        }
                        if (CheckRight(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont]);
                            lsY.Add(lsY[cont] + 1);
                        }
                        //ve etrafını aç
                        Right_(lsY[cont], lsX[cont]);
                        BottomRight_(lsY[cont], lsX[cont]);
                        Bottom_(lsY[cont], lsX[cont]);
                        BottomLeft_(lsY[cont], lsX[cont]);
                        Left_(lsY[cont], lsX[cont]);
                    }
                }
                else if(lsX[cont]+1 == 20)
                {
                    if (lsY[cont] - 1 == -1)
                    {
                        //sol alt köşe
                        //
                        //sağ ve üstünü kontrol et
                        if (CheckTop(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont] - 1);
                            lsY.Add(lsY[cont]);
                        }
                        if (CheckRight(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont]);
                            lsY.Add(lsY[cont] + 1);
                        }
                        //ve etrafını aç
                        Right_(lsY[cont], lsX[cont]);
                        Top_(lsY[cont], lsX[cont]); 
                        TopRight_(lsY[cont], lsX[cont]);
                    }
                    else if (lsY[cont] + 1 == 20)
                    {
                        //sağ alt köşe
                        //
                        //sol ve üstünü kontrol et
                        if (CheckTop(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont] - 1);
                            lsY.Add(lsY[cont]);
                        }
                        if (CheckLeft(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont]);
                            lsY.Add(lsY[cont] - 1);
                        }
                        //ve etrafını aç
                        Top_(lsY[cont], lsX[cont]);
                        Left_(lsY[cont], lsX[cont]);
                        TopLeft_(lsY[cont], lsX[cont]);
                    }
                    else
                    {
                        //alt kenar
                        //
                        //sol, sağ ve üstünü kontrol et
                        if (CheckTop(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont] - 1);
                            lsY.Add(lsY[cont]);
                        }
                        if (CheckLeft(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont]);
                            lsY.Add(lsY[cont] - 1);
                        }
                        if (CheckRight(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont]);
                            lsY.Add(lsY[cont] + 1);
                        }
                        //ve etrafını aç
                        Left_(lsY[cont], lsX[cont]);
                        TopLeft_(lsY[cont], lsX[cont]);
                        Top_(lsY[cont], lsX[cont]);
                        TopRight_(lsY[cont], lsX[cont]);
                        Right_(lsY[cont], lsX[cont]);
                    }
                }
                else
                {
                    //
                    if (lsY[cont] -1 == -1)
                    {
                        //sol kenar
                        //
                        //üst alt ve sağını kontrol et
                        if (CheckRight(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont]);
                            lsY.Add(lsY[cont] + 1);
                        }
                        if (CheckTop(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont] - 1);
                            lsY.Add(lsY[cont]);
                        }
                        if (CheckBottom(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont] + 1);
                            lsY.Add(lsY[cont]);
                        }
                        //ve etrafını aç
                        Top_(lsY[cont], lsX[cont]);
                        TopRight_(lsY[cont], lsX[cont]);
                        Right_(lsY[cont], lsX[cont]);
                        BottomRight_(lsY[cont], lsX[cont]);
                        Bottom_(lsY[cont], lsX[cont]);
                    }
                    else if (lsY[cont] + 1 == 20)
                    {
                        //sağ kenar
                        //
                        //üst alt ve solunu kontrol et
                        if (CheckLeft(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont]);
                            lsY.Add(lsY[cont] - 1);
                        }
                        if (CheckTop(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont] - 1);
                            lsY.Add(lsY[cont]);
                        }
                        if (CheckBottom(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont] + 1);
                            lsY.Add(lsY[cont]);
                        }
                        //ve etrafını aç
                        Top_(lsY[cont], lsX[cont]);
                        TopLeft_(lsY[cont], lsX[cont]);
                        Left_(lsY[cont], lsX[cont]);
                        BottomLeft_(lsY[cont], lsX[cont]);
                        Bottom_(lsY[cont], lsX[cont]);
                    }
                    else
                    {
                        //içeride bir yerler
                        //
                        //sol, üst , alt , sağını kontrol et
                        if (CheckLeft(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont]);
                            lsY.Add(lsY[cont] - 1);
                        }
                        if (CheckTop(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont] - 1);
                            lsY.Add(lsY[cont]);
                        }
                        if (CheckBottom(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont] + 1);
                            lsY.Add(lsY[cont]);
                        }
                        if (CheckRight(lsY[cont], lsX[cont]))
                        {
                            lsX.Add(lsX[cont]);
                            lsY.Add(lsY[cont] + 1);
                        }
                        //ve etrafını aç
                        Top_(lsY[cont], lsX[cont]);
                        TopLeft_(lsY[cont], lsX[cont]);
                        Left_(lsY[cont], lsX[cont]);
                        BottomLeft_(lsY[cont], lsX[cont]);
                        Bottom_(lsY[cont], lsX[cont]);
                        BottomRight_(lsY[cont], lsX[cont]);
                        Right_(lsY[cont], lsX[cont]);
                        TopRight_(lsY[cont], lsX[cont]);
                    }
                }
            }
            */
            /*
            if (numbers[i, j + y] == 0 && rev[i, j + y] == false)
            {
                TriggerZero(i, j + y);
            }
            else
            {
                rev[i, j + y] = true;
                map[i, j + y] = 1;
            }
            */
        }
        /*
        private void TriggerZero(int i, int j)
        {
            lsX.Add(i);
            lsY.Add(j);
            rev[i, j] = true;
            g.DrawImage(sprites[3], (i + 1) * 25, (j + 1) * 25, 25, 25);
            if (lsX[cont] == 0 && lsY[cont] == 0)
            {
                //sol üst
                //
                //alt, sağ kontrol et
                if (CheckBottom(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont] + 1);
                    lsY.Add(lsY[cont]);
                    cont++;
                }
                if (CheckRight(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont]);
                    lsY.Add(lsY[cont] + 1);
                    cont++;
                }
                //sağ, sağ-alt,alt ı aç.
                //ve etrafını aç
                Right_(lsY[cont], lsX[cont]);
                Bottom_(lsY[cont], lsX[cont]);
                BottomRight_(lsY[cont], lsX[cont]);
            }
            else if (lsX[cont] == 19 && lsY[cont] == 0)
            {
                //sol alt köşe
                //
                //sağ ve üstünü kontrol et
                if (CheckTop(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont] - 1);
                    lsY.Add(lsY[cont]);
                    cont++;
                }
                if (CheckRight(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont]);
                    lsY.Add(lsY[cont] + 1);
                    cont++;
                }
                //ve etrafını aç
                Right_(lsY[cont], lsX[cont]);
                Top_(lsY[cont], lsX[cont]);
                TopRight_(lsY[cont], lsX[cont]);
            }
            else if (lsX[cont] == 0 && lsY[cont] == 19)
            {
                //sağ üst köşe
                //
                //sol ve altını kontrol et
                if (CheckBottom(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont] + 1);
                    lsY.Add(lsY[cont]);
                    cont++;
                }
                if (CheckLeft(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont]);
                    lsY.Add(lsY[cont] - 1);
                    cont++;
                }
                //ve etrafını aç
                Left_(lsY[cont], lsX[cont]);
                Bottom_(lsY[cont], lsX[cont]);
                BottomLeft_(lsY[cont], lsX[cont]);
            }
            else if (lsX[cont] == 19 && lsY[cont] == 19)
            {
                //sağ alt köşe
                //
                //sol ve üstünü kontrol et
                if (CheckTop(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont] - 1);
                    lsY.Add(lsY[cont]);
                    cont++;
                }
                if (CheckLeft(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont]);
                    lsY.Add(lsY[cont] - 1);
                    cont++;
                }
                //ve etrafını aç
                Top_(lsY[cont], lsX[cont]);
                Left_(lsY[cont], lsX[cont]);
                TopLeft_(lsY[cont], lsX[cont]);
            }
            else if (lsX[cont] == 0 && lsY[cont] - 1 >= 0 && lsY[cont] + 1 <= 19)
            {
                //üst kenar
                //
                //sol, sağ ve altını kontrol et
                if (CheckBottom(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont] + 1);
                    lsY.Add(lsY[cont]);
                    cont++;
                }
                if (CheckLeft(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont]);
                    lsY.Add(lsY[cont] - 1);
                    cont++;
                }
                if (CheckRight(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont]);
                    lsY.Add(lsY[cont] + 1);
                    cont++;
                }
                //ve etrafını aç
                Right_(lsY[cont], lsX[cont]);
                BottomRight_(lsY[cont], lsX[cont]);
                Bottom_(lsY[cont], lsX[cont]);
                BottomLeft_(lsY[cont], lsX[cont]);
                Left_(lsY[cont], lsX[cont]);
            }
            else if (lsX[cont] == 19 && lsY[cont] - 1 >= 0 && lsY[cont] + 1 <= 19)
            {
                //alt kenar
                //
                //sol, sağ ve üstünü kontrol et
                if (CheckTop(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont] - 1);
                    lsY.Add(lsY[cont]);
                    cont++;
                }
                if (CheckLeft(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont]);
                    lsY.Add(lsY[cont] - 1);
                    cont++;
                }
                if (CheckRight(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont]);
                    lsY.Add(lsY[cont] + 1);
                    cont++;
                }
                //ve etrafını aç
                Left_(lsY[cont], lsX[cont]);
                TopLeft_(lsY[cont], lsX[cont]);
                Top_(lsY[cont], lsX[cont]);
                TopRight_(lsY[cont], lsX[cont]);
                Right_(lsY[cont], lsX[cont]);
            }
            else if (lsY[cont] == 0 && lsX[cont] - 1 >= 0 && lsX[cont] + 1 <= 19)
            {
                //sol kenar
                //
                //üst alt ve sağını kontrol et
                if (CheckRight(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont]);
                    lsY.Add(lsY[cont] + 1);
                    cont++;
                }
                if (CheckTop(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont] - 1);
                    lsY.Add(lsY[cont]);
                    cont++;
                }
                if (CheckBottom(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont] + 1);
                    lsY.Add(lsY[cont]);
                    cont++;
                }
                //ve etrafını aç
                Top_(lsY[cont], lsX[cont]);
                TopRight_(lsY[cont], lsX[cont]);
                Right_(lsY[cont], lsX[cont]);
                BottomRight_(lsY[cont], lsX[cont]);
                Bottom_(lsY[cont], lsX[cont]);
            }
            else if (lsY[cont] == 19 && lsX[cont] - 1 >= 0 && lsX[cont] + 1 <= 19)
            {
                //sağ kenar
                //
                //üst alt ve solunu kontrol et
                if (CheckLeft(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont]);
                    lsY.Add(lsY[cont] - 1);
                    cont++;
                }
                if (CheckTop(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont] - 1);
                    lsY.Add(lsY[cont]);
                    cont++;
                }
                if (CheckBottom(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont] + 1);
                    lsY.Add(lsY[cont]);
                    cont++;
                }
                //ve etrafını aç
                Top_(lsY[cont], lsX[cont]);
                TopLeft_(lsY[cont], lsX[cont]);
                Left_(lsY[cont], lsX[cont]);
                BottomLeft_(lsY[cont], lsX[cont]);
                Bottom_(lsY[cont], lsX[cont]);
            }
            else if (lsX[cont] >= 0 && lsX[cont] <= 19 && j >= 0 && j <= 19)
            {
                //geri kalan her hangi bir konum.
                //içeride bir yerler
                //
                //sol, üst , alt , sağını kontrol et
                if (CheckLeft(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont]);
                    lsY.Add(lsY[cont] - 1);
                    cont++;
                }
                if (CheckTop(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont] - 1);
                    lsY.Add(lsY[cont]);
                    cont++;
                }
                if (CheckBottom(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont] + 1);
                    lsY.Add(lsY[cont]);
                    cont++;
                }
                if (CheckRight(lsY[cont], lsX[cont]))
                {
                    lsX.Add(lsX[cont]);
                    lsY.Add(lsY[cont] + 1);
                    cont++;
                }
                //ve etrafını aç
                Top_(lsY[cont], lsX[cont]);
                TopLeft_(lsY[cont], lsX[cont]);
                Left_(lsY[cont], lsX[cont]);
                BottomLeft_(lsY[cont], lsX[cont]);
                Bottom_(lsY[cont], lsX[cont]);
                BottomRight_(lsY[cont], lsX[cont]);
                Right_(lsY[cont], lsX[cont]);
                TopRight_(lsY[cont], lsX[cont]);
            }
            /*
            //in squares
            if (numbers[i + x, j + y] == 0 && rev[i + x, j + y] == false)
            {
                TriggerZero(i + x, j + y);
            }
            else
            {
                rev[i + x, j + y] = true;
                map[i + x, j + y] = 1;
                */
    }
}