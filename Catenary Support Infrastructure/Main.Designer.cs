namespace CatenarySupport
{
    partial class Main
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
            gridControl = new DevExpress.XtraGrid.GridControl();
            gridview_masts = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridview_protocols = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)gridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridview_masts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridview_protocols).BeginInit();
            SuspendLayout();
            // 
            // gridControl
            // 
            gridControl.Dock = DockStyle.Fill;
            gridControl.EmbeddedNavigator.Margin = new Padding(4);
            gridControl.Location = new Point(0, 0);
            gridControl.MainView = gridview_masts;
            gridControl.Margin = new Padding(4);
            gridControl.Name = "gridControl";
            gridControl.Size = new Size(1183, 949);
            gridControl.TabIndex = 0;
            gridControl.UseEmbeddedNavigator = true;
            gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridview_masts, gridview_protocols });
            // 
            // gridview_masts
            // 
            gridview_masts.DetailHeight = 431;
            gridview_masts.GridControl = gridControl;
            gridview_masts.Name = "gridview_masts";
            gridview_masts.OptionsEditForm.PopupEditFormWidth = 933;
            gridview_masts.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            gridview_masts.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gridview_masts.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // gridview_protocols
            // 
            gridview_protocols.DetailHeight = 431;
            gridview_protocols.GridControl = gridControl;
            gridview_protocols.Name = "gridview_protocols";
            gridview_protocols.OptionsEditForm.PopupEditFormWidth = 933;
            gridview_protocols.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            gridview_protocols.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gridview_protocols.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1183, 949);
            Controls.Add(gridControl);
            Margin = new Padding(4);
            Name = "Main";
            Text = "XtraForm1";
            Shown += Main_Shown;
            ((System.ComponentModel.ISupportInitialize)gridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridview_masts).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridview_protocols).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridview_masts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridview_protocols;
    }
}