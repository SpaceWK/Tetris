namespace TetrisFinal1
{
    partial class Square
    {

        private System.ComponentModel.IContainer components = null;

        // golesc toate resursele folosite

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// metoda pentru Designer support - sa nu fie modificat
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Square
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.Name = "Square";
            this.Size = new System.Drawing.Size(51, 54);
            this.ResumeLayout(false);

        }

        #endregion
    }
}