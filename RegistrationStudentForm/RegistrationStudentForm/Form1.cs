using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RegistrationStudentForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnSubmit.Click += btnSubmit_Click;
            btnColor.Click += btnColor_Click;
            this.Load += Form1_Load;

            rbMale.Appearance = Appearance.Button;
            rbMale.FlatStyle = FlatStyle.Standard;
            rbMale.BackColor = Color.White;
            rbMale.FlatAppearance.BorderColor = Color.Blue;

            rbFemale.Appearance = Appearance.Button;
            rbFemale.FlatStyle = FlatStyle.Standard;
            rbFemale.BackColor = Color.White;
            rbFemale.FlatAppearance.BorderColor = Color.Blue;

            rbOther.Appearance = Appearance.Button;
            rbOther.FlatStyle = FlatStyle.Standard;
            rbOther.BackColor = Color.White;
            rbOther.FlatAppearance.BorderColor = Color.Blue;
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbCountry.Items.AddRange(new string[] { "Yemen", "Egypt", "Iraq", "Saudi Arabia", "Palestine", "Syria" });

            this.BackColor = Color.FromArgb(240, 250, 255);

            btnSubmit.BackColor = Color.FromArgb(0, 122, 255);
            btnSubmit.ForeColor = Color.White;
            btnColor.BackColor = Color.FromArgb(242, 242, 242);
            lblResult.ForeColor = Color.Black;
            txtName.ForeColor = Color.Black;
            txtEmail.ForeColor = Color.Black;
            txtPassword.ForeColor = Color.Black;
            lblResult.ForeColor = Color.WhiteSmoke;


            lblName.BackColor = Color.FromArgb(80, 200, 240,255);
            lblEmail.BackColor = Color.FromArgb(80, 200, 240,255);
            lblPassword.BackColor = Color.FromArgb(80, 200, 240,255);
            lblBirthdate.BackColor = Color.FromArgb(80, 200, 240,255);
            lblCountry.BackColor = Color.FromArgb(80, 200, 240,255);
            lblGender.BackColor = Color.FromArgb(80, 200, 240,255);


            txtName.BackColor = Color.FromArgb(255, 255, 255);
            txtName.BorderStyle = BorderStyle.Fixed3D;
            txtEmail.BackColor = Color.FromArgb(255, 255, 255);
            txtEmail.BorderStyle = BorderStyle.Fixed3D;
            txtPassword.BackColor = Color.FromArgb(255, 255, 255);
            txtPassword.BorderStyle = BorderStyle.Fixed3D;
            lblResult.BackColor = Color.Green;

        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Check the name field
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please enter your name!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }
                // Check the email field
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Please enter your email!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                // Verify email format
                var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$");
                if (!emailRegex.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("Invalid email!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                // Check the password field
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please enter your password!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                string gender = "";
                if (rbMale.Checked) gender = "Male";
                else if (rbFemale.Checked) gender = "Female";
                else if (rbOther.Checked) gender = "Other";

                lblResult.Text = $"Name: {txtName.Text}, " +
                                 $"Email: {txtEmail.Text}, " +
                                 $"Gender: {gender},\n" +
                                 $"Fivorite Color: {btnColor.BackColor.Name}, " +
                                 $"Birthdate: {dtpBirthdate.Value.ToShortDateString()}, " +
                                 $"Country: {cmbCountry.SelectedItem.ToString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // When you click on the color selection button
        private void btnColor_Click(object sender, EventArgs e)
        {
            // Open the color selsction window
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Set the selscted color in the button
                    btnColor.BackColor = colorDialog.Color;
                }
            }
        }


    }
}
