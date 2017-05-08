using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consignment_Shop_UI
{
    public partial class Consignment_Shop : Form
    {
        private Store store = new Store();
        BindingSource itemsBinding = new BindingSource();

        public Consignment_Shop()
        {
            InitializeComponent();
            SetupData();

            itemsBinding.DataSource = store.Items;
            ItemListBox.DataSource = itemsBinding;

            ItemListBox.DisplayMember = "Display";
            ItemListBox.ValueMember = "Display";
        }

        private void Consignment_Shop_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void SetupData()
        {

            store.Venders.Add(new Vender { FirstName = "Sophie", LastName = "Zhang", Commission = .5 });
            store.Venders.Add(new Vender {FirstName = "Jotaro", LastName = "Kujo", Commission = .5 });
            store.Venders.Add(new Vender { FirstName = "Sashimi", LastName = "Sushi"});

            store.Items.Add(new Item
            {
                Title = "Star Platium",
                Description = "Stand",
                Price = 99.99M,
                Owner = store.Venders[1]
            });

            store.Items.Add(new Item
            {
                Title = "Black Dragon Roll",
                Description = "Food",
                Price = 5.99M,
                Owner = store.Venders[2]
            });

            store.Items.Add(new Item
            {
                Title = "Beauty and Beast",
                Description = "Movie",
                Price = 10.99M,
                Owner = store.Venders[0]
            });

            store.Items.Add(new Item
            {
                Title = "Red Dragon Roll",
                Description = "Food",
                Price = 4.99M,
                Owner = store.Venders[2]
            });

            store.Items.Add(new Item
            {
                Title = "JoJo's Hat",
                Description = "Hat",
                Price = 99.59M,
                Owner = store.Venders[1]
            });

            store.Name = "Seconds are Better";

        }

    }
}
