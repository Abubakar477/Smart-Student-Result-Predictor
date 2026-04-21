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
    public partial class Form2 : Form
    {
        private List<Student> _students;

        // For window dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form2(List<Student> students)
        {
            InitializeComponent();
            _students = students;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Bind the List directly to the DataGridView
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = _students;

            // Format the columns
            if (dgvStudents.Columns["Name"] != null)
            {
                dgvStudents.Columns["Name"].HeaderText = "STUDENT NAME";
                dgvStudents.Columns["Name"].FillWeight = 40;
            }
            if (dgvStudents.Columns["Age"] != null)
            {
                dgvStudents.Columns["Age"].HeaderText = "AGE";
                dgvStudents.Columns["Age"].FillWeight = 20;
            }
            if (dgvStudents.Columns["StudentId"] != null)
            {
                dgvStudents.Columns["StudentId"].HeaderText = "STUDENT ID";
                dgvStudents.Columns["StudentId"].FillWeight = 20;
            }
            if (dgvStudents.Columns["Marks"] != null)
            {
                dgvStudents.Columns["Marks"].HeaderText = "MARKS";
                dgvStudents.Columns["Marks"].FillWeight = 20;
            }
        }
    }
}
