using ClassLibrary.Enums;
using ClassLibrary.Models;
using System.ComponentModel;

namespace MainForms.Forms;

partial class MainForm
{
    private IContainer components = null;

    

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    private void InitializeComponent()
    {
        components = new Container();
        tableLayoutPanel1 = new TableLayoutPanel();
        flowLayoutPanel1 = new FlowLayoutPanel();
        menuStrip1 = new MenuStrip();
        toFileToolStripMenuItem = new ToolStripMenuItem();
        automaticToolStripMenuItem = new ToolStripMenuItem();
        grenadesToolStripMenuItem = new ToolStripMenuItem();
        toolStripMenuItem1 = new ToolStripMenuItem();
        toRichTextBoxToolStripMenuItem = new ToolStripMenuItem();
        automaticToolStripMenuItem1 = new ToolStripMenuItem();
        grenadesToolStripMenuItem1 = new ToolStripMenuItem();
        tabControl1 = new TabControl();
        tabPage1 = new TabPage();
        tableLayoutPanel2 = new TableLayoutPanel();
        tableLayoutPanel3 = new TableLayoutPanel();
        left_manufacturer_label = new Label();
        left_manufactured_lable = new Label();
        left_manufacturer_input = new TextBox();
        left_manufactured_input = new DateTimePicker();
        left_weight_label = new Label();
        left_weight_input = new TextBox();
        left_fireRate_label = new Label();
        left_fireMode_label = new Label();
        left_magazineCap_label = new Label();
        left_manufCountry_label = new Label();
        left_AmmoCount_label = new Label();
        left_Caliber_label = new Label();
        left_Range_label = new Label();
        left_Accuracy_label = new Label();
        left_info_label = new Label();
        left_firerate_input = new TextBox();
        left_fireMode_input = new ComboBox();
        left_magCap_input = new TextBox();
        left_manufCountry_input = new TextBox();
        left_ammoCount_input = new TextBox();
        left_caliber_input = new TextBox();
        left_range_input = new TextBox();
        left_accuracy_input = new TextBox();
        left_info_input = new RichTextBox();
        flowLayoutPanel2 = new FlowLayoutPanel();
        left_prev_button = new Button();
        left_next_button = new Button();
        flowLayoutPanel3 = new FlowLayoutPanel();
        left_save_button = new Button();
        left_delete_button = new Button();
        left_new_button = new Button();
        right_tablePanel = new TableLayoutPanel();
        tableLayoutPanel4 = new TableLayoutPanel();
        right_saveGrenade_button = new Button();
        right_type_label = new Label();
        right_explosType_label = new Label();
        right_blast_radius_label = new Label();
        right_info_label = new Label();
        right_weight_label = new Label();
        right_manufactured_label = new Label();
        right_manufacturer_label = new Label();
        right_info_input = new RichTextBox();
        right_type_input = new TextBox();
        right_explosionType_input = new ComboBox();
        right_blastRadius_input = new TextBox();
        right_weight_input = new TextBox();
        right_manufacturer_input = new TextBox();
        right_manufactured_input = new DateTimePicker();
        dataGridView1 = new DataGridView();
        tabPage2 = new TabPage();
        richTextBox1 = new RichTextBox();
        dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
        deleteGrenade = new DataGridViewButtonColumn();
        contextMenuStrip1 = new ContextMenuStrip(components);
        tableLayoutPanel1.SuspendLayout();
        flowLayoutPanel1.SuspendLayout();
        menuStrip1.SuspendLayout();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        tableLayoutPanel3.SuspendLayout();
        flowLayoutPanel2.SuspendLayout();
        flowLayoutPanel3.SuspendLayout();
        right_tablePanel.SuspendLayout();
        tableLayoutPanel4.SuspendLayout();
        ((ISupportInitialize)dataGridView1).BeginInit();
        tabPage2.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.AutoSize = true;
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
        tableLayoutPanel1.Controls.Add(tabControl1, 0, 1);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.111821F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 94.888176F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel1.Size = new Size(1195, 650);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.Controls.Add(menuStrip1);
        flowLayoutPanel1.Location = new Point(3, 3);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new Size(1189, 26);
        flowLayoutPanel1.TabIndex = 0;
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { toFileToolStripMenuItem, toolStripMenuItem1, toRichTextBoxToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(168, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // toFileToolStripMenuItem
        // 
        toFileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { automaticToolStripMenuItem, grenadesToolStripMenuItem });
        toFileToolStripMenuItem.Name = "toFileToolStripMenuItem";
        toFileToolStripMenuItem.Size = new Size(50, 20);
        toFileToolStripMenuItem.Text = "To file";
        // 
        // automaticToolStripMenuItem
        // 
        automaticToolStripMenuItem.Name = "automaticToolStripMenuItem";
        automaticToolStripMenuItem.Size = new Size(130, 22);
        automaticToolStripMenuItem.Text = "Automatic";
        automaticToolStripMenuItem.Click += AutomaticToFile;
        // 
        // grenadesToolStripMenuItem
        // 
        grenadesToolStripMenuItem.Name = "grenadesToolStripMenuItem";
        grenadesToolStripMenuItem.Size = new Size(130, 22);
        grenadesToolStripMenuItem.Text = "Grenades";
        grenadesToolStripMenuItem.Click += GrenadesToFile;
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new Size(12, 20);
        // 
        // toRichTextBoxToolStripMenuItem
        // 
        toRichTextBoxToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { automaticToolStripMenuItem1, grenadesToolStripMenuItem1 });
        toRichTextBoxToolStripMenuItem.Name = "toRichTextBoxToolStripMenuItem";
        toRichTextBoxToolStripMenuItem.Size = new Size(98, 20);
        toRichTextBoxToolStripMenuItem.Text = "To RichTextBox";
        // 
        // automaticToolStripMenuItem1
        // 
        automaticToolStripMenuItem1.Name = "automaticToolStripMenuItem1";
        automaticToolStripMenuItem1.Size = new Size(130, 22);
        automaticToolStripMenuItem1.Text = "Automatic";
        automaticToolStripMenuItem1.Click += AutomaticToRichTextBox;
        // 
        // grenadesToolStripMenuItem1
        // 
        grenadesToolStripMenuItem1.Name = "grenadesToolStripMenuItem1";
        grenadesToolStripMenuItem1.Size = new Size(130, 22);
        grenadesToolStripMenuItem1.Text = "Grenades";
        grenadesToolStripMenuItem1.Click += GrenadesToRichTextBox;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Location = new Point(5, 38);
        tabControl1.Margin = new Padding(5);
        tabControl1.Name = "tabControl1";
        tabControl1.Padding = new Point(6, 4);
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(1185, 607);
        tabControl1.TabIndex = 1;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(tableLayoutPanel2);
        tabPage1.Location = new Point(4, 26);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new Padding(3);
        tabPage1.Size = new Size(1177, 577);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Collections";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.AutoSize = true;
        tableLayoutPanel2.ColumnCount = 2;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
        tableLayoutPanel2.Controls.Add(right_tablePanel, 1, 0);
        tableLayoutPanel2.Dock = DockStyle.Fill;
        tableLayoutPanel2.Location = new Point(3, 3);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 1;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel2.Size = new Size(1171, 571);
        tableLayoutPanel2.TabIndex = 0;
        // 
        // tableLayoutPanel3
        // 
        tableLayoutPanel3.AutoSize = true;
        tableLayoutPanel3.ColumnCount = 2;
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.40517F));
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.5948257F));
        tableLayoutPanel3.Controls.Add(left_manufacturer_label, 0, 0);
        tableLayoutPanel3.Controls.Add(left_manufactured_lable, 0, 1);
        tableLayoutPanel3.Controls.Add(left_manufacturer_input, 1, 0);
        tableLayoutPanel3.Controls.Add(left_manufactured_input, 1, 1);
        tableLayoutPanel3.Controls.Add(left_weight_label, 0, 2);
        tableLayoutPanel3.Controls.Add(left_weight_input, 1, 2);
        tableLayoutPanel3.Controls.Add(left_fireRate_label, 0, 3);
        tableLayoutPanel3.Controls.Add(left_fireMode_label, 0, 4);
        tableLayoutPanel3.Controls.Add(left_magazineCap_label, 0, 5);
        tableLayoutPanel3.Controls.Add(left_manufCountry_label, 0, 6);
        tableLayoutPanel3.Controls.Add(left_AmmoCount_label, 0, 7);
        tableLayoutPanel3.Controls.Add(left_Caliber_label, 0, 8);
        tableLayoutPanel3.Controls.Add(left_Range_label, 0, 9);
        tableLayoutPanel3.Controls.Add(left_Accuracy_label, 0, 10);
        tableLayoutPanel3.Controls.Add(left_info_label, 0, 11);
        tableLayoutPanel3.Controls.Add(left_firerate_input, 1, 3);
        tableLayoutPanel3.Controls.Add(left_fireMode_input, 1, 4);
        tableLayoutPanel3.Controls.Add(left_magCap_input, 1, 5);
        tableLayoutPanel3.Controls.Add(left_manufCountry_input, 1, 6);
        tableLayoutPanel3.Controls.Add(left_ammoCount_input, 1, 7);
        tableLayoutPanel3.Controls.Add(left_caliber_input, 1, 8);
        tableLayoutPanel3.Controls.Add(left_range_input, 1, 9);
        tableLayoutPanel3.Controls.Add(left_accuracy_input, 1, 10);
        tableLayoutPanel3.Controls.Add(left_info_input, 1, 11);
        tableLayoutPanel3.Controls.Add(flowLayoutPanel2, 0, 12);
        tableLayoutPanel3.Controls.Add(flowLayoutPanel3, 1, 12);
        tableLayoutPanel3.Dock = DockStyle.Fill;
        tableLayoutPanel3.Location = new Point(3, 3);
        tableLayoutPanel3.Name = "tableLayoutPanel3";
        tableLayoutPanel3.RowCount = 13;
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
        tableLayoutPanel3.Size = new Size(462, 565);
        tableLayoutPanel3.TabIndex = 0;
        // 
        // left_manufacturer_label
        // 
        left_manufacturer_label.AutoSize = true;
        left_manufacturer_label.Dock = DockStyle.Fill;
        left_manufacturer_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_manufacturer_label.Location = new Point(3, 0);
        left_manufacturer_label.Name = "left_manufacturer_label";
        left_manufacturer_label.Size = new Size(148, 30);
        left_manufacturer_label.TabIndex = 0;
        left_manufacturer_label.Text = "Manufacturer";
        left_manufacturer_label.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // left_manufactured_lable
        // 
        left_manufactured_lable.AutoSize = true;
        left_manufactured_lable.Dock = DockStyle.Fill;
        left_manufactured_lable.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_manufactured_lable.Location = new Point(3, 30);
        left_manufactured_lable.Name = "left_manufactured_lable";
        left_manufactured_lable.Size = new Size(148, 30);
        left_manufactured_lable.TabIndex = 1;
        left_manufactured_lable.Text = "Manufactured";
        left_manufactured_lable.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // left_manufacturer_input
        // 
        left_manufacturer_input.Dock = DockStyle.Fill;
        left_manufacturer_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_manufacturer_input.Location = new Point(157, 3);
        left_manufacturer_input.Name = "left_manufacturer_input";
        left_manufacturer_input.Size = new Size(302, 29);
        left_manufacturer_input.TabIndex = 2;
        // 
        // left_manufactured_input
        // 
        left_manufactured_input.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_manufactured_input.Dock = DockStyle.Fill;
        left_manufactured_input.Location = new Point(157, 33);
        left_manufactured_input.Name = "left_manufactured_input";
        left_manufactured_input.Size = new Size(302, 23);
        left_manufactured_input.TabIndex = 3;
        // 
        // left_weight_label
        // 
        left_weight_label.AutoSize = true;
        left_weight_label.Dock = DockStyle.Fill;
        left_weight_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_weight_label.Location = new Point(3, 60);
        left_weight_label.Name = "left_weight_label";
        left_weight_label.Size = new Size(148, 30);
        left_weight_label.TabIndex = 4;
        left_weight_label.Text = "Weight";
        left_weight_label.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // left_weight_input
        // 
        left_weight_input.Dock = DockStyle.Fill;
        left_weight_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_weight_input.Location = new Point(157, 63);
        left_weight_input.Name = "left_weight_input";
        left_weight_input.Size = new Size(302, 29);
        left_weight_input.TabIndex = 7;
        // 
        // left_fireRate_label
        // 
        left_fireRate_label.AutoSize = true;
        left_fireRate_label.Dock = DockStyle.Fill;
        left_fireRate_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_fireRate_label.Location = new Point(3, 90);
        left_fireRate_label.Name = "left_fireRate_label";
        left_fireRate_label.Size = new Size(148, 30);
        left_fireRate_label.TabIndex = 8;
        left_fireRate_label.Text = "FireRate";
        left_fireRate_label.TextAlign = ContentAlignment.MiddleLeft;
        left_fireRate_label.UseMnemonic = false;
        // 
        // left_fireMode_label
        // 
        left_fireMode_label.AutoSize = true;
        left_fireMode_label.Dock = DockStyle.Fill;
        left_fireMode_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_fireMode_label.Location = new Point(3, 120);
        left_fireMode_label.Name = "left_fireMode_label";
        left_fireMode_label.Size = new Size(148, 30);
        left_fireMode_label.TabIndex = 9;
        left_fireMode_label.Text = "Fire Mode";
        left_fireMode_label.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // left_magazineCap_label
        // 
        left_magazineCap_label.AutoSize = true;
        left_magazineCap_label.Dock = DockStyle.Fill;
        left_magazineCap_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_magazineCap_label.Location = new Point(3, 150);
        left_magazineCap_label.Name = "left_magazineCap_label";
        left_magazineCap_label.Size = new Size(148, 30);
        left_magazineCap_label.TabIndex = 10;
        left_magazineCap_label.Text = "Magazine Capacity";
        left_magazineCap_label.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // left_manufCountry_label
        // 
        left_manufCountry_label.AutoSize = true;
        left_manufCountry_label.Dock = DockStyle.Fill;
        left_manufCountry_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_manufCountry_label.Location = new Point(3, 180);
        left_manufCountry_label.Name = "left_manufCountry_label";
        left_manufCountry_label.Size = new Size(148, 30);
        left_manufCountry_label.TabIndex = 11;
        left_manufCountry_label.Text = "Country";
        left_manufCountry_label.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // left_AmmoCount_label
        // 
        left_AmmoCount_label.AutoSize = true;
        left_AmmoCount_label.Dock = DockStyle.Fill;
        left_AmmoCount_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_AmmoCount_label.Location = new Point(3, 210);
        left_AmmoCount_label.Name = "left_AmmoCount_label";
        left_AmmoCount_label.Size = new Size(148, 30);
        left_AmmoCount_label.TabIndex = 12;
        left_AmmoCount_label.Text = "Ammo Count";
        left_AmmoCount_label.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // left_Caliber_label
        // 
        left_Caliber_label.AutoSize = true;
        left_Caliber_label.Dock = DockStyle.Fill;
        left_Caliber_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_Caliber_label.Location = new Point(3, 240);
        left_Caliber_label.Name = "left_Caliber_label";
        left_Caliber_label.Size = new Size(148, 30);
        left_Caliber_label.TabIndex = 13;
        left_Caliber_label.Text = "Caliber";
        left_Caliber_label.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // left_Range_label
        // 
        left_Range_label.AutoSize = true;
        left_Range_label.Dock = DockStyle.Fill;
        left_Range_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_Range_label.Location = new Point(3, 270);
        left_Range_label.Name = "left_Range_label";
        left_Range_label.Size = new Size(148, 30);
        left_Range_label.TabIndex = 14;
        left_Range_label.Text = "Range";
        left_Range_label.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // left_Accuracy_label
        // 
        left_Accuracy_label.AutoSize = true;
        left_Accuracy_label.Dock = DockStyle.Fill;
        left_Accuracy_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_Accuracy_label.Location = new Point(3, 300);
        left_Accuracy_label.Name = "left_Accuracy_label";
        left_Accuracy_label.Size = new Size(148, 30);
        left_Accuracy_label.TabIndex = 15;
        left_Accuracy_label.Text = "Accuracy";
        left_Accuracy_label.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // left_info_label
        // 
        left_info_label.AutoSize = true;
        left_info_label.Dock = DockStyle.Fill;
        left_info_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_info_label.Location = new Point(3, 330);
        left_info_label.Name = "left_info_label";
        left_info_label.Size = new Size(148, 200);
        left_info_label.TabIndex = 16;
        left_info_label.Text = "Info";
        left_info_label.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // left_firerate_input
        // 
        left_firerate_input.Dock = DockStyle.Fill;
        left_firerate_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_firerate_input.Location = new Point(157, 93);
        left_firerate_input.Name = "left_firerate_input";
        left_firerate_input.Size = new Size(302, 29);
        left_firerate_input.TabIndex = 17;
        // 
        // left_fireMode_input
        // 
        left_fireMode_input.Dock = DockStyle.Fill;
        left_fireMode_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_fireMode_input.FormattingEnabled = true;
        left_fireMode_input.Items.AddRange(new object[] { FireMode.SemiAutomatic, FireMode.BurstFire, FireMode.FullAuto });
        left_fireMode_input.Location = new Point(157, 123);
        left_fireMode_input.Name = "left_fireMode_input";
        left_fireMode_input.Size = new Size(302, 29);
        left_fireMode_input.TabIndex = 18;
        // 
        // left_magCap_input
        // 
        left_magCap_input.Dock = DockStyle.Fill;
        left_magCap_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_magCap_input.Location = new Point(157, 153);
        left_magCap_input.Name = "left_magCap_input";
        left_magCap_input.Size = new Size(302, 29);
        left_magCap_input.TabIndex = 19;
        // 
        // left_manufCountry_input
        // 
        left_manufCountry_input.Dock = DockStyle.Fill;
        left_manufCountry_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_manufCountry_input.Location = new Point(157, 183);
        left_manufCountry_input.Name = "left_manufCountry_input";
        left_manufCountry_input.Size = new Size(302, 29);
        left_manufCountry_input.TabIndex = 20;
        // 
        // left_ammoCount_input
        // 
        left_ammoCount_input.Dock = DockStyle.Fill;
        left_ammoCount_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_ammoCount_input.Location = new Point(157, 213);
        left_ammoCount_input.Name = "left_ammoCount_input";
        left_ammoCount_input.Size = new Size(302, 29);
        left_ammoCount_input.TabIndex = 21;
        // 
        // left_caliber_input
        // 
        left_caliber_input.Dock = DockStyle.Fill;
        left_caliber_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_caliber_input.Location = new Point(157, 243);
        left_caliber_input.Name = "left_caliber_input";
        left_caliber_input.Size = new Size(302, 29);
        left_caliber_input.TabIndex = 22;
        // 
        // left_range_input
        // 
        left_range_input.Dock = DockStyle.Fill;
        left_range_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_range_input.Location = new Point(157, 273);
        left_range_input.Name = "left_range_input";
        left_range_input.Size = new Size(302, 29);
        left_range_input.TabIndex = 23;
        // 
        // left_accuracy_input
        // 
        left_accuracy_input.Dock = DockStyle.Fill;
        left_accuracy_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_accuracy_input.Location = new Point(157, 303);
        left_accuracy_input.Name = "left_accuracy_input";
        left_accuracy_input.Size = new Size(302, 29);
        left_accuracy_input.TabIndex = 24;
        // 
        // left_info_input
        // 
        left_info_input.Dock = DockStyle.Fill;
        left_info_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        left_info_input.Location = new Point(157, 333);
        left_info_input.Name = "left_info_input";
        left_info_input.Size = new Size(302, 194);
        left_info_input.TabIndex = 25;
        left_info_input.Text = "";
        // 
        // flowLayoutPanel2
        // 
        flowLayoutPanel2.Controls.Add(left_prev_button);
        flowLayoutPanel2.Controls.Add(left_next_button);
        flowLayoutPanel2.Dock = DockStyle.Fill;
        flowLayoutPanel2.Location = new Point(3, 533);
        flowLayoutPanel2.Name = "flowLayoutPanel2";
        flowLayoutPanel2.Size = new Size(148, 29);
        flowLayoutPanel2.TabIndex = 26;
        // 
        // left_prev_button
        // 
        left_prev_button.Location = new Point(3, 3);
        left_prev_button.Name = "left_prev_button";
        left_prev_button.Size = new Size(70, 23);
        left_prev_button.TabIndex = 0;
        left_prev_button.Text = "Prev";
        left_prev_button.UseVisualStyleBackColor = true;
        left_prev_button.Click += AutomaticPrev;
        // 
        // left_next_button
        // 
        left_next_button.Location = new Point(79, 3);
        left_next_button.Name = "left_next_button";
        left_next_button.RightToLeft = RightToLeft.No;
        left_next_button.Size = new Size(64, 23);
        left_next_button.TabIndex = 2;
        left_next_button.Text = "Next";
        left_next_button.UseVisualStyleBackColor = true;
        left_next_button.Click += AutomaticNext;
        // 
        // flowLayoutPanel3
        // 
        flowLayoutPanel3.Controls.Add(left_save_button);
        flowLayoutPanel3.Controls.Add(left_delete_button);
        flowLayoutPanel3.Controls.Add(left_new_button);
        flowLayoutPanel3.Dock = DockStyle.Fill;
        flowLayoutPanel3.Location = new Point(157, 533);
        flowLayoutPanel3.Name = "flowLayoutPanel3";
        flowLayoutPanel3.Size = new Size(302, 29);
        flowLayoutPanel3.TabIndex = 27;
        // 
        // left_save_button
        // 
        left_save_button.Location = new Point(3, 3);
        left_save_button.Name = "left_save_button";
        left_save_button.Size = new Size(93, 23);
        left_save_button.TabIndex = 0;
        left_save_button.Text = "Save";
        left_save_button.UseVisualStyleBackColor = true;
        left_save_button.Click += SaveAutomatic;
        // 
        // left_delete_button
        // 
        left_delete_button.Location = new Point(102, 3);
        left_delete_button.Name = "left_delete_button";
        left_delete_button.Size = new Size(93, 23);
        left_delete_button.TabIndex = 1;
        left_delete_button.Text = "Delete";
        left_delete_button.UseVisualStyleBackColor = true;
        left_delete_button.Click += Automatic_Delete;
        // 
        // left_new_button
        // 
        left_new_button.Location = new Point(201, 3);
        left_new_button.Name = "left_new_button";
        left_new_button.Size = new Size(89, 23);
        left_new_button.TabIndex = 2;
        left_new_button.Text = "New";
        left_new_button.UseVisualStyleBackColor = true;
        left_new_button.Click += NewAutomaticButtonClick;
        // 
        // right_tablePanel
        // 
        right_tablePanel.ColumnCount = 1;
        right_tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        right_tablePanel.Controls.Add(tableLayoutPanel4, 0, 0);
        right_tablePanel.Controls.Add(dataGridView1, 0, 1);
        right_tablePanel.Location = new Point(471, 3);
        right_tablePanel.Name = "right_tablePanel";
        right_tablePanel.RowCount = 2;
        right_tablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
        right_tablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
        right_tablePanel.Size = new Size(697, 565);
        right_tablePanel.TabIndex = 1;
        // 
        // tableLayoutPanel4
        // 
        tableLayoutPanel4.ColumnCount = 4;
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel4.Controls.Add(right_saveGrenade_button, 3, 3);
        tableLayoutPanel4.Controls.Add(right_type_label, 0, 0);
        tableLayoutPanel4.Controls.Add(right_explosType_label, 0, 1);
        tableLayoutPanel4.Controls.Add(right_blast_radius_label, 0, 2);
        tableLayoutPanel4.Controls.Add(right_info_label, 0, 3);
        tableLayoutPanel4.Controls.Add(right_weight_label, 2, 0);
        tableLayoutPanel4.Controls.Add(right_manufactured_label, 2, 1);
        tableLayoutPanel4.Controls.Add(right_manufacturer_label, 2, 2);
        tableLayoutPanel4.Controls.Add(right_info_input, 1, 3);
        tableLayoutPanel4.Controls.Add(right_type_input, 1, 0);
        tableLayoutPanel4.Controls.Add(right_explosionType_input, 1, 1);
        tableLayoutPanel4.Controls.Add(right_blastRadius_input, 1, 2);
        tableLayoutPanel4.Controls.Add(right_weight_input, 3, 0);
        tableLayoutPanel4.Controls.Add(right_manufacturer_input, 3, 2);
        tableLayoutPanel4.Controls.Add(right_manufactured_input, 3, 1);
        tableLayoutPanel4.Dock = DockStyle.Fill;
        tableLayoutPanel4.Location = new Point(3, 3);
        tableLayoutPanel4.Name = "tableLayoutPanel4";
        tableLayoutPanel4.RowCount = 4;
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 15.7894735F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 15.7894735F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 15.7894735F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 52.63158F));
        tableLayoutPanel4.Size = new Size(691, 248);
        tableLayoutPanel4.TabIndex = 1;
        // 
        // right_saveGrenade_button
        // 
        right_saveGrenade_button.Dock = DockStyle.Fill;
        right_saveGrenade_button.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_saveGrenade_button.Location = new Point(519, 120);
        right_saveGrenade_button.Name = "right_saveGrenade_button";
        right_saveGrenade_button.Size = new Size(169, 125);
        right_saveGrenade_button.TabIndex = 0;
        right_saveGrenade_button.Text = "Save";
        right_saveGrenade_button.UseVisualStyleBackColor = true;
        right_saveGrenade_button.Click += SaveGrenage;
        // 
        // right_type_label
        // 
        right_type_label.AutoSize = true;
        right_type_label.Dock = DockStyle.Fill;
        right_type_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_type_label.ImageAlign = ContentAlignment.MiddleLeft;
        right_type_label.Location = new Point(3, 0);
        right_type_label.Name = "right_type_label";
        right_type_label.Size = new Size(166, 39);
        right_type_label.TabIndex = 1;
        right_type_label.Text = "Type";
        right_type_label.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // right_explosType_label
        // 
        right_explosType_label.AutoSize = true;
        right_explosType_label.Dock = DockStyle.Fill;
        right_explosType_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_explosType_label.ImageAlign = ContentAlignment.MiddleLeft;
        right_explosType_label.Location = new Point(3, 39);
        right_explosType_label.Name = "right_explosType_label";
        right_explosType_label.Size = new Size(166, 39);
        right_explosType_label.TabIndex = 2;
        right_explosType_label.Text = "ExplosionType";
        right_explosType_label.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // right_blast_radius_label
        // 
        right_blast_radius_label.AutoSize = true;
        right_blast_radius_label.Dock = DockStyle.Fill;
        right_blast_radius_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_blast_radius_label.ImageAlign = ContentAlignment.MiddleLeft;
        right_blast_radius_label.Location = new Point(3, 78);
        right_blast_radius_label.Name = "right_blast_radius_label";
        right_blast_radius_label.Size = new Size(166, 39);
        right_blast_radius_label.TabIndex = 3;
        right_blast_radius_label.Text = "BlastRadius";
        right_blast_radius_label.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // right_info_label
        // 
        right_info_label.AutoSize = true;
        right_info_label.Dock = DockStyle.Fill;
        right_info_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_info_label.ImageAlign = ContentAlignment.MiddleLeft;
        right_info_label.Location = new Point(3, 117);
        right_info_label.Name = "right_info_label";
        right_info_label.Size = new Size(166, 131);
        right_info_label.TabIndex = 4;
        right_info_label.Text = "Info";
        right_info_label.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // right_weight_label
        // 
        right_weight_label.AutoSize = true;
        right_weight_label.Dock = DockStyle.Fill;
        right_weight_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_weight_label.ImageAlign = ContentAlignment.MiddleLeft;
        right_weight_label.Location = new Point(347, 0);
        right_weight_label.Name = "right_weight_label";
        right_weight_label.Size = new Size(166, 39);
        right_weight_label.TabIndex = 5;
        right_weight_label.Text = "Weight";
        right_weight_label.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // right_manufactured_label
        // 
        right_manufactured_label.AutoSize = true;
        right_manufactured_label.Dock = DockStyle.Fill;
        right_manufactured_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_manufactured_label.ImageAlign = ContentAlignment.MiddleLeft;
        right_manufactured_label.Location = new Point(347, 39);
        right_manufactured_label.Name = "right_manufactured_label";
        right_manufactured_label.Size = new Size(166, 39);
        right_manufactured_label.TabIndex = 6;
        right_manufactured_label.Text = "Manufactured";
        right_manufactured_label.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // right_manufacturer_label
        // 
        right_manufacturer_label.AutoSize = true;
        right_manufacturer_label.Dock = DockStyle.Fill;
        right_manufacturer_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_manufacturer_label.ImageAlign = ContentAlignment.MiddleLeft;
        right_manufacturer_label.Location = new Point(347, 78);
        right_manufacturer_label.Name = "right_manufacturer_label";
        right_manufacturer_label.Size = new Size(166, 39);
        right_manufacturer_label.TabIndex = 7;
        right_manufacturer_label.Text = "Manufacturer";
        right_manufacturer_label.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // right_info_input
        // 
        right_info_input.Dock = DockStyle.Fill;
        right_info_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_info_input.Location = new Point(175, 120);
        right_info_input.Name = "right_info_input";
        right_info_input.Size = new Size(166, 125);
        right_info_input.TabIndex = 8;
        right_info_input.Text = "";
        // 
        // right_type_input
        // 
        right_type_input.Dock = DockStyle.Fill;
        right_type_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_type_input.Location = new Point(175, 3);
        right_type_input.Name = "right_type_input";
        right_type_input.Size = new Size(166, 29);
        right_type_input.TabIndex = 9;
        // 
        // right_explosionType_input
        // 
        right_explosionType_input.Dock = DockStyle.Fill;
        right_explosionType_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_explosionType_input.FormattingEnabled = true;
        right_explosionType_input.Items.AddRange(new object[] { ExplosionType.Normal, ExplosionType.Grenade, ExplosionType.Missile, ExplosionType.Nuclear, ExplosionType.Mine });
        right_explosionType_input.Location = new Point(175, 42);
        right_explosionType_input.Name = "right_explosionType_input";
        right_explosionType_input.Size = new Size(166, 29);
        right_explosionType_input.TabIndex = 10;
        // 
        // right_blastRadius_input
        // 
        right_blastRadius_input.Dock = DockStyle.Fill;
        right_blastRadius_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_blastRadius_input.Location = new Point(175, 81);
        right_blastRadius_input.Name = "right_blastRadius_input";
        right_blastRadius_input.Size = new Size(166, 29);
        right_blastRadius_input.TabIndex = 11;
        // 
        // right_weight_input
        // 
        right_weight_input.Dock = DockStyle.Fill;
        right_weight_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_weight_input.Location = new Point(519, 3);
        right_weight_input.Name = "right_weight_input";
        right_weight_input.Size = new Size(169, 29);
        right_weight_input.TabIndex = 12;
        // 
        // right_manufacturer_input
        // 
        right_manufacturer_input.Dock = DockStyle.Fill;
        right_manufacturer_input.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_manufacturer_input.Location = new Point(519, 81);
        right_manufacturer_input.Name = "right_manufacturer_input";
        right_manufacturer_input.Size = new Size(169, 29);
        right_manufacturer_input.TabIndex = 14;
        // 
        // right_manufactured_input
        // 
        right_manufactured_input.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        right_manufactured_input.Dock = DockStyle.Fill;
        right_manufactured_input.Location = new Point(519, 42);
        right_manufactured_input.Name = "right_manufactured_input";
        right_manufactured_input.Size = new Size(169, 23);
        right_manufactured_input.TabIndex = 15;
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(3, 257);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowTemplate.Height = 25;
        dataGridView1.Size = new Size(691, 305);
        dataGridView1.TabIndex = 2;
        dataGridView1.CellContentClick += DataGridColRowClick;
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(richTextBox1);
        tabPage2.Location = new Point(4, 26);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(1177, 577);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "RichTextBox";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // richTextBox1
        // 
        richTextBox1.Dock = DockStyle.Fill;
        richTextBox1.Location = new Point(3, 3);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new Size(1171, 571);
        richTextBox1.TabIndex = 0;
        richTextBox1.Text = "";
        // 
        // dataGridViewButtonColumn1
        // 
        dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
        // 
        // deleteGrenade
        // 
        deleteGrenade.Name = "deleteGrenade";
        deleteGrenade.Text = "Delete";
        deleteGrenade.UseColumnTextForButtonValue = true;
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(61, 4);
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(1195, 650);
        Controls.Add(tableLayoutPanel1);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        Name = "MainForm";
        Text = "MainForm";
        Load += MainForm_Load;
        tableLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel1.PerformLayout();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage1.PerformLayout();
        tableLayoutPanel2.ResumeLayout(false);
        tableLayoutPanel2.PerformLayout();
        tableLayoutPanel3.ResumeLayout(false);
        tableLayoutPanel3.PerformLayout();
        flowLayoutPanel2.ResumeLayout(false);
        flowLayoutPanel3.ResumeLayout(false);
        right_tablePanel.ResumeLayout(false);
        tableLayoutPanel4.ResumeLayout(false);
        tableLayoutPanel4.PerformLayout();
        ((ISupportInitialize)dataGridView1).EndInit();
        tabPage2.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private FlowLayoutPanel flowLayoutPanel1;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TableLayoutPanel tableLayoutPanel2;
    private RichTextBox richTextBox1;
    private TableLayoutPanel tableLayoutPanel3;
    private Label left_manufacturer_label;
    private Label left_manufactured_lable;
    private TextBox left_manufacturer_input;
    private DateTimePicker left_manufactured_input;
    private Label left_weight_label;
    private TextBox left_weight_input;
    private Label left_fireRate_label;
    private Label left_fireMode_label;
    private Label left_magazineCap_label;
    private Label left_manufCountry_label;
    private Label left_AmmoCount_label;
    private Label left_Caliber_label;
    private Label left_Range_label;
    private Label left_Accuracy_label;
    private Label left_info_label;
    private TextBox left_firerate_input;
    private ComboBox left_fireMode_input;
    private TextBox left_magCap_input;
    private TextBox left_manufCountry_input;
    private TextBox left_ammoCount_input;
    private TextBox left_caliber_input;
    private TextBox left_range_input;
    private TextBox left_accuracy_input;
    private RichTextBox left_info_input;
    private TableLayoutPanel right_tablePanel;

    private DataGridViewButtonColumn deleteGrenade;
    private DataGridViewButtonColumn dataGridViewButtonColumn1;
    private TableLayoutPanel tableLayoutPanel4;
    private Button right_saveGrenade_button;
    private Label right_type_label;
    private Label right_explosType_label;
    private Label right_blast_radius_label;
    private Label right_info_label;
    private Label right_weight_label;
    private Label right_manufactured_label;
    private Label right_manufacturer_label;
    private RichTextBox right_info_input;
    private TextBox right_type_input;
    private ComboBox right_explosionType_input;
    private TextBox right_blastRadius_input;
    private TextBox right_weight_input;
    private TextBox right_manufacturer_input;
    private DateTimePicker right_manufactured_input;
    private ContextMenuStrip contextMenuStrip1;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem toFileToolStripMenuItem;
    private ToolStripMenuItem automaticToolStripMenuItem;
    private ToolStripMenuItem grenadesToolStripMenuItem;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem toRichTextBoxToolStripMenuItem;
    private ToolStripMenuItem automaticToolStripMenuItem1;
    private ToolStripMenuItem grenadesToolStripMenuItem1;
    private FlowLayoutPanel flowLayoutPanel2;
    private Button left_prev_button;
    private FlowLayoutPanel flowLayoutPanel3;
    private Button left_save_button;
    private Button left_delete_button;
    private Button left_next_button;
    private DataGridView dataGridView1;
    private Button left_new_button;
}