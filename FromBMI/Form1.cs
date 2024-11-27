namespace FromBMI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double weight = 0;
            double height = 0;

            // ตรวจสอบและแปลงค่าจาก textBox1 (น้ำหนัก)
            if (!double.TryParse(textBox1.Text, out weight))
            {
                textBox1.Text = "0";
                MessageBox.Show("กรุณาใส่ค่าน้ำหนักที่ถูกต้อง");
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }

            // ตรวจสอบและแปลงค่าจาก textBox2 (ส่วนสูง)
            if (!double.TryParse(textBox2.Text, out height))
            {
                textBox2.Text = "0";
                MessageBox.Show("กรุณาใส่ค่าส่วนสูงที่ถูกต้อง");
                textBox2.Focus();
                textBox2.SelectAll();
                return;
            }

            // ตรวจสอบว่าค่า height ไม่เป็นศูนย์หรือค่าที่ไม่สมเหตุสมผล
            if (height <= 0)
            {
                MessageBox.Show("ส่วนสูงต้องมีค่ามากกว่า 0");
                textBox2.Focus();
                textBox2.SelectAll();
                return;
            }

            // คำนวณ BMI
            double bmi = weight / Math.Pow(height / 100, 2);

            // กำหนดผลลัพธ์
            string result = "";
            if (bmi < 18.5)
            {
                result = "Underweight (ผอม)";
            }
            else if (bmi < 25.0)
            {
                result = "Normal weight (ปกติ)";
            }
            else if (bmi < 30)
            {
                result = "Overweight (อ้วน)";
            }
            else
            {
                result = "Obesity (โรคอ้วน)";
            }

            // แสดงผลลัพธ์
            label3.Text = "Your Body Mass Index (BMI) is " + bmi.ToString("0.0");
            label4.Text = "From your BMI, you are " + result;

            // ตั้งค่า focus และ select ข้อความใน textBox1
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("ต้องการปิดโปรแกรมจริงหรือไม่", "ยืนยันการปิด",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
