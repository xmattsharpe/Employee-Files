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


namespace FileHomework
{
    public partial class Form1 : Form
    {
        // My file that holds all data is called Employee.txt, it should be with my form1 and form1.designer.
        // try out my listbox after you add a employee, click on there information in the listbox and delete them.
        // just dont delete "Anna", shes the default employee in my file for the purpose of reading from the file of the assignment.


        string filePath = @"C:\Users\matth\source\repos\FileHomework\FileHomework\Employee.txt";

        public Form1()
        {
            InitializeComponent();
            DisplayFileData();
            // Read from file and call my display function to display any pre exisiting data when the form opens.



            List<string> data = new List<string>();
            List<EmployeeInfo> info = new List<EmployeeInfo>();

            data = File.ReadAllLines(filePath).ToList();
            foreach (var i in data)
            {
                string[] items = i.Split(',');
                // The way I have formatted my file, a comma will appear after each piece of data, this is how I will determine the next item of data

                EmployeeInfo newEmp = new EmployeeInfo(items[0], Double.Parse(items[1]), Double.Parse(items[2]), items[3]);
                info.Add(newEmp);
                

                //populate the original employee class with the default employee in the file

                textBox1.Text = newEmp.Name;
                textBox2.Text = newEmp.Salary.ToString();
                textBox3.Text = newEmp.Bonus.ToString();
                textBox7.Text = newEmp.Bank;
            }

        }

        public void DisplayFileData()
        {
            // This is for mylist to append the pre written data that I am reading from my file to display in them listbox
            //  or whatever the employer has added from previous runs.
            // This is code that ive just pasted from above, again the purpose is so that I am also able to append pre written data to my listbox to call a function.

            List<string> data = new List<string>();
            data = File.ReadAllLines(filePath).ToList();
            foreach (var i in data)
            {
                string[] items = i.Split(',');
                // same as above

                try
                {
                    EmployeeInfo newEmp = new EmployeeInfo(items[0], Double.Parse(items[1]), Double.Parse(items[2]), items[3]);
                    listBox1.Items.Add($"{newEmp.Name}, {newEmp.Salary}, {newEmp.Bonus}, {newEmp.Bank}");

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Write to file

            List<string> data1 = new List<string>();
            List<NewEmployee> data2 = new List<NewEmployee>();

            try
            {

                // populating my fields from the newEmployee class
                NewEmployee inst = new NewEmployee(textBox4.Text, Double.Parse(textBox5.Text), Double.Parse(textBox6.Text), textBox8.Text);

                // adding the new employee to the list
                data2.Add(inst);

                // this formats the info to my file a better better since they all go on the same line, rather than appending them one at a time
                string Information = $" {inst.NewName}, {inst.NewSalary}, {inst.NewBonus}, {inst.NewBank} ";

                data1.Add(Information);

                File.AppendAllText(filePath, Information + Environment.NewLine);

                listBox1.Items.Add(Information);
            }
            catch (Exception ex)
            { // I am catching any blank data here.

                MessageBox.Show(ex.Message);
            }

            // This clears the new entries upon saving
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();



            MessageBox.Show("Entry Successful! Thank you for your service.", "Confirmed", MessageBoxButtons.OK);
            // confirmation
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void listBox1_Click(object sender, EventArgs e)
        {

           DialogResult res= MessageBox.Show("Are you sure you'd like to delete this employee?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                int index = listBox1.SelectedIndex;
                // store the current index the employer clicks on
                List<string> allCon = File.ReadAllLines(filePath).ToList();
                // list to hold the entire file as it stands that I will mremove from below
                allCon.RemoveAt(index);

                File.WriteAllLines(filePath, allCon); 
                // updating my file WITHOUT the erased individual
                listBox1.Items.RemoveAt(index);
                // removing the individual employee from my listbox

                MessageBox.Show("Employee deleted successfully");
                // end confirmation
            }
        }
    }
}
