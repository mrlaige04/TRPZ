namespace Lab8;

partial class MainForm
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
        mainTable = new TableLayoutPanel();
        tableLayoutPanel2 = new TableLayoutPanel();
        tableLayoutPanel1 = new TableLayoutPanel();
        label2 = new Label();
        tableLayoutPanel5 = new TableLayoutPanel();
        label3 = new Label();
        selectProductDropdown = new ComboBox();
        tableLayoutPanel7 = new TableLayoutPanel();
        label4 = new Label();
        newMcCountInput = new TextBox();
        tableLayoutPanel8 = new TableLayoutPanel();
        label5 = new Label();
        newMcMeasureInput = new TextBox();
        newMcSaveButton = new Button();
        tableLayoutPanel9 = new TableLayoutPanel();
        tableLayoutPanel10 = new TableLayoutPanel();
        BillsMore2Button = new Button();
        billsMore2DatePicker = new DateTimePicker();
        tableLayoutPanel3 = new TableLayoutPanel();
        tableLayoutPanel4 = new TableLayoutPanel();
        selectMealDropdown = new ComboBox();
        label1 = new Label();
        mealCompDataGrid = new DataGridView();
        tableLayoutPanel6 = new TableLayoutPanel();
        mainTable.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        tableLayoutPanel5.SuspendLayout();
        tableLayoutPanel7.SuspendLayout();
        tableLayoutPanel8.SuspendLayout();
        tableLayoutPanel9.SuspendLayout();
        tableLayoutPanel10.SuspendLayout();
        tableLayoutPanel3.SuspendLayout();
        tableLayoutPanel4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)mealCompDataGrid).BeginInit();
        SuspendLayout();
        // 
        // mainTable
        // 
        mainTable.ColumnCount = 2;
        mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        mainTable.Controls.Add(tableLayoutPanel2, 1, 0);
        mainTable.Controls.Add(tableLayoutPanel3, 0, 0);
        mainTable.Dock = DockStyle.Fill;
        mainTable.Location = new Point(0, 0);
        mainTable.Name = "mainTable";
        mainTable.RowCount = 1;
        mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainTable.Size = new Size(800, 450);
        mainTable.TabIndex = 0;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 1;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 0);
        tableLayoutPanel2.Controls.Add(tableLayoutPanel9, 0, 1);
        tableLayoutPanel2.Dock = DockStyle.Fill;
        tableLayoutPanel2.Location = new Point(523, 3);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 2;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
        tableLayoutPanel2.Size = new Size(274, 444);
        tableLayoutPanel2.TabIndex = 0;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Controls.Add(label2, 0, 0);
        tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 1);
        tableLayoutPanel1.Controls.Add(tableLayoutPanel7, 0, 2);
        tableLayoutPanel1.Controls.Add(tableLayoutPanel8, 0, 3);
        tableLayoutPanel1.Controls.Add(newMcSaveButton, 0, 4);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(3, 3);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 5;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.Size = new Size(268, 171);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Dock = DockStyle.Fill;
        label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        label2.Location = new Point(3, 0);
        label2.Name = "label2";
        label2.Size = new Size(262, 34);
        label2.TabIndex = 0;
        label2.Text = "Add new";
        label2.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tableLayoutPanel5
        // 
        tableLayoutPanel5.ColumnCount = 2;
        tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        tableLayoutPanel5.Controls.Add(label3, 0, 0);
        tableLayoutPanel5.Controls.Add(selectProductDropdown, 1, 0);
        tableLayoutPanel5.Dock = DockStyle.Fill;
        tableLayoutPanel5.Location = new Point(3, 37);
        tableLayoutPanel5.Name = "tableLayoutPanel5";
        tableLayoutPanel5.RowCount = 1;
        tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel5.Size = new Size(262, 28);
        tableLayoutPanel5.TabIndex = 1;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Dock = DockStyle.Fill;
        label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        label3.Location = new Point(3, 0);
        label3.Name = "label3";
        label3.Size = new Size(98, 28);
        label3.TabIndex = 0;
        label3.Text = "Product";
        label3.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // selectProductDropdown
        // 
        selectProductDropdown.Dock = DockStyle.Fill;
        selectProductDropdown.FormattingEnabled = true;
        selectProductDropdown.Location = new Point(107, 3);
        selectProductDropdown.Name = "selectProductDropdown";
        selectProductDropdown.Size = new Size(152, 23);
        selectProductDropdown.TabIndex = 1;
        // 
        // tableLayoutPanel7
        // 
        tableLayoutPanel7.ColumnCount = 2;
        tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        tableLayoutPanel7.Controls.Add(label4, 0, 0);
        tableLayoutPanel7.Controls.Add(newMcCountInput, 1, 0);
        tableLayoutPanel7.Dock = DockStyle.Fill;
        tableLayoutPanel7.Location = new Point(3, 71);
        tableLayoutPanel7.Name = "tableLayoutPanel7";
        tableLayoutPanel7.RowCount = 1;
        tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel7.Size = new Size(262, 28);
        tableLayoutPanel7.TabIndex = 2;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Dock = DockStyle.Fill;
        label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        label4.Location = new Point(3, 0);
        label4.Name = "label4";
        label4.Size = new Size(98, 28);
        label4.TabIndex = 0;
        label4.Text = "Count";
        label4.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // newMcCountInput
        // 
        newMcCountInput.Dock = DockStyle.Fill;
        newMcCountInput.Location = new Point(107, 3);
        newMcCountInput.Name = "newMcCountInput";
        newMcCountInput.Size = new Size(152, 23);
        newMcCountInput.TabIndex = 1;
        // 
        // tableLayoutPanel8
        // 
        tableLayoutPanel8.ColumnCount = 2;
        tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        tableLayoutPanel8.Controls.Add(label5, 0, 0);
        tableLayoutPanel8.Controls.Add(newMcMeasureInput, 1, 0);
        tableLayoutPanel8.Dock = DockStyle.Fill;
        tableLayoutPanel8.Location = new Point(3, 105);
        tableLayoutPanel8.Name = "tableLayoutPanel8";
        tableLayoutPanel8.RowCount = 1;
        tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel8.Size = new Size(262, 28);
        tableLayoutPanel8.TabIndex = 3;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Dock = DockStyle.Fill;
        label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        label5.Location = new Point(3, 0);
        label5.Name = "label5";
        label5.Size = new Size(98, 28);
        label5.TabIndex = 0;
        label5.Text = "Measure";
        label5.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // newMcMeasureInput
        // 
        newMcMeasureInput.Dock = DockStyle.Fill;
        newMcMeasureInput.Location = new Point(107, 3);
        newMcMeasureInput.Name = "newMcMeasureInput";
        newMcMeasureInput.Size = new Size(152, 23);
        newMcMeasureInput.TabIndex = 1;
        // 
        // newMcSaveButton
        // 
        newMcSaveButton.Dock = DockStyle.Fill;
        newMcSaveButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        newMcSaveButton.Location = new Point(3, 139);
        newMcSaveButton.Name = "newMcSaveButton";
        newMcSaveButton.Size = new Size(262, 29);
        newMcSaveButton.TabIndex = 4;
        newMcSaveButton.Text = "Save";
        newMcSaveButton.UseVisualStyleBackColor = true;
        newMcSaveButton.Click += newMcSaveButton_Click;
        // 
        // tableLayoutPanel9
        // 
        tableLayoutPanel9.ColumnCount = 1;
        tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel9.Controls.Add(tableLayoutPanel10, 0, 0);
        tableLayoutPanel9.Dock = DockStyle.Fill;
        tableLayoutPanel9.Location = new Point(3, 180);
        tableLayoutPanel9.Name = "tableLayoutPanel9";
        tableLayoutPanel9.RowCount = 2;
        tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 14.5593872F));
        tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 85.44061F));
        tableLayoutPanel9.Size = new Size(268, 261);
        tableLayoutPanel9.TabIndex = 1;
        // 
        // tableLayoutPanel10
        // 
        tableLayoutPanel10.ColumnCount = 2;
        tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel10.Controls.Add(BillsMore2Button, 1, 0);
        tableLayoutPanel10.Controls.Add(billsMore2DatePicker, 0, 0);
        tableLayoutPanel10.Dock = DockStyle.Fill;
        tableLayoutPanel10.Location = new Point(3, 3);
        tableLayoutPanel10.Name = "tableLayoutPanel10";
        tableLayoutPanel10.RowCount = 1;
        tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel10.Size = new Size(262, 32);
        tableLayoutPanel10.TabIndex = 0;
        // 
        // BillsMore2Button
        // 
        BillsMore2Button.Dock = DockStyle.Fill;
        BillsMore2Button.Location = new Point(134, 3);
        BillsMore2Button.Name = "BillsMore2Button";
        BillsMore2Button.Size = new Size(125, 26);
        BillsMore2Button.TabIndex = 0;
        BillsMore2Button.Text = "Get bills";
        BillsMore2Button.UseVisualStyleBackColor = true;
        BillsMore2Button.Click += BillsMore2Button_Click_1;
        // 
        // billsMore2DatePicker
        // 
        billsMore2DatePicker.Location = new Point(3, 3);
        billsMore2DatePicker.Name = "billsMore2DatePicker";
        billsMore2DatePicker.Size = new Size(125, 23);
        billsMore2DatePicker.TabIndex = 1;
        // 
        // tableLayoutPanel3
        // 
        tableLayoutPanel3.ColumnCount = 1;
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
        tableLayoutPanel3.Controls.Add(mealCompDataGrid, 0, 1);
        tableLayoutPanel3.Dock = DockStyle.Fill;
        tableLayoutPanel3.Location = new Point(3, 3);
        tableLayoutPanel3.Name = "tableLayoutPanel3";
        tableLayoutPanel3.RowCount = 2;
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
        tableLayoutPanel3.Size = new Size(514, 444);
        tableLayoutPanel3.TabIndex = 1;
        // 
        // tableLayoutPanel4
        // 
        tableLayoutPanel4.ColumnCount = 2;
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        tableLayoutPanel4.Controls.Add(selectMealDropdown, 1, 0);
        tableLayoutPanel4.Controls.Add(label1, 0, 0);
        tableLayoutPanel4.Dock = DockStyle.Fill;
        tableLayoutPanel4.Location = new Point(3, 3);
        tableLayoutPanel4.Name = "tableLayoutPanel4";
        tableLayoutPanel4.RowCount = 1;
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel4.Size = new Size(508, 38);
        tableLayoutPanel4.TabIndex = 0;
        // 
        // selectMealDropdown
        // 
        selectMealDropdown.Dock = DockStyle.Fill;
        selectMealDropdown.FormattingEnabled = true;
        selectMealDropdown.Location = new Point(180, 3);
        selectMealDropdown.Name = "selectMealDropdown";
        selectMealDropdown.Size = new Size(325, 23);
        selectMealDropdown.TabIndex = 0;
        selectMealDropdown.SelectedIndexChanged += selectMealDropdown_SelectedIndexChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Dock = DockStyle.Fill;
        label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        label1.Location = new Point(3, 0);
        label1.Name = "label1";
        label1.Size = new Size(171, 38);
        label1.TabIndex = 1;
        label1.Text = "Select Meal";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // mealCompDataGrid
        // 
        mealCompDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        mealCompDataGrid.Dock = DockStyle.Fill;
        mealCompDataGrid.Location = new Point(3, 47);
        mealCompDataGrid.Name = "mealCompDataGrid";
        mealCompDataGrid.RowTemplate.Height = 25;
        mealCompDataGrid.Size = new Size(508, 394);
        mealCompDataGrid.TabIndex = 1;
        mealCompDataGrid.CellContentClick += mealCompDataGrid_CellContentClick;
        // 
        // tableLayoutPanel6
        // 
        tableLayoutPanel6.ColumnCount = 2;
        tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
        tableLayoutPanel6.Dock = DockStyle.Fill;
        tableLayoutPanel6.Location = new Point(0, 0);
        tableLayoutPanel6.Name = "tableLayoutPanel6";
        tableLayoutPanel6.RowCount = 1;
        tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel6.Size = new Size(200, 100);
        tableLayoutPanel6.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(mainTable);
        Name = "MainForm";
        Text = "MainForm";
        Load += MainForm_Load;
        mainTable.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        tableLayoutPanel5.ResumeLayout(false);
        tableLayoutPanel5.PerformLayout();
        tableLayoutPanel7.ResumeLayout(false);
        tableLayoutPanel7.PerformLayout();
        tableLayoutPanel8.ResumeLayout(false);
        tableLayoutPanel8.PerformLayout();
        tableLayoutPanel9.ResumeLayout(false);
        tableLayoutPanel10.ResumeLayout(false);
        tableLayoutPanel3.ResumeLayout(false);
        tableLayoutPanel4.ResumeLayout(false);
        tableLayoutPanel4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)mealCompDataGrid).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel mainTable;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private TableLayoutPanel tableLayoutPanel4;
    private ComboBox selectMealDropdown;
    private Label label1;
    private DataGridView mealCompDataGrid;
    private TableLayoutPanel tableLayoutPanel1;
    private Label label2;
    private TableLayoutPanel tableLayoutPanel5;
    private Label label3;
    private ComboBox selectProductDropdown;
    private TableLayoutPanel tableLayoutPanel7;
    private Label label4;
    private TextBox newMcCountInput;
    private TableLayoutPanel tableLayoutPanel8;
    private Label label5;
    private TextBox newMcMeasureInput;
    private Button newMcSaveButton;
    private TableLayoutPanel tableLayoutPanel6;
    private TableLayoutPanel tableLayoutPanel9;
    private TableLayoutPanel tableLayoutPanel10;
    private Button BillsMore2Button;
    private DateTimePicker billsMore2DatePicker;
}