using System.Text.RegularExpressions;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        private string pointPath = "C:\\Users\\sukhy\\source\\repos\\WinFormsApp6\\WinFormsApp6\\Points.txt";
        private string pathToWrite = "C:\\Users\\sukhy\\source\\repos\\WinFormsApp6\\WinFormsApp6\\result.txt";
        private List<Point> points;
        public Form1()
        {
            InitializeComponent();
        }
        private List<Point> FileRead(string filepath)
        {
            var result = new List<Point>();
            try
            {
                string content = File.ReadAllText(filepath);
                string pattern = @"\d+ \d+";
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(content);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        var res = match.Value.Split(" ");
                        result.Add(
                            new Point(int.Parse(res[0]), int.Parse(res[1])));
                    }
                }
            }
            catch
            {
                throw new Exception("Error to read file");
            }
            return result;
        }
        private void WriteToFile(List<Point> pnt, string filepath)
        {
            var text = "";
            for(int i = 0;i<pnt.Count;i++)
            {
                text += $"Point{i}: {pnt[i].X} {pnt[i].Y}\n";
            }
           
            try
            {
                File.WriteAllText(filepath, text);
            }
            catch
            {
                throw new Exception("Error write to file");
            }
        }
        private void Form1_Load(object sender, EventArgs e){}
        private void InitButton_Click(object sender, EventArgs e)
        {
            points = FileRead(pointPath);
            mainPanel.Controls.Clear();
            mainPanel.Paint += new PaintEventHandler(
                   (object sender, PaintEventArgs e) =>
                   {
                       DrawingPoints(points, e.Graphics, Color.Black);
                   });
            mainPanel.Refresh();
        }
        private void DrawingPoints(List<Point> points, Graphics g, Color color)
        {
            foreach (var i in points)
            {
                SolidBrush brush = new SolidBrush(color);
                g.FillEllipse(brush,i.X - 10 / 2,i.Y - 10 / 2, 10, 10);
            }
        }
        private void RunButtom_Click(object sender, EventArgs e)
        {
            double Distance(Point p1, Point p2) => Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            var center = new Point(mainPanel.Width/2, mainPanel.Height/2);
            List<Point> resultpoints = points.OrderBy(p => Distance(p, center)).ToList();
            resultpoints = resultpoints[..10];
            List<Point> pointLine = resultpoints.OrderBy(p=>center.X-p.X).ToList();
            mainPanel.Paint += new PaintEventHandler(
                  (object sender, PaintEventArgs e) =>
                  {
                      DrawingPoints(resultpoints, e.Graphics, Color.Red);
                      for(int i=0;i<pointLine.Count-1;i++)
                      {
                          e.Graphics.DrawLine(new Pen(Color.Blue,2), pointLine[i], pointLine[i + 1]);
                      }
                  });
            mainPanel.Refresh();
            WriteToFile(pointLine, pathToWrite);
        }
    }
}
