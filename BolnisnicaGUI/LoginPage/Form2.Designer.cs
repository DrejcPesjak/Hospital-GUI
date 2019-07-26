namespace LoginPage
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnOdjava = new System.Windows.Forms.Button();
            this.btnSpremSvojeGeslo = new System.Windows.Forms.Button();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.btnSprUporGeslo = new System.Windows.Forms.Button();
            this.btnPregledUporabnikov = new System.Windows.Forms.Button();
            this.btnDodajUporabnika = new System.Windows.Forms.Button();
            this.panelSestra = new System.Windows.Forms.Panel();
            this.btnPregledPacientov = new System.Windows.Forms.Button();
            this.btnSpremeniPacienta = new System.Windows.Forms.Button();
            this.btnDodajPacienta = new System.Windows.Forms.Button();
            this.panelDoktor = new System.Windows.Forms.Panel();
            this.btnDoktorKartoteka = new System.Windows.Forms.Button();
            this.panelPacient = new System.Windows.Forms.Panel();
            this.btnPacientTermini = new System.Windows.Forms.Button();
            this.btnPacientPodatki = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelAdmin.SuspendLayout();
            this.panelSestra.SuspendLayout();
            this.panelDoktor.SuspendLayout();
            this.panelPacient.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnOdjava);
            this.splitContainer1.Panel1.Controls.Add(this.btnSpremSvojeGeslo);
            this.splitContainer1.Panel1.Controls.Add(this.panelAdmin);
            this.splitContainer1.Panel1.Controls.Add(this.panelSestra);
            this.splitContainer1.Panel1.Controls.Add(this.panelDoktor);
            this.splitContainer1.Panel1.Controls.Add(this.panelPacient);
            this.splitContainer1.Panel1MinSize = 214;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Size = new System.Drawing.Size(941, 587);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnOdjava
            // 
            this.btnOdjava.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOdjava.Location = new System.Drawing.Point(0, 300);
            this.btnOdjava.Name = "btnOdjava";
            this.btnOdjava.Size = new System.Drawing.Size(214, 30);
            this.btnOdjava.TabIndex = 5;
            this.btnOdjava.Text = "Odjava";
            this.btnOdjava.UseVisualStyleBackColor = true;
            this.btnOdjava.Click += new System.EventHandler(this.btnOdjava_Click);
            // 
            // btnSpremSvojeGeslo
            // 
            this.btnSpremSvojeGeslo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSpremSvojeGeslo.Location = new System.Drawing.Point(0, 270);
            this.btnSpremSvojeGeslo.Name = "btnSpremSvojeGeslo";
            this.btnSpremSvojeGeslo.Size = new System.Drawing.Size(214, 30);
            this.btnSpremSvojeGeslo.TabIndex = 4;
            this.btnSpremSvojeGeslo.Text = "Spremeni svoje geslo";
            this.btnSpremSvojeGeslo.UseVisualStyleBackColor = true;
            this.btnSpremSvojeGeslo.Click += new System.EventHandler(this.btnSpremSvojeGeslo_Click);
            // 
            // panelAdmin
            // 
            this.panelAdmin.AutoSize = true;
            this.panelAdmin.Controls.Add(this.btnSprUporGeslo);
            this.panelAdmin.Controls.Add(this.btnPregledUporabnikov);
            this.panelAdmin.Controls.Add(this.btnDodajUporabnika);
            this.panelAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdmin.Location = new System.Drawing.Point(0, 180);
            this.panelAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(214, 90);
            this.panelAdmin.TabIndex = 3;
            // 
            // btnSprUporGeslo
            // 
            this.btnSprUporGeslo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSprUporGeslo.Location = new System.Drawing.Point(0, 60);
            this.btnSprUporGeslo.Name = "btnSprUporGeslo";
            this.btnSprUporGeslo.Size = new System.Drawing.Size(214, 30);
            this.btnSprUporGeslo.TabIndex = 2;
            this.btnSprUporGeslo.Text = "Spremeni uporabnikovo geslo";
            this.btnSprUporGeslo.UseVisualStyleBackColor = true;
            this.btnSprUporGeslo.Click += new System.EventHandler(this.btnSprUporGeslo_Click);
            // 
            // btnPregledUporabnikov
            // 
            this.btnPregledUporabnikov.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPregledUporabnikov.Location = new System.Drawing.Point(0, 30);
            this.btnPregledUporabnikov.Name = "btnPregledUporabnikov";
            this.btnPregledUporabnikov.Size = new System.Drawing.Size(214, 30);
            this.btnPregledUporabnikov.TabIndex = 1;
            this.btnPregledUporabnikov.Text = "Pregled uporabnikov";
            this.btnPregledUporabnikov.UseVisualStyleBackColor = true;
            this.btnPregledUporabnikov.Click += new System.EventHandler(this.btnPregledUporabnikov_Click);
            // 
            // btnDodajUporabnika
            // 
            this.btnDodajUporabnika.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDodajUporabnika.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDodajUporabnika.Location = new System.Drawing.Point(0, 0);
            this.btnDodajUporabnika.Name = "btnDodajUporabnika";
            this.btnDodajUporabnika.Size = new System.Drawing.Size(214, 30);
            this.btnDodajUporabnika.TabIndex = 0;
            this.btnDodajUporabnika.Text = "Dodaj uporabnika";
            this.btnDodajUporabnika.UseVisualStyleBackColor = true;
            this.btnDodajUporabnika.Click += new System.EventHandler(this.btnDodajUporabnika_Click);
            // 
            // panelSestra
            // 
            this.panelSestra.AutoSize = true;
            this.panelSestra.Controls.Add(this.btnPregledPacientov);
            this.panelSestra.Controls.Add(this.btnSpremeniPacienta);
            this.panelSestra.Controls.Add(this.btnDodajPacienta);
            this.panelSestra.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSestra.Location = new System.Drawing.Point(0, 90);
            this.panelSestra.Margin = new System.Windows.Forms.Padding(4);
            this.panelSestra.Name = "panelSestra";
            this.panelSestra.Size = new System.Drawing.Size(214, 90);
            this.panelSestra.TabIndex = 2;
            // 
            // btnPregledPacientov
            // 
            this.btnPregledPacientov.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPregledPacientov.Location = new System.Drawing.Point(0, 60);
            this.btnPregledPacientov.Name = "btnPregledPacientov";
            this.btnPregledPacientov.Size = new System.Drawing.Size(214, 30);
            this.btnPregledPacientov.TabIndex = 3;
            this.btnPregledPacientov.Text = "Pregled pacientov";
            this.btnPregledPacientov.UseVisualStyleBackColor = true;
            // 
            // btnSpremeniPacienta
            // 
            this.btnSpremeniPacienta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSpremeniPacienta.Location = new System.Drawing.Point(0, 30);
            this.btnSpremeniPacienta.Name = "btnSpremeniPacienta";
            this.btnSpremeniPacienta.Size = new System.Drawing.Size(214, 30);
            this.btnSpremeniPacienta.TabIndex = 2;
            this.btnSpremeniPacienta.Text = "Spremeni pacientove podatke";
            this.btnSpremeniPacienta.UseVisualStyleBackColor = true;
            // 
            // btnDodajPacienta
            // 
            this.btnDodajPacienta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDodajPacienta.Location = new System.Drawing.Point(0, 0);
            this.btnDodajPacienta.Name = "btnDodajPacienta";
            this.btnDodajPacienta.Size = new System.Drawing.Size(214, 30);
            this.btnDodajPacienta.TabIndex = 0;
            this.btnDodajPacienta.Text = "Dodaj pacienta";
            this.btnDodajPacienta.UseVisualStyleBackColor = true;
            // 
            // panelDoktor
            // 
            this.panelDoktor.AutoSize = true;
            this.panelDoktor.Controls.Add(this.btnDoktorKartoteka);
            this.panelDoktor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDoktor.Location = new System.Drawing.Point(0, 60);
            this.panelDoktor.Margin = new System.Windows.Forms.Padding(4);
            this.panelDoktor.Name = "panelDoktor";
            this.panelDoktor.Size = new System.Drawing.Size(214, 30);
            this.panelDoktor.TabIndex = 1;
            // 
            // btnDoktorKartoteka
            // 
            this.btnDoktorKartoteka.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoktorKartoteka.Location = new System.Drawing.Point(0, 0);
            this.btnDoktorKartoteka.Name = "btnDoktorKartoteka";
            this.btnDoktorKartoteka.Size = new System.Drawing.Size(214, 30);
            this.btnDoktorKartoteka.TabIndex = 0;
            this.btnDoktorKartoteka.Text = "Pacienti";
            this.btnDoktorKartoteka.UseVisualStyleBackColor = true;
            this.btnDoktorKartoteka.Click += new System.EventHandler(this.btnDoktorKartoteka_Click);
            // 
            // panelPacient
            // 
            this.panelPacient.AutoSize = true;
            this.panelPacient.Controls.Add(this.btnPacientTermini);
            this.panelPacient.Controls.Add(this.btnPacientPodatki);
            this.panelPacient.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPacient.Location = new System.Drawing.Point(0, 0);
            this.panelPacient.Margin = new System.Windows.Forms.Padding(4);
            this.panelPacient.Name = "panelPacient";
            this.panelPacient.Size = new System.Drawing.Size(214, 60);
            this.panelPacient.TabIndex = 0;
            // 
            // btnPacientTermini
            // 
            this.btnPacientTermini.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPacientTermini.Location = new System.Drawing.Point(0, 30);
            this.btnPacientTermini.Margin = new System.Windows.Forms.Padding(4);
            this.btnPacientTermini.Name = "btnPacientTermini";
            this.btnPacientTermini.Size = new System.Drawing.Size(214, 30);
            this.btnPacientTermini.TabIndex = 1;
            this.btnPacientTermini.Text = "Termini";
            this.btnPacientTermini.UseVisualStyleBackColor = true;
            this.btnPacientTermini.Click += new System.EventHandler(this.btnPacientTermini_Click);
            // 
            // btnPacientPodatki
            // 
            this.btnPacientPodatki.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPacientPodatki.Location = new System.Drawing.Point(0, 0);
            this.btnPacientPodatki.Margin = new System.Windows.Forms.Padding(4);
            this.btnPacientPodatki.Name = "btnPacientPodatki";
            this.btnPacientPodatki.Size = new System.Drawing.Size(214, 30);
            this.btnPacientPodatki.TabIndex = 0;
            this.btnPacientPodatki.Text = "Moji Podatki";
            this.btnPacientPodatki.UseVisualStyleBackColor = true;
            this.btnPacientPodatki.Click += new System.EventHandler(this.btnPacientPodatki_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 587);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(659, 194);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Bolnišnica Doriana";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelAdmin.ResumeLayout(false);
            this.panelSestra.ResumeLayout(false);
            this.panelDoktor.ResumeLayout(false);
            this.panelPacient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.Button btnDodajUporabnika;
        private System.Windows.Forms.Panel panelSestra;
        private System.Windows.Forms.Button btnDodajPacienta;
        private System.Windows.Forms.Panel panelDoktor;
        private System.Windows.Forms.Button btnDoktorKartoteka;
        private System.Windows.Forms.Panel panelPacient;
        private System.Windows.Forms.Button btnPacientTermini;
        private System.Windows.Forms.Button btnPacientPodatki;
        private System.Windows.Forms.Button btnPregledUporabnikov;
        private System.Windows.Forms.Button btnSpremSvojeGeslo;
        private System.Windows.Forms.Button btnSprUporGeslo;
        private System.Windows.Forms.Button btnPregledPacientov;
        private System.Windows.Forms.Button btnSpremeniPacienta;
        private System.Windows.Forms.Button btnOdjava;



    }
}