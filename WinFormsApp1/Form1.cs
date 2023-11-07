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

        public PersonManager personmanager = new PersonManager(new FileStorageRepository());

        // load
        private void button1_Click(object sender, EventArgs e)
        {
            personmanager.Load();
            dataGridView1.DataSource = personmanager.persons;
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
                personmanager.Add(person);

                var image = modal.Image;
                image.Save(@$".\Images\{person.Id}.jpg");

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = personmanager.persons;
            }
        }
    }
}