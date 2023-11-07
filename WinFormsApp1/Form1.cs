using Newtonsoft.Json;
using System.IO;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public List<Person> persons;

        private void button1_Click(object sender, EventArgs e)
        {
            var text = File.ReadAllText(@".\Persons.json");
            persons = JsonConvert.DeserializeObject<List<Person>>(text);
            dataGridView1.DataSource = persons;
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            var person = e.Row.DataBoundItem as Person;
            if (person == null)
                return;
            var image = Image.FromFile(@$".\Images\{person.Id}.jpg");

            pictureBox1.Image = image;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var modal = new NewModal();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
            {
                var person = modal.NewPerson;
                person.Id = persons.Max(x => x.Id) + 1;
                var image = modal.Image;
                persons.Add(person);
                File.WriteAllText(@".\Persons.json", JsonConvert.SerializeObject(persons));
                image.Save(@$".\Images\{person.Id}.jpg");

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = persons;
            }
        }
    }
}