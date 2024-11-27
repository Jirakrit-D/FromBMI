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

            // ��Ǩ�ͺ����ŧ��Ҩҡ textBox1 (���˹ѡ)
            if (!double.TryParse(textBox1.Text, out weight))
            {
                textBox1.Text = "0";
                MessageBox.Show("��س�����ҹ��˹ѡ���١��ͧ");
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }

            // ��Ǩ�ͺ����ŧ��Ҩҡ textBox2 (��ǹ�٧)
            if (!double.TryParse(textBox2.Text, out height))
            {
                textBox2.Text = "0";
                MessageBox.Show("��س��������ǹ�٧���١��ͧ");
                textBox2.Focus();
                textBox2.SelectAll();
                return;
            }

            // ��Ǩ�ͺ��Ҥ�� height ������ٹ�����ͤ�ҷ��������˵�����
            if (height <= 0)
            {
                MessageBox.Show("��ǹ�٧��ͧ�դ���ҡ���� 0");
                textBox2.Focus();
                textBox2.SelectAll();
                return;
            }

            // �ӹǳ BMI
            double bmi = weight / Math.Pow(height / 100, 2);

            // ��˹����Ѿ��
            string result = "";
            if (bmi < 18.5)
            {
                result = "Underweight (���)";
            }
            else if (bmi < 25.0)
            {
                result = "Normal weight (����)";
            }
            else if (bmi < 30)
            {
                result = "Overweight (��ǹ)";
            }
            else
            {
                result = "Obesity (�ä��ǹ)";
            }

            // �ʴ����Ѿ��
            label3.Text = "Your Body Mass Index (BMI) is " + bmi.ToString("0.0");
            label4.Text = "From your BMI, you are " + result;

            // ��駤�� focus ��� select ��ͤ���� textBox1
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("��ͧ��ûԴ�������ԧ�������", "�׹�ѹ��ûԴ",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
