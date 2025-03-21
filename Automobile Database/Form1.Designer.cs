namespace Automobile_Database
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
            dgvAutos = new DataGridView();
            txtFilter = new TextBox();
            plotAspiration = new ScottPlot.WinForms.FormsPlot();
            plotNumOfDoors = new ScottPlot.WinForms.FormsPlot();
            plotBodyStyle = new ScottPlot.WinForms.FormsPlot();
            plotFuelType = new ScottPlot.WinForms.FormsPlot();
            plotDriveWheels = new ScottPlot.WinForms.FormsPlot();
            btnFilter = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAutos).BeginInit();
            SuspendLayout();
            // 
            // dgvAutos
            // 
            dgvAutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutos.Location = new Point(12, 51);
            dgvAutos.Name = "dgvAutos";
            dgvAutos.RowTemplate.Height = 25;
            dgvAutos.Size = new Size(762, 196);
            dgvAutos.TabIndex = 0;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(12, 22);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(171, 23);
            txtFilter.TabIndex = 1;
            txtFilter.TextChanged += txtFilter_TextChanged;
            // 
            // plotAspiration
            // 
            plotAspiration.DisplayScale = 1F;
            plotAspiration.Location = new Point(29, 277);
            plotAspiration.Name = "plotAspiration";
            plotAspiration.Size = new Size(233, 150);
            plotAspiration.TabIndex = 2;
            // 
            // plotNumOfDoors
            // 
            plotNumOfDoors.DisplayScale = 1F;
            plotNumOfDoors.Location = new Point(284, 277);
            plotNumOfDoors.Name = "plotNumOfDoors";
            plotNumOfDoors.Size = new Size(233, 150);
            plotNumOfDoors.TabIndex = 3;
            // 
            // plotBodyStyle
            // 
            plotBodyStyle.DisplayScale = 1F;
            plotBodyStyle.Location = new Point(541, 277);
            plotBodyStyle.Name = "plotBodyStyle";
            plotBodyStyle.Size = new Size(233, 150);
            plotBodyStyle.TabIndex = 4;
            // 
            // plotFuelType
            // 
            plotFuelType.DisplayScale = 1F;
            plotFuelType.Location = new Point(792, 71);
            plotFuelType.Name = "plotFuelType";
            plotFuelType.Size = new Size(233, 150);
            plotFuelType.TabIndex = 6;
            // 
            // plotDriveWheels
            // 
            plotDriveWheels.DisplayScale = 1F;
            plotDriveWheels.Location = new Point(792, 277);
            plotDriveWheels.Name = "plotDriveWheels";
            plotDriveWheels.Size = new Size(233, 150);
            plotDriveWheels.TabIndex = 5;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(216, 21);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 23);
            btnFilter.TabIndex = 7;
            btnFilter.Text = "filter";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 543);
            Controls.Add(btnFilter);
            Controls.Add(plotFuelType);
            Controls.Add(plotDriveWheels);
            Controls.Add(plotBodyStyle);
            Controls.Add(plotNumOfDoors);
            Controls.Add(plotAspiration);
            Controls.Add(txtFilter);
            Controls.Add(dgvAutos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAutos;
        private TextBox txtFilter;
        private ScottPlot.WinForms.FormsPlot plotAspiration;
        private ScottPlot.WinForms.FormsPlot plotNumOfDoors;
        private ScottPlot.WinForms.FormsPlot plotBodyStyle;
        private ScottPlot.WinForms.FormsPlot plotFuelType;
        private ScottPlot.WinForms.FormsPlot plotDriveWheels;
        private Button btnFilter;
    }
}