﻿namespace Todos_los_items_del_Indec
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.bttnPDFpath = new System.Windows.Forms.Button();
            this.textBoxPDFPath = new System.Windows.Forms.TextBox();
            this.bttnFirstPage = new System.Windows.Forms.Button();
            this.bttnLastPage = new System.Windows.Forms.Button();
            this.maskedFirstPage = new System.Windows.Forms.MaskedTextBox();
            this.maskedLastPage = new System.Windows.Forms.MaskedTextBox();
            this.bttnTXT = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxTXTPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bttnPDFpath
            // 
            this.bttnPDFpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnPDFpath.Location = new System.Drawing.Point(39, 139);
            this.bttnPDFpath.Name = "bttnPDFpath";
            this.bttnPDFpath.Size = new System.Drawing.Size(201, 34);
            this.bttnPDFpath.TabIndex = 0;
            this.bttnPDFpath.Text = "Obtener el archivo PDF";
            this.bttnPDFpath.UseVisualStyleBackColor = true;
            this.bttnPDFpath.Click += new System.EventHandler(this.bttnPDFpath_Click);
            // 
            // textBoxPDFPath
            // 
            this.textBoxPDFPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPDFPath.Location = new System.Drawing.Point(281, 145);
            this.textBoxPDFPath.Name = "textBoxPDFPath";
            this.textBoxPDFPath.Size = new System.Drawing.Size(276, 22);
            this.textBoxPDFPath.TabIndex = 1;
            // 
            // bttnFirstPage
            // 
            this.bttnFirstPage.Enabled = false;
            this.bttnFirstPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnFirstPage.Location = new System.Drawing.Point(39, 179);
            this.bttnFirstPage.Name = "bttnFirstPage";
            this.bttnFirstPage.Size = new System.Drawing.Size(201, 34);
            this.bttnFirstPage.TabIndex = 2;
            this.bttnFirstPage.Text = "Primera pagina del anexo";
            this.bttnFirstPage.UseVisualStyleBackColor = true;
            this.bttnFirstPage.Click += new System.EventHandler(this.bttnFirstPage_Click);
            // 
            // bttnLastPage
            // 
            this.bttnLastPage.Enabled = false;
            this.bttnLastPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnLastPage.Location = new System.Drawing.Point(39, 219);
            this.bttnLastPage.Name = "bttnLastPage";
            this.bttnLastPage.Size = new System.Drawing.Size(201, 34);
            this.bttnLastPage.TabIndex = 3;
            this.bttnLastPage.Text = "Ultima pagina del anexo";
            this.bttnLastPage.UseVisualStyleBackColor = true;
            this.bttnLastPage.Click += new System.EventHandler(this.bttnLastPage_Click);
            // 
            // maskedFirstPage
            // 
            this.maskedFirstPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedFirstPage.Location = new System.Drawing.Point(281, 185);
            this.maskedFirstPage.Name = "maskedFirstPage";
            this.maskedFirstPage.Size = new System.Drawing.Size(276, 22);
            this.maskedFirstPage.TabIndex = 4;
            // 
            // maskedLastPage
            // 
            this.maskedLastPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedLastPage.Location = new System.Drawing.Point(281, 225);
            this.maskedLastPage.Name = "maskedLastPage";
            this.maskedLastPage.Size = new System.Drawing.Size(276, 22);
            this.maskedLastPage.TabIndex = 5;
            // 
            // bttnTXT
            // 
            this.bttnTXT.Enabled = false;
            this.bttnTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnTXT.Location = new System.Drawing.Point(39, 287);
            this.bttnTXT.Name = "bttnTXT";
            this.bttnTXT.Size = new System.Drawing.Size(518, 34);
            this.bttnTXT.TabIndex = 6;
            this.bttnTXT.Text = "Crear y Guardar TXT";
            this.bttnTXT.UseVisualStyleBackColor = true;
            this.bttnTXT.Click += new System.EventHandler(this.bttnTXT_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(621, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(542, 536);
            this.dataGridView1.TabIndex = 7;
            // 
            // textBoxTXTPath
            // 
            this.textBoxTXTPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTXTPath.Location = new System.Drawing.Point(39, 259);
            this.textBoxTXTPath.Name = "textBoxTXTPath";
            this.textBoxTXTPath.Size = new System.Drawing.Size(518, 22);
            this.textBoxTXTPath.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 560);
            this.Controls.Add(this.textBoxTXTPath);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bttnTXT);
            this.Controls.Add(this.maskedLastPage);
            this.Controls.Add(this.maskedFirstPage);
            this.Controls.Add(this.bttnLastPage);
            this.Controls.Add(this.bttnFirstPage);
            this.Controls.Add(this.textBoxPDFPath);
            this.Controls.Add(this.bttnPDFpath);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Items del Indec";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttnPDFpath;
        private System.Windows.Forms.TextBox textBoxPDFPath;
        private System.Windows.Forms.Button bttnFirstPage;
        private System.Windows.Forms.Button bttnLastPage;
        private System.Windows.Forms.MaskedTextBox maskedFirstPage;
        private System.Windows.Forms.MaskedTextBox maskedLastPage;
        private System.Windows.Forms.Button bttnTXT;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxTXTPath;
    }
}

