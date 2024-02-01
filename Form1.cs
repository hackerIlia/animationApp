namespace Lab_6_animation
{
    public partial class Form1 : Form
    {
        private Snowflake[] snowflakes;
        private Ball ball;
        private Graphics g,b,c;
        List<Point> points=new List<Point>();
        public Form1()
        {
            points.Clear();
            InitializeComponent();
             this.g = pictureBox1.CreateGraphics();
            this.b = pictureBox2.CreateGraphics();
            this.c=pictureBox3.CreateGraphics();

            ball = new Ball();

            snowflakes = new Snowflake[30];
            for (int i = 0;i<snowflakes.Length;i++)
            {
                snowflakes[i] = new Snowflake();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Snowflake snowflake in snowflakes)
                snowflake.Update();

            Invalidate();//перерисовка окна
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            g.Clear(Color.White);

            //body
            Pen bluePen = new Pen(Color.FromArgb(128, 229, 255), 3);
            g.DrawEllipse(bluePen, 221, 54, 60, 60);
            Brush brush1 = new SolidBrush(Color.FromArgb(128, 229, 255));
            g.FillEllipse(brush1, 221, 54, 60, 60);
            g.DrawEllipse(bluePen, 211, 114, 80, 80);
            g.FillEllipse(brush1, 211, 114, 80, 80);
            g.DrawEllipse(bluePen, 201, 194, 100, 100);
            g.FillEllipse(brush1, 201, 194, 100, 100);
            Pen blackPen = new Pen(Color.Black, 3);
            Brush brushBlack = new SolidBrush(Color.Black);
            g.DrawEllipse(blackPen, 235, 69, 10, 10);
            g.FillEllipse(brushBlack, 235, 69, 10, 10);
            g.DrawEllipse(blackPen, 257, 69, 10, 10);
            g.FillEllipse(brushBlack, 257, 69, 10, 10);

            //nose
            Point[] trianlgle =
            {
                new Point(240,98),
                new Point(252,86),
                new Point(263,98)
            };
            g.DrawPolygon(new Pen(Color.FromArgb(255, 140, 26), 2), trianlgle);
            g.FillPolygon(new SolidBrush(Color.FromArgb(255, 140, 26)), trianlgle);

            //mouth
            g.DrawEllipse(blackPen, 229, 100, 4, 4);
            g.FillEllipse(brushBlack, 229, 100, 4, 4);
            g.DrawEllipse(blackPen, 239, 104, 4, 4);
            g.FillEllipse(brushBlack, 239, 104, 4, 4);
            g.DrawEllipse(blackPen, 248, 105, 4, 4);
            g.FillEllipse(brushBlack, 248, 105, 4, 4);
            g.DrawEllipse(blackPen, 257, 105, 4, 4);
            g.FillEllipse(brushBlack, 257, 105, 4, 4);
            g.DrawEllipse(blackPen, 268, 102, 4, 4);
            g.FillEllipse(brushBlack, 268, 102, 4, 4);


            //left hand
            g.DrawLine(blackPen, new Point(234, 164), new Point(174, 223));
            g.DrawLine(blackPen, new Point(195, 201), new Point(163, 204));
            g.DrawLine(blackPen, new Point(195, 201), new Point(192, 233));

            //right hand
            g.DrawLine(blackPen, new Point(271, 164), new Point(331, 223));
            g.DrawLine(blackPen, new Point(307, 201), new Point(311, 226));
            g.DrawLine(blackPen, new Point(307, 201), new Point(345, 209));

            //legs
            g.DrawEllipse(new Pen(Color.FromArgb(102, 163, 255)), 206, 278, 40, 40);
            g.FillEllipse(new SolidBrush(Color.FromArgb(102, 163, 255)), 206, 278, 40, 40);
            g.DrawEllipse(new Pen(Color.FromArgb(102, 163, 255)), 258, 278, 40, 40);
            g.FillEllipse(new SolidBrush(Color.FromArgb(102, 163, 255)), 258, 278, 40, 40);

            //cap
            Point[] cap =
            {
                new Point(227,22),
                new Point(272,22),
                new Point(272,65),
                new Point(254,58),
                new Point(227,65)
            };
            g.DrawPolygon(new Pen(Color.FromArgb(204, 102, 0)), cap);
            g.FillPolygon(new SolidBrush(Color.FromArgb(204, 102, 0)), cap);


            foreach (Snowflake snowflake in snowflakes)
            {
                g.FillEllipse(Brushes.LightBlue, snowflake.X, snowflake.Y, 10, 10);
            }

            b.Clear(Color.White);
            b.FillEllipse(Brushes.LightBlue, ball.X, ball.Y, 30, 30);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button2_Start_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button2_Stop_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int x = pictureBox3.PointToClient(Cursor.Position).X;
            int y = pictureBox3.PointToClient(Cursor.Position).Y;

            Point p= new Point(x, y);
            points.Add(p);

            textBox1.Text += x + ";" + y + Environment.NewLine;
        }

        private void buttonCoordPlane_Click(object sender, EventArgs e)
        {
            
            c.DrawLine(new Pen(Color.Black), pictureBox3.Width / 2, 0, pictureBox3.Width / 2, pictureBox3.Height);
            c.DrawLine(new Pen(Color.Black), 0, pictureBox3.Height / 2, pictureBox3.Width, pictureBox3.Height / 2);

            foreach (Point p in points)
            {
                c.DrawEllipse(new Pen(Color.Red), p.X, p.Y, 2, 2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c.Clear(Color.White);
            buttonCoordPlane_Click(sender, e);
            if(points.Count==0) { MessageBox.Show("Нет точек!");return;}
            int xmax = points[0].X, xmin = points[0].X, ymax = points[0].Y, ymin = points[0].Y;
            foreach(Point p in points)
            {
                if(p.X > xmax) xmax = p.X;
                if(p.X < xmin) xmin = p.X;
                if (p.Y > ymax) ymax = p.Y;
                if (p.Y < ymin) ymin = p.Y;
            }

            Rectangle rect = new Rectangle(xmin,ymin,xmax-xmin,ymax-ymin);
            c.DrawRectangle(new Pen(Color.Orange,3), rect);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ball.Update();

            Invalidate();
        }
    }

    internal class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Velocity_X { get; set; }
        public int Velocity_Y { get; set; }

        private static Random random = new Random();

        public Ball()
        {
            X = random.Next(0, 520);
            Y = 0;
            Velocity_X = random.Next(1, 10);
            Velocity_Y = random.Next(1, 10);
        }

        public void Update()
        {
            Y += Velocity_Y;
            X += Velocity_X;
            if(X>520-30)
                Velocity_X=random.Next(-10, -1);
            if (X < 0)
                Velocity_X=random.Next(1, 10);
            if(Y>337-30)
                Velocity_Y=random.Next(-10, -1);
            if(Y<0)
                Velocity_Y=random.Next(1, 10);
        }
    }

    internal class Snowflake
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Velocity { get; set; }

        private static Random random = new Random();

        public Snowflake()
        {
            X = random.Next(0,520); 
            Y = 0; 
            Velocity = random.Next(1,10); 
        }

        public void Update()
        {
            Y += Velocity; 
            if (Y > 337) 
            {
                Y = 0;
                Velocity = random.Next(1, 10);
            }
        }
    }
}