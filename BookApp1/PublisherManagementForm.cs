using System;
using System.Windows.Forms;
using BookApp1.Classes;

namespace BookApp1 {
    public partial class PublisherManagementForm : Form {
        private readonly IPublisherRepository publisherRepository;

        public PublisherManagementForm(IPublisherRepository repository) {
            InitializeComponent();
            publisherRepository = repository;
            LoadPublishers();
            ClearInputs(); 
        }

        private void LoadPublishers() {
            listBoxPublishers.DataSource = null;
            listBoxPublishers.DataSource = publisherRepository.GetPublishers();
            listBoxPublishers.DisplayMember = "Name";
            listBoxPublishers.ValueMember = "Id";
        }

        private void listBoxPublishers_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBoxPublishers.SelectedItem is Publisher selectedPublisher) {
                txtName.Text = selectedPublisher.Name;
                txtHeadquarters.Text = selectedPublisher.Headquarters;
                txtAddress.Text = selectedPublisher.Address;
                dtpFounded.Value = selectedPublisher.Founded ?? DateTime.Today;
                dtpFounded.Checked = selectedPublisher.Founded.HasValue;
                txtCeoFounder.Text = selectedPublisher.CeoFounder;
            }
        }

        private void btnNew_Click(object sender, EventArgs e) {
            ClearInputs();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Publisher publisher = listBoxPublishers.SelectedItem as Publisher ?? new Publisher();

            publisher.Name = txtName.Text;
            publisher.Headquarters = txtHeadquarters.Text;
            publisher.Address = txtAddress.Text;
            publisher.Founded = dtpFounded.Checked ? dtpFounded.Value : null;
            publisher.CeoFounder = txtCeoFounder.Text;

            if (publisher.Id == 0) 
                publisherRepository.CreatePublisher(publisher);
            else 
                publisherRepository.UpdatePublisher(publisher);

            LoadPublishers();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (listBoxPublishers.SelectedItem is Publisher selectedPublisher) {
                if (MessageBox.Show($"Are you sure you want to delete {selectedPublisher.Name}?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    publisherRepository.DeletePublisher(selectedPublisher.Id);
                    LoadPublishers();
                    ClearInputs();
                }
            } else {
                MessageBox.Show("Please select a publisher to delete.");
            }
        }

        private void ClearInputs() {
            txtName.Text = "";
            txtHeadquarters.Text = "";
            txtAddress.Text = "";
            dtpFounded.Value = DateTime.Today;
            dtpFounded.Checked = false;
            txtCeoFounder.Text = "";
            listBoxPublishers.ClearSelected(); 
        }
    }
}