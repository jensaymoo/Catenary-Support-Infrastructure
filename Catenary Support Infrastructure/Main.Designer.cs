﻿namespace CatenarySupport
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            Defects = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridcontrol_masts = new DevExpress.XtraGrid.GridControl();
            gridview_masts = new DevExpress.XtraGrid.Views.Grid.GridView();
            navigationtab = new DevExpress.XtraBars.Navigation.TabPane();
            navtab_masts = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            natab_protocols = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            gridcontrol_protocols = new DevExpress.XtraGrid.GridControl();
            gridview_protocols = new DevExpress.XtraGrid.Views.Grid.GridView();
            navtab_measurments = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            gridcontrol_measurments = new DevExpress.XtraGrid.GridControl();
            gridview_measurments = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)Defects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridcontrol_masts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridview_masts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)navigationtab).BeginInit();
            navigationtab.SuspendLayout();
            navtab_masts.SuspendLayout();
            natab_protocols.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridcontrol_protocols).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridview_protocols).BeginInit();
            navtab_measurments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridcontrol_measurments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridview_measurments).BeginInit();
            SuspendLayout();
            // 
            // Defects
            // 
            Defects.Appearance.Row.BackColor = Color.FromArgb(255, 128, 0);
            Defects.Appearance.Row.Options.UseBackColor = true;
            Defects.GridControl = gridcontrol_masts;
            Defects.Name = "Defects";
            // 
            // gridcontrol_masts
            // 
            gridcontrol_masts.Dock = DockStyle.Fill;
            gridcontrol_masts.EmbeddedNavigator.Margin = new Padding(4);
            gridLevelNode1.LevelTemplate = Defects;
            gridLevelNode1.RelationName = "Details";
            gridcontrol_masts.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1 });
            gridcontrol_masts.Location = new Point(0, 0);
            gridcontrol_masts.MainView = gridview_masts;
            gridcontrol_masts.Margin = new Padding(4, 10, 4, 4);
            gridcontrol_masts.Name = "gridcontrol_masts";
            gridcontrol_masts.Padding = new Padding(0, 10, 0, 0);
            gridcontrol_masts.Size = new Size(1183, 908);
            gridcontrol_masts.TabIndex = 2;
            gridcontrol_masts.UseEmbeddedNavigator = true;
            gridcontrol_masts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridview_masts, Defects });
            // 
            // gridview_masts
            // 
            gridview_masts.DetailHeight = 431;
            gridview_masts.GridControl = gridcontrol_masts;
            gridview_masts.Name = "gridview_masts";
            gridview_masts.OptionsEditForm.PopupEditFormWidth = 933;
            gridview_masts.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            gridview_masts.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gridview_masts.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // navigationtab
            // 
            navigationtab.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True;
            navigationtab.Controls.Add(navtab_masts);
            navigationtab.Controls.Add(natab_protocols);
            navigationtab.Controls.Add(navtab_measurments);
            navigationtab.Dock = DockStyle.Fill;
            navigationtab.Location = new Point(0, 0);
            navigationtab.Name = "navigationtab";
            navigationtab.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { navtab_masts, natab_protocols, navtab_measurments });
            navigationtab.RegularSize = new Size(1183, 949);
            navigationtab.SelectedPage = navtab_masts;
            navigationtab.Size = new Size(1183, 949);
            navigationtab.TabIndex = 2;
            navigationtab.Text = "tabPane1";
            navigationtab.TransitionAnimationProperties.FrameCount = 100;
            // 
            // navtab_masts
            // 
            navtab_masts.Caption = "Опоры";
            navtab_masts.Controls.Add(gridcontrol_masts);
            navtab_masts.Name = "navtab_masts";
            navtab_masts.Size = new Size(1183, 908);
            // 
            // natab_protocols
            // 
            natab_protocols.BackgroundPadding = new Padding(20, 20, 21, 20);
            natab_protocols.Caption = "Протоколы";
            natab_protocols.Controls.Add(gridcontrol_protocols);
            natab_protocols.Name = "natab_protocols";
            natab_protocols.Size = new Size(1183, 908);
            // 
            // gridcontrol_protocols
            // 
            gridcontrol_protocols.Dock = DockStyle.Fill;
            gridcontrol_protocols.EmbeddedNavigator.Margin = new Padding(4);
            gridcontrol_protocols.Location = new Point(0, 0);
            gridcontrol_protocols.MainView = gridview_protocols;
            gridcontrol_protocols.Margin = new Padding(4);
            gridcontrol_protocols.Name = "gridcontrol_protocols";
            gridcontrol_protocols.Size = new Size(1183, 908);
            gridcontrol_protocols.TabIndex = 3;
            gridcontrol_protocols.UseEmbeddedNavigator = true;
            gridcontrol_protocols.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridview_protocols });
            // 
            // gridview_protocols
            // 
            gridview_protocols.DetailHeight = 431;
            gridview_protocols.GridControl = gridcontrol_protocols;
            gridview_protocols.Name = "gridview_protocols";
            gridview_protocols.OptionsEditForm.PopupEditFormWidth = 933;
            gridview_protocols.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            gridview_protocols.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gridview_protocols.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // navtab_measurments
            // 
            navtab_measurments.Caption = "Измерения";
            navtab_measurments.Controls.Add(gridcontrol_measurments);
            navtab_measurments.Name = "navtab_measurments";
            navtab_measurments.Size = new Size(1183, 908);
            // 
            // gridcontrol_measurments
            // 
            gridcontrol_measurments.Dock = DockStyle.Fill;
            gridcontrol_measurments.EmbeddedNavigator.Margin = new Padding(4);
            gridcontrol_measurments.Location = new Point(0, 0);
            gridcontrol_measurments.MainView = gridview_measurments;
            gridcontrol_measurments.Margin = new Padding(4, 10, 4, 4);
            gridcontrol_measurments.Name = "gridcontrol_measurments";
            gridcontrol_measurments.Padding = new Padding(0, 10, 0, 0);
            gridcontrol_measurments.Size = new Size(1183, 908);
            gridcontrol_measurments.TabIndex = 3;
            gridcontrol_measurments.UseEmbeddedNavigator = true;
            gridcontrol_measurments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridview_measurments });
            // 
            // gridview_measurments
            // 
            gridview_measurments.DetailHeight = 431;
            gridview_measurments.GridControl = gridcontrol_measurments;
            gridview_measurments.Name = "gridview_measurments";
            gridview_measurments.OptionsEditForm.EditFormColumnCount = 5;
            gridview_measurments.OptionsEditForm.PopupEditFormWidth = 933;
            gridview_measurments.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            gridview_measurments.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gridview_measurments.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1183, 949);
            Controls.Add(navigationtab);
            Margin = new Padding(4);
            Name = "Main";
            Text = "Catenary Support Infrastructure";
            Shown += Main_Shown;
            ((System.ComponentModel.ISupportInitialize)Defects).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridcontrol_masts).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridview_masts).EndInit();
            ((System.ComponentModel.ISupportInitialize)navigationtab).EndInit();
            navigationtab.ResumeLayout(false);
            navtab_masts.ResumeLayout(false);
            natab_protocols.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridcontrol_protocols).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridview_protocols).EndInit();
            navtab_measurments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridcontrol_measurments).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridview_measurments).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraBars.Navigation.TabPane navigationtab;
        private DevExpress.XtraBars.Navigation.TabNavigationPage navtab_masts;
        private DevExpress.XtraGrid.GridControl gridcontrol_masts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridview_masts;
        private DevExpress.XtraBars.Navigation.TabNavigationPage natab_protocols;
        private DevExpress.XtraGrid.GridControl gridcontrol_protocols;
        private DevExpress.XtraGrid.Views.Grid.GridView gridview_protocols;
        private DevExpress.XtraBars.Navigation.TabNavigationPage navtab_measurments;
        private DevExpress.XtraGrid.GridControl gridcontrol_measurments;
        private DevExpress.XtraGrid.Views.Grid.GridView gridview_measurments;
        private DevExpress.XtraGrid.Views.Grid.GridView Defects;
    }
}