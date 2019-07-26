namespace LoginPage
{
    partial class Form3
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
            this.lblSifraTermina = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.btnDodajRecept = new System.Windows.Forms.Button();
            this.btnShraniTermin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSifraTermina
            // 
            this.lblSifraTermina.AutoSize = true;
            this.lblSifraTermina.Location = new System.Drawing.Point(9, 18);
            this.lblSifraTermina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSifraTermina.Name = "lblSifraTermina";
            this.lblSifraTermina.Size = new System.Drawing.Size(96, 17);
            this.lblSifraTermina.TabIndex = 0;
            this.lblSifraTermina.Text = "Šifra termina: ";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(9, 51);
            this.lblDatum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(57, 17);
            this.lblDatum.TabIndex = 1;
            this.lblDatum.Text = "Datum: ";
            // 
            // txtOpis
            // 
            this.txtOpis.Enabled = false;
            this.txtOpis.Location = new System.Drawing.Point(12, 89);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(468, 244);
            this.txtOpis.TabIndex = 2;
            // 
            // btnDodajRecept
            // 
            this.btnDodajRecept.Location = new System.Drawing.Point(381, 11);
            this.btnDodajRecept.Name = "btnDodajRecept";
            this.btnDodajRecept.Size = new System.Drawing.Size(99, 30);
            this.btnDodajRecept.TabIndex = 3;
            this.btnDodajRecept.Text = "Dodaj recept";
            this.btnDodajRecept.UseVisualStyleBackColor = true;
            this.btnDodajRecept.Visible = false;
            this.btnDodajRecept.Click += new System.EventHandler(this.btnDodajRecept_Click);
            // 
            // btnShraniTermin
            // 
            this.btnShraniTermin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnShraniTermin.Location = new System.Drawing.Point(381, 44);
            this.btnShraniTermin.Name = "btnShraniTermin";
            this.btnShraniTermin.Size = new System.Drawing.Size(99, 30);
            this.btnShraniTermin.TabIndex = 4;
            this.btnShraniTermin.Text = "Shrani";
            this.btnShraniTermin.UseVisualStyleBackColor = true;
            this.btnShraniTermin.Visible = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 345);
            this.Controls.Add(this.btnShraniTermin);
            this.Controls.Add(this.btnDodajRecept);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblSifraTermina);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(508, 384);
            this.Name = "Form3";
            this.ShowIcon = false;
            this.Text = "Termin";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSifraTermina;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.Button btnDodajRecept;
        private System.Windows.Forms.Button btnShraniTermin;
    }
}