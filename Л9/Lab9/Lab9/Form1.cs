using Lab9.Models;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Lab9;

public partial class Form1 : Form
{
    private readonly SqlConnection _connection;
    private SqlDataAdapter _pages_adapter;
    private SqlDataAdapter _fullWork_adapter;
    private readonly DataSet _ds;

    private int pages_pageSize = 10;
    private int pages_pageNumber = 1;

    public Form1(SqlConnection connection)
    {
        InitializeComponent();
        _connection = connection;

        pageDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        pageDataGrid.AllowUserToAddRows = false;
        pageDataGrid.ReadOnly = true;

        _pages_adapter = new SqlDataAdapter(Pages_GetSql(), connection);

        _ds = new DataSet();

        _pages_adapter.Fill(_ds);

        pageDataGrid.DataSource = _ds.Tables[0];
    }

    private string Pages_GetSql()
    {
        return $"""
            select * from MealComposition
            order by CURRENT_TIMESTAMP
            offset {(pages_pageNumber - 1) * pages_pageSize} rows
            fetch next {pages_pageSize} rows only
            """;
    }

    private void pages_leftButton_Click(object sender, EventArgs e)
    {
        if (pages_pageNumber == 1) return;
        pages_pageNumber--;


        _pages_adapter = new SqlDataAdapter(Pages_GetSql(), _connection);

        _ds.Tables[0].Rows.Clear();
        _pages_adapter.Fill(_ds);
    }

    private void pages_rightButton_Click(object sender, EventArgs e)
    {
        if (_ds.Tables[0].Rows.Count < pages_pageSize) return;
        pages_pageNumber++;

        _pages_adapter = new SqlDataAdapter(Pages_GetSql(), _connection);

        _ds.Tables[0].Rows.Clear();
        _pages_adapter.Fill(_ds);
    }

    private void pages_addRowOne_Click(object sender, EventArgs e)
    {
        _pages_adapter.SelectCommand = new SqlCommand(Pages_GetSql(), _connection);

        var lastIdCmd = _connection.CreateCommand();
        lastIdCmd.CommandText = """
                select top(1) MealCompositionId from MealComposition
                order by MealCompositionId desc
            """;



        var newRow = _ds.Tables[0].NewRow();
        newRow["MealCompositionId"] = Random.Shared.Next(100, 200);
        newRow["ProductId"] = 1;
        newRow["MealId"] = 5;
        newRow["Count"] = 5;
        newRow["Measure"] = "Test";

        _ds.Tables[0].Rows.Add(newRow);

        var cmdBuilder = new SqlCommandBuilder(_pages_adapter);
        _pages_adapter.Update(_ds.Tables[0]);

        _ds.Tables[0].Clear();
        _pages_adapter.Fill(_ds.Tables[0]);
    }

    private void pages_addRowProc_Click(object sender, EventArgs e)
    {
        _pages_adapter.SelectCommand = new SqlCommand(Pages_GetSql(), _connection);
        _pages_adapter.InsertCommand = new SqlCommand("AddMealComposition", _connection);

        _pages_adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
        var newId = Random.Shared.Next();

        _pages_adapter.InsertCommand.Parameters.Add(new SqlParameter("@MealCompositionId", SqlDbType.Int, 0, "MealCompositionId"));
        _pages_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int, 0, "ProductId"));
        _pages_adapter.InsertCommand.Parameters.Add(new SqlParameter("@MealId", SqlDbType.Int, 0, "MealId"));
        _pages_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Count", SqlDbType.Float, 0, "Count"));
        _pages_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Measure", SqlDbType.NVarChar, 50, "Measure"));



        var newRow = _ds.Tables[0].NewRow();
        newRow["MealCompositionId"] = newId;
        newRow["ProductId"] = 2;
        newRow["MealId"] = 2;
        newRow["Count"] = 30;
        newRow["Measure"] = "sdfsd";
        _ds.Tables[0].Rows.Add(newRow);

        _pages_adapter.Update(_ds.Tables[0]);
        _ds.Tables[0].AcceptChanges();
    }

    private string FullWork_GetSql()
    {
        return "select * from MealComposition";
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {
        var fullWorkSql = FullWork_GetSql();

        fullWorkDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        fullWorkDataGrid.AllowUserToAddRows = false;

        _fullWork_adapter = new SqlDataAdapter(fullWorkSql, _connection);
        _fullWork_adapter.Fill(_ds, "MealCompositions");
        fullWorkDataGrid.DataSource = _ds.Tables[1];
        fullWorkDataGrid.Columns["MealCompositionId"].ReadOnly = true;

        fullWork_IdTextBox.Enabled = false;
        fullWork_IdTextBox.DataBindings.Add("Text", _ds.Tables[1], "MealCompositionId");
        fullWork_MealIdTextBox.DataBindings.Add("Text", _ds.Tables[1], "MealId");
        fullWork_ProductIdTextBox.DataBindings.Add("Text", _ds.Tables[1], "ProductId");
        fullWork_CountTextBox.DataBindings.Add("Text", _ds.Tables[1], "Count");
        fullWork_MeasureTextBox.DataBindings.Add("Text", _ds.Tables[1], "Measure");


    }

    private void fullWorkSaveButton_Click(object sender, EventArgs e)
    {
        BindingContext[_ds, "MealCompositions"].EndCurrentEdit();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        using var dbContext = new Restaurant2Context();
        var query = from employee in dbContext.Employees
                    join bill in dbContext.Bills on employee.EmployeeId equals bill.EmployeeId
                    join position in dbContext.Positions on employee.PositionId equals position.PositionId
                    group new { employee, bill, position } by new { employee.FirstName, employee.LastName, position.Name } into g
                    select new
                    {
                        FullName = g.Key.FirstName + " " + g.Key.LastName,
                        AverageBillAmount = g.Average(x => x.bill.Sum),
                        PositionName = g.Key.Name,
                        AverageBillAmountByPosition = g.Average(x => x.bill.Sum)
                    };

        var result = query.Where(x => x.AverageBillAmount > x.AverageBillAmountByPosition);

        linqDataGrid.DataSource = result.ToList();
    }
}
