namespace I_CARE_Phone_Shop_C__Project
{
    partial class Form4
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
            textBox3 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button2 = new Button();
            textBox4 = new TextBox();
            button3 = new Button();
            label5 = new Label();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.Location = new Point(203, 286);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 22;
            // 
            // button1
            // 
            button1.Location = new Point(81, 361);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 21;
            button1.Text = "ADD";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(203, 225);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 20;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(203, 149);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 293);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 18;
            label4.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 232);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 17;
            label3.Text = "Category Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 156);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 16;
            label2.Text = "Category ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(333, 25);
            label1.Name = "label1";
            label1.Size = new Size(167, 32);
            label1.TabIndex = 15;
            label1.Text = "CATEGORIES";
            // 
            // button2
            // 
            button2.Location = new Point(262, 361);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 23;
            button2.Text = "UPDATE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(607, 370);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 26;
            // 
            // button3
            // 
            button3.Location = new Point(430, 442);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 25;
            button3.Text = "DELETE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(430, 377);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 24;
            label5.Text = "Category ID";
            // 
            // button4
            // 
            button4.Location = new Point(618, 442);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 27;
            button4.Text = "SEARCH";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(430, 76);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(397, 265);
            dataGridView1.TabIndex = 28;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(872, 549);
            Controls.Add(dataGridView1);
            Controls.Add(button4);
            Controls.Add(textBox4);
            Controls.Add(button3);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form4";
            Text = "SEARCH";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button2;
        private TextBox textBox4;
        private Button button3;
        private Label label5;
        private Button button4;
        private DataGridView dataGridView1;
    }
}