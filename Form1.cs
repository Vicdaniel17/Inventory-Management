using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventryManager
{
    public partial class InventoryManagementStudio : Form
    {
        DataTable inventory = new DataTable();
        public InventoryManagementStudio()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            skuTextBox.Text = "";
            nameTextBox.Text = "";
            priceTextBox.Text="";
            descriptionTextBox.Text = "";
            quantityTextBox.Text = "";
            categoryComboBox.SelectedIndex = -1;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Save all the values from the fields into variables
            string sku = skuTextBox.Text;
            string name = nameTextBox.Text;
            string price = priceTextBox.Text;
            string description = descriptionTextBox.Text;
            string quantity = quantityTextBox.Text;
            string category = (string)categoryComboBox.SelectedItem;

            //Add values to the datatable
            inventory.Rows.Add(sku, name, category, price, description, quantity);

            //clear fields after saved
            NewButton_Click(sender, e);

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Exception handleling 
            try
            {
                inventory.Rows[inventoryGridView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception err)
            {
                Console.WriteLine("Error: " + err);
            }
        }

        private void InventoryGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                skuTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
                nameTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
                priceTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
                descriptionTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[4].ToString();
                quantityTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[5].ToString();

                string itemToLookFor = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[2].ToString();
                categoryComboBox.SelectedIndex = categoryComboBox.Items.IndexOf(itemToLookFor);

            }
            catch(Exception err)
            {
                Console.WriteLine("There has been an error: " + err);
            }
        }

        private void InventoryManagementStudio_Load(object sender, EventArgs e)
        {
            inventory.Columns.Add("SKU");
            inventory.Columns.Add("Name");
            inventory.Columns.Add("Category");
            inventory.Columns.Add("Price");
            inventory.Columns.Add("Description");
            inventory.Columns.Add("Quantity");

            inventoryGridView.DataSource = inventory;
        }
    }
}
