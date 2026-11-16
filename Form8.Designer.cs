namespace I_CARE_Phone_Shop_C__Project
{
    partial class Form8
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
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(315, 281);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(397, 189);
            dataGridView1.TabIndex = 46;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(168, 72);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 45;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 79);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 44;
            label2.Text = "Bill NO";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(350, 9);
            label1.Name = "label1";
            label1.Size = new Size(195, 32);
            label1.TabIndex = 43;
            label1.Text = "SALE HISTORY";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(391, 75);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 47;
            label3.Text = "Date";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(462, 74);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 48;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(406, 240);
            label4.Name = "label4";
            label4.Size = new Size(172, 20);
            label4.TabIndex = 49;
            label4.Text = "Completed Sales Record";
            // 
            // button1
            // 
            button1.Location = new Point(373, 155);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 52;
            button1.Text = "SEARCH";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(618, 155);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 53;
            button2.Text = "VIEW ALL";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form8
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(1060, 556);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form8";
            Text = "Form8";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private Button button1;
        private Button button2;
    }
}