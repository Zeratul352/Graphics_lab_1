using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_lab_1
{
    public partial class MainWindow : Form
    {
        int[,] StatusGrid;
        Dictionary<Tuple<int, int>, int> extrapoints;
        bool ignoreboarderflag = false;
        bool gridflag = false;
        static int step = 3;
        static int count = 600 / step;
        int termitex = count/ 2 - 1;
        int termitey = count/ 2 - 1;
        int tickcount = 300;
        char termitestate = 'A';
        List<Tuple<int, int>> directions;
        int currentdirection = 0;
        Random random = new Random();
        List<Color> brushes = new List<Color>();
        Dictionary<Tuple<char, int>, Tuple<int, int, char>> rule;
        static Bitmap map = new Bitmap(count * step, count * step);
        string filename = "Default";
        public MainWindow()
        {
            InitializeComponent();
            
            StatusGrid = new int[count, count];
            for(int i = 0; i < count; i++)
            {
                for(int j = 0; j < count; j++)
                {
                    StatusGrid[i, j] = 0;
                }
            }
            //adding colors to palitre
            brushes.Add(Color.Black);
            brushes.Add(Color.White);
            brushes.Add(Color.Red);
            brushes.Add(Color.Lime);
            brushes.Add(Color.Blue);
            brushes.Add(Color.Yellow);
            brushes.Add(Color.Aqua);
            brushes.Add(Color.Magenta);
            brushes.Add(Color.Silver);
            brushes.Add(Color.Gray);
            brushes.Add(Color.Maroon);
            brushes.Add(Color.Olive);
            brushes.Add(Color.Green);
            brushes.Add(Color.Purple);
            brushes.Add(Color.Teal);
            brushes.Add(Color.Navy);
            //adding rule
            rule = new Dictionary<Tuple<char, int>, Tuple<int, int, char>>();
            rule.Add(new Tuple<char, int>('A', 0), new Tuple<int, int, char>(12, 0, 'C'));
            rule.Add(new Tuple<char, int>('A', 12), new Tuple<int, int, char>(0, 0, 'B'));
            rule.Add(new Tuple<char, int>('B', 12), new Tuple<int, int, char>(12, 1, 'A'));
            rule.Add(new Tuple<char, int>('B', 3), new Tuple<int, int, char>(12, 1, 'A'));
            rule.Add(new Tuple<char, int>('C', 12), new Tuple<int, int, char>(0, -1, 'A'));
            rule.Add(new Tuple<char, int>('C', 0), new Tuple<int, int, char>(3, -1, 'A'));
            rule.Add(new Tuple<char, int>('C', 3), new Tuple<int, int, char>(12, -1, 'A'));
            //
            directions = new List<Tuple<int, int>>();
            directions.Add(new Tuple<int, int>(0, 1));
            directions.Add(new Tuple<int, int>(1, 0));
            directions.Add(new Tuple<int, int>(0, -1));
            directions.Add(new Tuple<int, int>(-1, 0));
            //map.SetResolution(16, 1600);
            //Picture.CreateGraphics();
            //saveFileDialog1.Filter = "Text files"
        }
        private void Init()
        {
            timer.Stop();
            comboBox1.Enabled = true;
            StopButton.Enabled = true;
            save.Enabled = true;
            openfile.Enabled = true;
            TryDraw.Text = "Draw";
            DrawGrid.Text = "Draw grid";
            count = 600 / step;
            StatusGrid = new int[count, count];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    StatusGrid[i, j] = 0;
                }
            }
            map = new Bitmap(step * count, step * count);
            termitex = count / 2 - 1;
            termitey = count / 2 - 1;
            termitestate = 'A';
            //List<Tuple<int, int>> directions;
            currentdirection = 0;
            Picture.Image = map;
            ignoreboarderflag = false;
            gridflag = false;
            Ignore.Text = "Ignore boarder";
            extrapoints = null;
            //extrapoints = new Dictionary<Tuple<int, int>, int>();
        }
        private void TryDraw_Click(object sender, EventArgs e)
        {
            Graphics drawer = Picture.CreateGraphics();
            if (timer.Enabled)
            {
                TryDraw.Text = "Draw";
                timer.Stop();
                comboBox1.Enabled = true;
                StopButton.Enabled = true;
                save.Enabled = true;
                openfile.Enabled = true;
                return;
            }
            timer.Start();
            TryDraw.Text = "Stop drawing";
            openfile.Enabled = false;
            comboBox1.Enabled = false;
            StopButton.Enabled = false;
            save.Enabled = false;
            //drawer.DrawPolygon(new Pen(Color.Red), [new Point(100, 100), new Point(120, 100), new Point(120, 120), new Point(100, 120)]);
        }

        private void DrawGrid_Click(object sender, EventArgs e)
        {
            if (gridflag)
            {
                gridflag = true;
                DrawGrid.Text = "Draw grid";
                using (Graphics graphics = Graphics.FromImage(map))
                {
                    for (int i = 0; i <= count * step; i += step)
                    {
                        graphics.DrawLine(new Pen(Brushes.Black, 1), new Point(1, i), new Point(step * count - 1, i));
                        graphics.DrawLine(new Pen(Brushes.Black, 1), new Point(i, 1), new Point(i, step * count - 1));
                    }
                }
                Picture.Image = map;
                gridflag = false;
                return;
            }
            gridflag = true;
            DrawGrid.Text = "Remove grid";
            using(Graphics graphics = Graphics.FromImage(map))
            {
                for (int i = 0; i <= count * step; i += step)
                {
                    graphics.DrawLine(new Pen(Brushes.White, 1), new Point(1, i), new Point(step * count - 1, i));
                    graphics.DrawLine(new Pen(Brushes.White, 1), new Point(i, 1), new Point(i, step * count - 1));
                }
            }
            Picture.Image = map;
        }
        private bool Rule(int x, int y)
        {
            if (x < 0 || y < 0 || x >= count || y >= count)
            {
                return false;
            }
            Random random = new Random();
            int res = random.Next(1000);
            if(res % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Draw(int x, int y, int color)
        {
            if(x < 0 || y < 0 || x >= count || y >= count)
            {
                return;
            }
            /*if(StatusGrid[x, y] == 1)
            {
                return;
            }*/
            //Picture.Image = new Bitmap(count * step, count * step);
            StatusGrid[x, y] = color;
            //Graphics.FromImage(map);
           

            Graphics graphics = Picture.CreateGraphics();
            //new Point[4] point;
            
            for(int i = x * step + 1; i < x * step + step; i++)
            {
                for(int j = y * step + 1; j < y * step + step; j++)
                {
                    map.SetPixel(i, j, brushes[color]);
                }
            }
            Picture.Image = map;
            
            //graphics.FillRectangle(Brushes.Green, x * step + 1, y * step + 1, step - 1, step - 1);
        }

        private void Picture_MouseClick(object sender, MouseEventArgs e)
        {
            Init();
            termitex = e.X / step;
            termitey = e.Y / step;
            //x = x - x % 10;
            //y = y - y % 10;
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
           


                for (int i = 0; i < tickcount; i++)
                {
                try
                {


                    var action = rule[new Tuple<char, int>(termitestate, StatusGrid[termitex, termitey])];
                    Draw(termitex, termitey, action.Item1);
                    termitestate = action.Item3;
                    currentdirection = (currentdirection + action.Item2 + 4) % 4;
                    termitex += directions[currentdirection].Item1;
                    termitey += directions[currentdirection].Item2;
                    //Picture.Image = map;
                }
                catch
                {
                    try
                    {


                        Tuple<int, int> point = new Tuple<int, int>(termitex, termitey);
                        if (extrapoints.ContainsKey(point))
                        {
                            var action = rule[new Tuple<char, int>(termitestate, extrapoints[point])];
                            extrapoints[point] = action.Item1;
                            termitestate = action.Item3;
                            currentdirection = (currentdirection + action.Item2 + 4) % 4;
                            termitex += directions[currentdirection].Item1;
                            termitey += directions[currentdirection].Item2;
                        }
                        else
                        {
                            var action = rule[new Tuple<char, int>(termitestate, 0)];
                            extrapoints.Add(point, action.Item1);
                            termitestate = action.Item3;
                            currentdirection = (currentdirection + action.Item2 + 4) % 4;
                            termitex += directions[currentdirection].Item1;
                            termitey += directions[currentdirection].Item2;
                        }
                    }
                    catch
                    {
                        //timer.Stop();
                    }
                }
                }
            
            
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {


                var action = rule[new Tuple<char, int>(termitestate, StatusGrid[termitex, termitey])];
                Draw(termitex, termitey, action.Item1);
                termitestate = action.Item3;
                currentdirection = (currentdirection + action.Item2 + 4) % 4;
                termitex += directions[currentdirection].Item1;
                termitey += directions[currentdirection].Item2;
                Picture.Image = map;
            }
            catch
            {
                try
                {


                    Tuple<int, int> point = new Tuple<int, int>(termitex, termitey);
                    if (extrapoints.ContainsKey(point))
                    {
                        var action = rule[new Tuple<char, int>(termitestate, extrapoints[point])];
                        extrapoints[point] = action.Item1;
                        termitestate = action.Item3;
                        currentdirection = (currentdirection + action.Item2 + 4) % 4;
                        termitex += directions[currentdirection].Item1;
                        termitey += directions[currentdirection].Item2;
                    }
                    else
                    {
                        var action = rule[new Tuple<char, int>(termitestate, 0)];
                        extrapoints.Add(point, action.Item1);
                        termitestate = action.Item3;
                        currentdirection = (currentdirection + action.Item2 + 4) % 4;
                        termitex += directions[currentdirection].Item1;
                        termitey += directions[currentdirection].Item2;
                    }
                }
                catch
                {
                    timer.Stop();
                }
            }
        }

        private void Ignore_Click(object sender, EventArgs e)
        {
            if (ignoreboarderflag)
            {
                extrapoints = null;
                Ignore.Text = "Ignore boarder";
                ignoreboarderflag = false;
                return;
            }
            
            Ignore.Text = "Make boarder";
            ignoreboarderflag = true;
            extrapoints = new Dictionary<Tuple<int, int>, int>();
        }

        private void openfile_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Dictionary<Tuple<char, int>, Tuple<int, int, char>> newrule = new Dictionary<Tuple<char, int>, Tuple<int, int, char>>();
                try
                {
                    
                    using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                    {
                        var data = reader.ReadToEnd();
                        var lines = data.Split('\n');
                        foreach(var line in lines){
                            var line2 = line.Split('\r')[0];
                            var line1 = line2.Split(' ');
                            char elem1 = System.Convert.ToChar(line1[0]);
                            
                            int elem2 = System.Convert.ToInt32(line1[1]);
                            int elem3 = System.Convert.ToInt32(line1[2]);
                            int elem4 = System.Convert.ToInt32(line1[3]);
                            char elem5 = System.Convert.ToChar(line1[4]);
                            newrule.Add(new Tuple<char, int>(elem1, elem2), new Tuple<int, int, char>(elem3, elem4, elem5));
                        }
                        rule = new Dictionary<Tuple<char, int>, Tuple<int, int, char>>(newrule);
                        //filename = openFileDialog1.FileName. ;
                        Init();
                    }
                }
                catch
                {
                    MessageBox.Show("Can't parse file into turmite rule\n Please try another file", "OpenFileError", MessageBoxButtons.OK);
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                map.Save(saveFileDialog1.FileName);
            }
            //map.Save(filename + ".bmp");
        }

        private void Picture_Click(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tickcount = Convert.ToInt32(comboBox2.SelectedItem);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer.Stop();
            step = Convert.ToInt32(comboBox1.SelectedItem);
            Init();
        }
    }
}
