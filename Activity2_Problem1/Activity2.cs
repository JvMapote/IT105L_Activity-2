using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity2_Problem1
{
    /* 
    * FullName: Jayvee N. Mapote
    * Section: C11
    * Course: IT105L
    * Laboratory: Activity 2
    */

    public partial class Activity2 : Form
    {
        //Initialized Variables for Problem 1
        const int Weightedgrades = 5;
        const int Totalgrades = 2;
        double[] WeightedGrades = new double[Weightedgrades]; 
        double[] TotalGrades = new double[Totalgrades];

        //Initialized Variables for Problem 2
        string[] name = new string[3]; 
        string[] date = new string[3]; 
        int[]Units = new int[2];
        
        

        //Calculating Final Grades
        public double FinalGrade(double[] InputWeightedGrades) 
        {
            double total = InputWeightedGrades[0] + InputWeightedGrades[1] + InputWeightedGrades[2] + InputWeightedGrades[3] + InputWeightedGrades[4];
            double totalGrade = total;

            return totalGrade;
        }

        private double EquivalentGrade(double finalGrade)
        {
            
            double equivalentGrade;

            //Determining the Equivalent grade
            if (finalGrade > 96 && finalGrade <= 100)
            {
                equivalentGrade = 1.00;
            }
            else if (finalGrade >= 91.51 && finalGrade <= 96)
            {
                equivalentGrade = 1.25;
            }
            else if (finalGrade >= 87.01 && finalGrade <= 91.50)
            {
                equivalentGrade = 1.50;
            }
            else if (finalGrade >= 82.51 && finalGrade <= 87)
            {
                equivalentGrade = 1.75;
            }
            else if (finalGrade >= 78.01 && finalGrade <= 82.50)
            {
                equivalentGrade = 2.00;
            }
            else if (finalGrade >= 73.51 && finalGrade <= 78)
            {
                equivalentGrade = 2.25;
            }
            else if (finalGrade >= 69.01 && finalGrade <= 73.50)
            {
                equivalentGrade = 2.50;
            }
            else if (finalGrade >= 64.51 && finalGrade <= 69)
            {
                equivalentGrade = 2.75;
            }
            else if (finalGrade >= 60 && finalGrade <= 64.50)
            {
                equivalentGrade = 3.00;
            }
            else if (finalGrade < 60)
            {
                equivalentGrade = 5.00;
            }
            else
            {
                MessageBox.Show("Invalid Input:", "Error");
                equivalentGrade = 5.00;
            }

            return equivalentGrade;
        }
        //Student Passed&Failed Result and Tab selection
        private void StudentOutcome(double equivalentGrade)
        {
            if (equivalentGrade <= 3.00)
            {
                if (MessageBox.Show("Status: Student Passed", "Results", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK) 
                {
                    tabControl2.SelectedIndex = 1;
                }
                else 
                {
                    tabControl2.SelectedIndex = 0;
                }
            }
            else if (equivalentGrade >= 3.00) 
            {
                if (MessageBox.Show("Status: Student Failed", "Results", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    tabControl2.SelectedIndex = 1;
                }
                else 
                {
                    tabControl2.SelectedIndex = 0;
                }    
            }
            else
            {
                MessageBox.Show("Wrong input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl2.SelectedIndex = 0;
            }
        }
        //Aplication Exit
        private void NameBox1_TextChanged(object sender, EventArgs e)
        {
            string name = (String)NameBox1.Text;
            if (name == "exit" || name == "Exit" || name == "EXIT")
            {
                Application.Exit();
            }
        }
        //Clearing Button for Numerical inputs and string input
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            NameBox1.Clear();
            NameBox1.Focus();
            AssignmentBox.ResetText();
            QuizBox.ResetText();
            PrelimBox.ResetText();
            MidtermBox.ResetText();
            FinalExamBox.ResetText();
        }
        private void ClearBtn2_Click(object sender, EventArgs e)
        {
            FirstNameBox.Clear();
            MiddleNameBox.Clear();
            LastNameBox.Clear();
            CourseProgramBox.Clear();
            FirstNameBox.Focus();
            BirthmonthBox.ResetText();
            BirthdayBox.ResetText();
            BirthyearBox.ResetText();
            UnitTakenBox.ResetText();
        }
        //WeightedGrades Convertions
        private void AssignmentBox_ValueChanged(object sender, EventArgs e)
        {
            WeightedGrades[1] = Convert.ToDouble(AssignmentBox.Value) * 0.1;
        }
        private void QuizBox_ValueChanged(object sender, EventArgs e)
        {
            WeightedGrades[0] = Convert.ToDouble(QuizBox.Value) * 0.3;
        }
        private void PrelimBox_ValueChanged(object sender, EventArgs e)
        {
            WeightedGrades[2] = Convert.ToDouble(PrelimBox.Value) * 0.2;
        }
        private void MidtermBox_ValueChanged(object sender, EventArgs e)
        {
            WeightedGrades[3] = Convert.ToDouble(MidtermBox.Value) * 0.2;
        }
        private void FinalExamBox_ValueChanged(object sender, EventArgs e)
        {
            WeightedGrades[4] = Convert.ToDouble(FinalExamBox.Value) * 0.2;
        }
        //SubmitButton
        private void SumbitBtn_Click(object sender, EventArgs e)
        {
            //Passing values to get the total Grades
            TotalGrades[0] = FinalGrade(WeightedGrades);
            TotalGrades[1] = EquivalentGrade(TotalGrades[0]);

            ResultName.Text = ($"{NameBox1.Text.ToUpper()}");
            ResultQuiz.Text = ($"{WeightedGrades[0]}%");
            ResultAssignmentScore.Text = ($"{WeightedGrades[1]}%");
            PCAresult.Text = ($"{WeightedGrades[2].ToString()}%");
            MCAresult.Text = ($"{WeightedGrades[3]}%");
            FCAresult.Text = ($"{WeightedGrades[4].ToString()}%");
            FinalGradeResult.Text = ($"{TotalGrades[0]}%");
            EquivalentGradeResult.Text = ($"{TotalGrades[1]}");

            StudentOutcome(TotalGrades[1]);
        }
        //Getting the birthmonth in strings
        public string Birthdate(int mon) 
        {
            String birthmonth = CultureInfo.CurrentCulture.
                DateTimeFormat.GetMonthName
                (mon);
            return birthmonth;
        }
        //Getting the Yearlevel
        public string YearLevel(int unit) 
        {
            string yearLevel = string.Empty;

            if (unit > 200 && unit <= 250)
            {
                yearLevel = "First Year";
            }
            else if (unit > 150 && unit <= 200)
            {
                yearLevel = "Second Year";
            }
            else if (unit > 100 && unit <= 150)
            {
                yearLevel = "Third Year";
            }
            else if (unit > 50 && unit <= 100)
            {
                yearLevel = "Fourth Year";
            }
            else if (unit <= 50)
            {
                yearLevel = "Fifth Year";
            }
            return yearLevel;
        }
        //Displaying Name Results
        public void NameResults(string[] name) 
        {
            FullnameResult1.Text = ($"{name[0]} {name[1]} {name[2]}");
            FullnameResult2.Text = ($"{name[0]} {name[2]}");
        }
        //Button for Problem 2
        private void SubmitBtn2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Results: Do you want to see the result?", "Submitted", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                tabControl3.SelectedIndex = 1;
            }
            else
            {
                tabControl3.SelectedIndex = 0;
            }
            //Displaying Birthdate
            date[0] = Birthdate(Convert.ToInt32(BirthmonthBox.Value));
            date[1] = Convert.ToString(BirthdayBox.Value);
            date[2] = Convert.ToString(BirthyearBox.Value);
            BirthdateResult.Text = ($"{date[0]} {date[1]} {date[2]}");
            DateTime bday = Convert.ToDateTime(BirthdateResult.Text);
            DateTime today = DateTime.Today;
            int age = today.Year - Convert.ToInt32(BirthyearBox.Value);
            if (bday > today.AddYears(-age)) age--;
            AgeResult.Text = ($"{age}");
            //Displaying Name
            name[0] = FirstNameBox.Text;
            name[1] = MiddleNameBox.Text;
            name[2] = LastNameBox.Text;
            NameResults(name);
            //Displaying YearLevel
            Units[0] = Convert.ToInt32(UnitTakenBox.Text);
            Units[1] = 250 - Units[0];
            CurrentyearLevelResult.Text = ($"{YearLevel(Units[1])}");
        }
        public Activity2()
        {
            InitializeComponent();
        }

        
    }
}
