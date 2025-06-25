using System;
using System.Drawing;
using System.Windows.Forms;

namespace RGR_Graphics
{
    public partial class GrapicsForm : Form
    {

        private Func<double, double> currentFunction; //делегат для отримання поточної функції
        private double shiftX = 0, shiftY = 0; //оголошуємо змінні, які будуть використанні для реалізації переміщення по системі координат
        //конструктор форми
        public GrapicsForm()
        {
            InitializeComponent();
            InitFunctions(); //виклик методу для завантаження списку функцій в випадне меню
            this.KeyPreview = true;
        }
        //метод для завантаження списку функцій в випадне меню
        private void InitFunctions()
        {
            //додаємо всі функції до випадного меню
            comboBoxFunctions.Items.AddRange(new object[]
            {
                 "y = a*x^2 + b*x + c",          //0
                 "y = a*sin(x) + b",             //1
                 "y = a*cos(x) + b",             //2
                 "y = a*tan(x) + b",             //3
                 "y = a*x + b",                  //4
                 "y = a*x^3 + b*x + c",          //5
                 "y = a*exp(b*x)",               //6
                 "y = a*ln(x) + b",              //7
                 "y = a*sqrt(x) + b",            //8
                 "y = a/x + b",                  //9
                 "y = a*abs(x) + b",             //10
                 "y = a*log10(x) + b",           //11
                 "y = a*x^4 + b",                //12
                 "y = a*sin(b*x) + c",           //13
                 "y = a*cosh(x) + b",            //14
                 "y = a*sinh(x) + b",            //15
                 "y = a*sign(x) + b",            //16
                 "y = a*floor(x) + b",           //17
                 "y = a*ceil(x) + b",            //18
                 "y = a*pow(x, b) + c",          //19
                 "y = a*x^5 + b*x^2 + c",        //20
                 "y = a*atan(x) + b",            //21
                 "y = a*tanh(x) + b",            //22
                 "y = a*log2(x) + b",            //23
                 "y = a*1/(1+exp(-x)) + b"       //24 
            });
            comboBoxFunctions.SelectedIndex = 0; //вибрана за замовчуванням функція з індексом 0 
        }
        //метод для отримання функції, яка буде використана в побудові графіка
        private Func<double, double> GetFunction(int idx, double a, double b, double c)
        {
            switch (idx)
            {
                case 0:
                    // y = a*x^2 + b*x + c
                    return x => a * x * x + b * x + c;
                case 1:
                    // y = a*sin(x) + b
                    return x => a * Math.Sin(x) + b;
                case 2:
                    // y = a*cos(x) + b
                    return x => a * Math.Cos(x) + b;
                case 3:
                    // y = a*tan(x) + b
                    return x => a * Math.Tan(x) + b;
                case 4:
                    // y = a*x + b
                    return x => a * x + b;
                case 5:
                    // y = a*x^3 + b*x + c
                    return x => a * Math.Pow(x, 3) + b * x + c;
                case 6:
                    // y = a*exp(b*x)
                    return x => a * Math.Exp(b * x);
                case 7:
                    // y = a*ln(x) + b
                    return x => a * Math.Log(x) + b;
                case 8:
                    // y = a*sqrt(x) + b
                    return x => a * Math.Sqrt(x) + b;
                case 9:
                    // y = a/x + b
                    return x => a / x + b;
                case 10:
                    // y = a*abs(x) + b
                    return x => a * Math.Abs(x) + b;
                case 11:
                    // y = a*log10(x) + b
                    return x => a * Math.Log10(x) + b;
                case 12:
                    // y = a*x^4 + b
                    return x => a * Math.Pow(x, 4) + b;
                case 13:
                    // y = a*sin(b*x) + c
                    return x => a * Math.Sin(b * x) + c;
                case 14:
                    // y = a*cosh(x) + b
                    return x => a * Math.Cosh(x) + b;
                case 15:
                    // y = a*sinh(x) + b
                    return x => a * Math.Sinh(x) + b;
                case 16:
                    // y = a*sign(x) + b
                    return x => a * Math.Sign(x) + b;
                case 17:
                    // y = a*floor(x) + b
                    return x => a * Math.Floor(x) + b;
                case 18:
                    // y = a*ceil(x) + b
                    return x => a * Math.Ceiling(x) + b;
                case 19:
                    // y = a*pow(x, b) + c
                    return x => a * Math.Pow(x, b) + c;
                case 20:
                    // y = a*x^5 + b*x^2 + c
                    return x => a * Math.Pow(x, 5) + b * x * x + c;
                case 21:
                    // y = a*atan(x) + b
                    return x => a * Math.Atan(x) + b;
                case 22:
                    // y = a*tanh(x) + b
                    return x => a * Math.Tanh(x) + b;
                case 23:
                    // y = a*log2(x) + b
                    return x => a * (Math.Log(x) / Math.Log(2)) + b;
                case 24:
                    // y = a*(1/(1+exp(-x))) + b  (логістична крива)
                    return x => a * (1.0 / (1.0 + Math.Exp(-x))) + b;
                default:
                    return x => 0;
            }
        }
        //метод для отримання текстового представлення функції для відображення на формі
        private string GetEquation(int idx, double a, double b, double c)
        {
            switch (idx)
            {
                case 0:
                    return $"y = {a}x² + {b}x + {c}";
                case 1:
                    return $"y = {a}·sin(x) + {b}";
                case 2:
                    return $"y = {a}·cos(x) + {b}";
                case 3:
                    return $"y = {a}·tan(x) + {b}";
                case 4:
                    return $"y = {a}x + {b}";
                case 5:
                    return $"y = {a}x³ + {b}x + {c}";
                case 6:
                    return $"y = {a}·exp({b}x)";
                case 7:
                    return $"y = {a}·ln(x) + {b}";
                case 8:
                    return $"y = {a}·√x + {b}";
                case 9:
                    return $"y = {a}/x + {b}";
                case 10:
                    return $"y = {a}·|x| + {b}";
                case 11:
                    return $"y = {a}·log₁₀(x) + {b}";
                case 12:
                    return $"y = {a}x⁴ + {b}";
                case 13:
                    return $"y = {a}·sin({b}x) + {c}";
                case 14:
                    return $"y = {a}·cosh(x) + {b}";
                case 15:
                    return $"y = {a}·sinh(x) + {b}";
                case 16:
                    return $"y = {a}·sign(x) + {b}";
                case 17:
                    return $"y = {a}·floor(x) + {b}";
                case 18:
                    return $"y = {a}·ceiling(x) + {b}";
                case 19:
                    return $"y = {a}·x^{b} + {c}";
                case 20:
                    return $"y = {a}x⁵ + {b}x² + {c}";
                case 21:
                    return $"y = {a}·atan(x) + {b}";
                case 22:
                    return $"y = {a}·tanh(x) + {b}";
                case 23:
                    return $"y = {a}·log₂(x) + {b}";
                case 24:
                    return $"y = {a}/(1+exp(-x)) + {b}";
                default:
                    return "y = 0";
            }
        }
        //метод для побудови графіка обраної функції
        private void DrawGraph(double from, double to)
        {
            using (Graphics g = Graphics.FromImage(picBoxOutput.Image))
            {
                Pen curvePen = new Pen(Color.Red, 2); //колір та товщина ліній графіка
                //отримуємо ширину та висоту полотна, на яке буде виводитись графік
                int w = picBoxOutput.Width, h = picBoxOutput.Height; 
                int cx = w / 2, cy = h / 2; //знаходимо центр полотна
                double scale = 20; //масштаб (1 одиниця дорінює 20 пікселів)
                double step = (to - from) / w; //крок обчислень

                PointF? prev = null;
                for (double x = from; x <= to; x += step)
                {
                    double y = currentFunction(x);
                    //обчислення координат помножених на масштаб з урахуванням зсуву для правильного відображення на екрані
                    float sx = cx + (float)((x + shiftX) * scale);
                    float sy = cy - (float)((y + shiftY) * scale);

                    if (sx >= 0 && sx <= w && sy >= 0 && sy <= h)
                    {
                        PointF p = new PointF(sx, sy);
                        if (prev.HasValue) g.DrawLine(curvePen, prev.Value, p);
                        prev = p;
                    }
                    else prev = null;
                }
            }
            picBoxOutput.Invalidate(); //оновлення picBoxOutput
        }
        //метод для малювання системи координат та сітки
        private void DrawAxes()
        {
            var bmp = (Bitmap)picBoxOutput.Image;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White); //очищення полотна
                int w = bmp.Width, h = bmp.Height;
                double scale = 20.0;
                //центр полотна з урахуванням зсуву
                int cx = (int)(w / 2 + shiftX * scale);
                int cy = (int)(h / 2 - shiftY * scale);
                var gridPen = new Pen(Color.LightGray, 1);
                var axisPen = new Pen(Color.Black, 2);
                var font = new Font("Arial", 8);
                var brush = Brushes.Black;
                //сітка
                for (int x = cx % (int)scale; x < w; x += (int)scale)
                    g.DrawLine(gridPen, x, 0, x, h);
                for (int y = cy % (int)scale; y < h; y += (int)scale)
                    g.DrawLine(gridPen, 0, y, w, y);
                //осі
                g.DrawLine(axisPen, 0, cy, w, cy); // X
                g.DrawLine(axisPen, cx, 0, cx, h); // Y
                //підписи по осі Х
                double xWorldMin = (0 - cx) / scale;
                double xWorldMax = (w - cx) / scale;
                int xStart = (int)Math.Ceiling(xWorldMin);
                int xEnd = (int)Math.Floor(xWorldMax);
                for (int xi = xStart; xi <= xEnd; xi++)
                {
                    if (xi == 0) continue;
                    int px = (int)(cx + xi * scale);
                    g.DrawString(xi.ToString(), font, brush, px - 5, cy + 2);
                }
                //підписи по осі Y
                double yWorldMin = (cy - h) / scale;
                double yWorldMax = (cy - 0) / scale;
                int yStart = (int)Math.Ceiling(yWorldMin);
                int yEnd = (int)Math.Floor(yWorldMax);
                for (int yi = yStart; yi <= yEnd; yi++)
                {
                    if (yi == 0) continue;
                    int py = (int)(cy - yi * scale);
                    g.DrawString(yi.ToString(), font, brush, cx + 2, py - 5);
                }
            }
            picBoxOutput.Invalidate(); //оновлення picBoxOutput
        }
        //клік по кнопці "Побудувати графік"
        private void btnPlot_Click(object sender, EventArgs e)
        {
            try
            {
                DrawAxes();//виклик методу для малювання вісей
                //конвертація, отриманих з полів вводу, значень 
                double a = Convert.ToDouble(txtA.Text);
                double b = Convert.ToDouble(txtB.Text);
                double c = Convert.ToDouble(txtC.Text);
                double from = Convert.ToDouble(txtFrom.Text);
                double to = Convert.ToDouble(txtTo.Text);
                //отримання індексу, обраного у випадному меню, рівняння
                int idx = comboBoxFunctions.SelectedIndex;
                currentFunction = GetFunction(idx, a, b, c);
                labelEquation.Text = GetEquation(idx, a, b, c);

                DrawGraph(from, to);//виклик методу для малювання графіка
            }
            catch
            {
            }
        }
        //обробник для форми, який спрацьовує при завантаженні
        //використовується, щоб намалювати осі при завантаженні
        private void GrapicsForm_Load(object sender, EventArgs e)
        {
            //створюємо полотно для малювання
            picBoxOutput.Image = new Bitmap(picBoxOutput.Width, picBoxOutput.Height);
            DrawAxes();
        }
        //обробник для натискання клавіш керування курсором
        //використовується для реалізації переміщення по системі координат
        //в ньому визначається натиснута клавіша та залежно від цього змінюється значення зсуву
        private void GrapicsForm_KeyDown(object sender, KeyEventArgs e)
        {
            const double delta = 0.5;
            if (e.KeyCode == Keys.Left) shiftX += delta;
            if (e.KeyCode == Keys.Right) shiftX -= delta;
            if (e.KeyCode == Keys.Up) shiftY -= delta;
            if (e.KeyCode == Keys.Down) shiftY += delta;
            // Перемальовуємо осі і графік
            btnPlot.PerformClick();
        }
        //обробник для поля вводу, для забезпечення вводу правильних даних
        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Правильними символами вважаються цифри,
            // Кома, мінус, <Enter> і <Backspace>.
            // Будемо вважати правильним символом
            // також крапку, замінимо її комою.
            // Інші символи заборонені.
            // Щоб заборонений символ не відображався
            // у полі редагування, привласним
            // значення true властивості Handled параметра e
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (txtA.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == '-')
            {
                // дозволяємо введення мінуса
                if (txtA.Text.IndexOf('-') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку "Намалювати графік"
                    btnPlot.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }
        //обробник для поля вводу, для забезпечення вводу правильних даних
        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Правильними символами вважаються цифри,
            // Кома, мінус, <Enter> і <Backspace>.
            // Будемо вважати правильним символом
            // також крапку, замінимо її комою.
            // Інші символи заборонені.
            // Щоб заборонений символ не відображався
            // у полі редагування, привласним
            // значення true властивості Handled параметра e
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (txtA.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == '-')
            {
                // дозволяємо введення мінуса
                if (txtB.Text.IndexOf('-') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку "Намалювати графік"
                    btnPlot.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }
        //обробник для поля вводу, для забезпечення вводу правильних даних
        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Правильними символами вважаються цифри,
            // Кома, мінус, <Enter> і <Backspace>.
            // Будемо вважати правильним символом
            // також крапку, замінимо її комою.
            // Інші символи заборонені.
            // Щоб заборонений символ не відображався
            // у полі редагування, привласним
            // значення true властивості Handled параметра e
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (txtA.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == '-')
            {
                // дозволяємо введення мінуса
                if (txtC.Text.IndexOf('-') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку "Намалювати графік"
                    btnPlot.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }
        //обробник для поля вводу, для забезпечення вводу правильних даних
        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Правильними символами вважаються цифри,
            // Кома, мінус, <Enter> і <Backspace>.
            // Будемо вважати правильним символом
            // також крапку, замінимо її комою.
            // Інші символи заборонені.
            // Щоб заборонений символ не відображався
            // у полі редагування, привласним
            // значення true властивості Handled параметра e
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (txtA.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == '-')
            {
                // дозволяємо введення мінуса
                if (txtFrom.Text.IndexOf('-') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку "Намалювати графік"
                    btnPlot.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }
        //обробник для поля вводу, для забезпечення вводу правильних даних
        private void txtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Правильними символами вважаються цифри,
            // Кома, мінус, <Enter> і <Backspace>.
            // Будемо вважати правильним символом
            // також крапку, замінимо її комою.
            // Інші символи заборонені.
            // Щоб заборонений символ не відображався
            // у полі редагування, привласним
            // значення true властивості Handled параметра e
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // крапку замінемо комою
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (txtA.Text.IndexOf(',') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == '-')
            {
                // дозволяємо введення мінуса
                if (txtTo.Text.IndexOf('-') != -1)
                {
                    // кома вже є в полі редагування
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // натиснута клавіша <Enter>
                    // встановити курсор на кнопку "Намалювати графік"
                    btnPlot.Focus();
                return;
            }
            // інші символи заборонені
            e.Handled = true;
        }
        //обробник для поля вводу, який перемальовує графік при зміні тексту 
        private void txtA_TextChanged(object sender, EventArgs e)
        {
            btnPlot.PerformClick();
        }
        //обробник для поля вводу, який перемальовує графік при зміні тексту
        private void txtB_TextChanged(object sender, EventArgs e)
        {
            btnPlot.PerformClick();
        }
        //обробник для поля вводу, який перемальовує графік при зміні тексту
        private void txtC_TextChanged(object sender, EventArgs e)
        {
            btnPlot.PerformClick();
        }
        //обробник для поля вводу, який перемальовує графік при зміні тексту
        private void txtFrom_TextChanged(object sender, EventArgs e)
        {
            btnPlot.PerformClick();
        }
        //обробник для поля вводу, який перемальовує графік при зміні тексту
        private void txtTo_TextChanged(object sender, EventArgs e)
        {
            btnPlot.PerformClick();
        }
    }
}
