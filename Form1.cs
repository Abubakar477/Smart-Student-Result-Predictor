using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_predication
{
    public partial class Form1 : Form
    {
        private List<Student> students = new List<Student>();
        private MLEngine _mlEngine = new MLEngine();

        // For window dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
            SetupButtonAnimations();
        }

        private void SetupButtonAnimations()
        {
            // Add hover effects for secondary buttons
            btnDisplayResult.MouseEnter += (s, e) => btnDisplayResult.BackColor = Color.FromArgb(45, 45, 48);
            btnDisplayResult.MouseLeave += (s, e) => btnDisplayResult.BackColor = Color.FromArgb(30, 30, 30);

            btnShowAll.MouseEnter += (s, e) => btnShowAll.BackColor = Color.FromArgb(45, 45, 48);
            btnShowAll.MouseLeave += (s, e) => btnShowAll.BackColor = Color.FromArgb(30, 30, 30);

            btnAddStudent.MouseEnter += (s, e) => btnAddStudent.BackColor = Color.FromArgb(120, 50, 255);
            btnAddStudent.MouseLeave += (s, e) => btnAddStudent.BackColor = Color.FromArgb(98, 0, 238);

            btnPredictML.MouseEnter += (s, e) => btnPredictML.BackColor = Color.FromArgb(120, 50, 255);
            btnPredictML.MouseLeave += (s, e) => btnPredictML.BackColor = Color.FromArgb(98, 0, 238);
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                int age = int.Parse(txtAge.Text);
                string studentId = txtId.Text;
                double marks = double.Parse(txtMarks.Text);

                Student newStudent = new Student(name, age, studentId, marks);
                students.Add(newStudent);

                MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid data. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisplayResult_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("No students have been added yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Displaying the result for the last added student for demonstration
            Student lastStudent = students.Last();
            
            // Console-based prototype logic check (writing to trace)
            Console.WriteLine(lastStudent.GetDetails()); 

            string resultMessage = $"Last Added Student:\n\n{lastStudent.GetDetails()}\nResult: {lastStudent.CalculateResult()}";
            MessageBox.Show(resultMessage, "Student Result Prediction", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(students);
            form2.Show();
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtAge.Clear();
            txtId.Clear();
            txtMarks.Clear();
            txtName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            lblMLResult.Text = "Training model...";
            await Task.Run(() => _mlEngine.TrainModel());
            lblMLResult.Text = "Model Ready";
        }

        private void btnPredictML_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMarks.Text))
                {
                    MessageBox.Show("Please enter marks first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float marks = float.Parse(txtMarks.Text);
                var prediction = _mlEngine.Predict(marks);

                string status = prediction.Prediction ? "PASS" : "FAIL";
                Color statusColor = prediction.Prediction ? Color.LimeGreen : Color.Tomato;

                lblMLResult.Text = $"Result: {status} ({prediction.Probability:P1} Confidence)";
                lblMLResult.ForeColor = statusColor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during prediction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
