namespace pAnalizadorDeCodigo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TextBoxEditor = new RichTextBox();
            TextBoxConsola = new RichTextBox();
            buttonAnalizar = new Button();
            pictureBox1 = new PictureBox();
            buttonBorrar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TextBoxEditor
            // 
            TextBoxEditor.BackColor = SystemColors.InactiveCaption;
            TextBoxEditor.ForeColor = SystemColors.InactiveBorder;
            TextBoxEditor.Location = new Point(33, 40);
            TextBoxEditor.Name = "TextBoxEditor";
            TextBoxEditor.Size = new Size(460, 357);
            TextBoxEditor.TabIndex = 0;
            TextBoxEditor.Text = "";
            // 
            // TextBoxConsola
            // 
            TextBoxConsola.BackColor = SystemColors.AppWorkspace;
            TextBoxConsola.BorderStyle = BorderStyle.FixedSingle;
            TextBoxConsola.Location = new Point(519, 235);
            TextBoxConsola.Name = "TextBoxConsola";
            TextBoxConsola.ReadOnly = true;
            TextBoxConsola.Size = new Size(269, 162);
            TextBoxConsola.TabIndex = 1;
            TextBoxConsola.Text = "";
            // 
            // buttonAnalizar
            // 
            buttonAnalizar.BackColor = Color.LightCyan;
            buttonAnalizar.BackgroundImage = Properties.Resources.A_N_A_L_I_Z_A_R__4_;
            buttonAnalizar.FlatStyle = FlatStyle.Flat;
            buttonAnalizar.Location = new Point(519, 135);
            buttonAnalizar.Name = "buttonAnalizar";
            buttonAnalizar.Size = new Size(269, 38);
            buttonAnalizar.TabIndex = 2;
            buttonAnalizar.UseVisualStyleBackColor = false;
            buttonAnalizar.Click += buttonAnalizar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.C___m_p_i_l_e_r__2_;
            pictureBox1.Location = new Point(511, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(305, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // buttonBorrar
            // 
            buttonBorrar.BackgroundImage = Properties.Resources.borrarBoton;
            buttonBorrar.BackgroundImageLayout = ImageLayout.Center;
            buttonBorrar.FlatStyle = FlatStyle.Flat;
            buttonBorrar.Location = new Point(519, 179);
            buttonBorrar.Name = "buttonBorrar";
            buttonBorrar.Size = new Size(269, 38);
            buttonBorrar.TabIndex = 4;
            buttonBorrar.UseVisualStyleBackColor = true;
            buttonBorrar.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonBorrar);
            Controls.Add(pictureBox1);
            Controls.Add(buttonAnalizar);
            Controls.Add(TextBoxConsola);
            Controls.Add(TextBoxEditor);
            Name = "Form1";
            Text = "Analizador de Codigo";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox TextBoxEditor;
        private RichTextBox TextBoxConsola;
        private Button buttonAnalizar;
        private PictureBox pictureBox1;
        private Button buttonBorrar;
    }
}
