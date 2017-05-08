namespace Consignment_Shop_UI
{
    partial class Consignment_Shop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HeaderText = new System.Windows.Forms.Label();
            this.ItemListBox = new System.Windows.Forms.ListBox();
            this.ItemListBox_Label = new System.Windows.Forms.Label();
            this.AddToCart = new System.Windows.Forms.Button();
            this.ShoppingCartListBox_Label = new System.Windows.Forms.Label();
            this.ShoppingCartListBox = new System.Windows.Forms.ListBox();
            this.PurchaseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeaderText
            // 
            this.HeaderText.AutoSize = true;
            this.HeaderText.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderText.Location = new System.Drawing.Point(13, 13);
            this.HeaderText.Name = "HeaderText";
            this.HeaderText.Size = new System.Drawing.Size(345, 32);
            this.HeaderText.TabIndex = 0;
            this.HeaderText.Text = "Consignment Shop Demo";
            // 
            // ItemListBox
            // 
            this.ItemListBox.FormattingEnabled = true;
            this.ItemListBox.ItemHeight = 16;
            this.ItemListBox.Location = new System.Drawing.Point(19, 81);
            this.ItemListBox.Name = "ItemListBox";
            this.ItemListBox.Size = new System.Drawing.Size(258, 100);
            this.ItemListBox.TabIndex = 1;
            // 
            // ItemListBox_Label
            // 
            this.ItemListBox_Label.AutoSize = true;
            this.ItemListBox_Label.Location = new System.Drawing.Point(19, 63);
            this.ItemListBox_Label.Name = "ItemListBox_Label";
            this.ItemListBox_Label.Size = new System.Drawing.Size(96, 16);
            this.ItemListBox_Label.TabIndex = 2;
            this.ItemListBox_Label.Text = "Store Items";
            this.ItemListBox_Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // AddToCart
            // 
            this.AddToCart.Location = new System.Drawing.Point(283, 118);
            this.AddToCart.Name = "AddToCart";
            this.AddToCart.Size = new System.Drawing.Size(159, 23);
            this.AddToCart.TabIndex = 3;
            this.AddToCart.Text = "Add to Cart ->";
            this.AddToCart.UseVisualStyleBackColor = true;
            // 
            // ShoppingCartListBox_Label
            // 
            this.ShoppingCartListBox_Label.AutoSize = true;
            this.ShoppingCartListBox_Label.Location = new System.Drawing.Point(445, 63);
            this.ShoppingCartListBox_Label.Name = "ShoppingCartListBox_Label";
            this.ShoppingCartListBox_Label.Size = new System.Drawing.Size(112, 16);
            this.ShoppingCartListBox_Label.TabIndex = 5;
            this.ShoppingCartListBox_Label.Text = "Shopping Cart";
            this.ShoppingCartListBox_Label.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // ShoppingCartListBox
            // 
            this.ShoppingCartListBox.FormattingEnabled = true;
            this.ShoppingCartListBox.ItemHeight = 16;
            this.ShoppingCartListBox.Location = new System.Drawing.Point(448, 81);
            this.ShoppingCartListBox.Name = "ShoppingCartListBox";
            this.ShoppingCartListBox.Size = new System.Drawing.Size(258, 100);
            this.ShoppingCartListBox.TabIndex = 4;
            this.ShoppingCartListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // PurchaseButton
            // 
            this.PurchaseButton.Location = new System.Drawing.Point(547, 211);
            this.PurchaseButton.Name = "PurchaseButton";
            this.PurchaseButton.Size = new System.Drawing.Size(159, 23);
            this.PurchaseButton.TabIndex = 6;
            this.PurchaseButton.Text = "Purchase";
            this.PurchaseButton.UseVisualStyleBackColor = true;
            // 
            // Consignment_Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 311);
            this.Controls.Add(this.PurchaseButton);
            this.Controls.Add(this.ShoppingCartListBox_Label);
            this.Controls.Add(this.ShoppingCartListBox);
            this.Controls.Add(this.AddToCart);
            this.Controls.Add(this.ItemListBox_Label);
            this.Controls.Add(this.ItemListBox);
            this.Controls.Add(this.HeaderText);
            this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Consignment_Shop";
            this.Text = "Consignment Shop Form";
            this.Load += new System.EventHandler(this.Consignment_Shop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderText;
        private System.Windows.Forms.ListBox ItemListBox;
        private System.Windows.Forms.Label ItemListBox_Label;
        private System.Windows.Forms.Button AddToCart;
        private System.Windows.Forms.Label ShoppingCartListBox_Label;
        private System.Windows.Forms.ListBox ShoppingCartListBox;
        private System.Windows.Forms.Button PurchaseButton;
    }
}

