using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace Lab8;
public partial class MainForm : Form
{
    private readonly SqlConnection _connection;

    private bool _isEditingMcMode = false;
    private int _editingMcIndex = -1;
    private IEnumerable<Product>? _products;

    private readonly BindingList<Meal> _meals = new BindingList<Meal>();
    private Meal? _selectedMeal;

    private readonly BindingList<MealComposition> _selectedMealCompositions = new BindingList<MealComposition>();

    public MainForm(SqlConnection connection)
    {
        InitializeComponent();
        _connection = connection;
        mainTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
    }

    private async void selectMealDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        await SetMealCompositionsGrid();
    }

    private async Task SetMealCompositionsGrid()
    {
        _selectedMeal = _meals[selectMealDropdown.SelectedIndex];
        var mealCompositions = await GetMealCompositions(_selectedMeal.MealId);
        _selectedMealCompositions.Clear();
        foreach (var mc in mealCompositions)
        {
            _selectedMealCompositions.Add(mc);
        }
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        selectMealDropdown.DataSource = _meals;
        selectMealDropdown.DisplayMember = nameof(Meal.Name);
        selectMealDropdown.DropDownStyle = ComboBoxStyle.DropDownList;

        var meals = await GetAllMeals();
        foreach (var meal in meals)
        {
            _meals.Add(meal);
        }

        mealCompDataGrid.DataSource = _selectedMealCompositions;
        mealCompDataGrid.Columns[nameof(MealComposition.MealCompositionId)].Visible = false;

        DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
        editButtonColumn.HeaderText = "Edit";
        editButtonColumn.Text = "Edit";
        editButtonColumn.Name = "Edit";
        editButtonColumn.UseColumnTextForButtonValue = true;
        mealCompDataGrid.Columns.Add(editButtonColumn);

        DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
        deleteButtonColumn.HeaderText = "Delete";
        deleteButtonColumn.Text = "Delete";
        deleteButtonColumn.Name = "Delete";
        deleteButtonColumn.UseColumnTextForButtonValue = true;
        mealCompDataGrid.Columns.Add(deleteButtonColumn);

        await SetMealCompositionsGrid();

        _products = await GetAllProduct();
        selectProductDropdown.DataSource = _products;
        selectProductDropdown.DisplayMember = nameof(Product.Name);
        selectProductDropdown.DropDownStyle = ComboBoxStyle.DropDownList;

        tableLayoutPanel9.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
    }
    private async Task<IEnumerable<Meal>> GetAllMeals()
    {
        var meals = new List<Meal>();

        var command = _connection.CreateCommand();
        command.CommandText = "select MealId, Name from Meal";
        var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var mealId = reader.GetInt32(reader.GetOrdinal(nameof(Meal.MealId)));
            var name = reader.GetString(reader.GetOrdinal(nameof(Meal.Name)));

            var meal = new Meal { Name = name, MealId = mealId };
            meals.Add(meal);
        }

        await reader.CloseAsync();
        await command.DisposeAsync();

        return meals;
    }

    private async Task<IEnumerable<MealComposition>> GetMealCompositions(int id)
    {
        var mealCompositions = new List<MealComposition>();

        var command = _connection.CreateCommand();
        command.CommandText = $"""
                    select mc.MealCompositionId, p.Name, mc.Count, mc.Measure from MealComposition as mc
                    join Product as p on mc.ProductId = p.ProductId
                    where MealId = {id}
            """;

        var parameter = new SqlParameter();
        parameter.ParameterName = "@mealId";
        parameter.Value = id;

        command.Parameters.Add(parameter);

        var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var mealCompId = reader.GetInt32(reader.GetOrdinal(nameof(MealComposition.MealCompositionId)));
            var name = reader.GetString(reader.GetOrdinal(nameof(MealComposition.Name)));
            var count = reader.GetFieldValue<double>(reader.GetOrdinal(nameof(MealComposition.Count)));
            var measure = reader.GetString(reader.GetOrdinal(nameof(MealComposition.Measure)));

            var mealComposition = new MealComposition
            {
                MealCompositionId = mealCompId,
                Name = name,
                Count = count,
                Measure = measure
            };

            mealCompositions.Add(mealComposition);
        }

        await reader.CloseAsync();
        await command.DisposeAsync();

        return mealCompositions;
    }

    private async Task<IEnumerable<Product>> GetAllProduct()
    {
        var products = new List<Product>();

        var command = _connection.CreateCommand();
        command.CommandText = "select ProductId, Name from Product";

        var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var productId = reader.GetInt32(reader.GetOrdinal(nameof(Product.ProductId)));
            var name = reader.GetString(reader.GetOrdinal(nameof(Product.Name)));

            var product = new Product { ProductId = productId, Name = name };
            products.Add(product);
        }

        await reader.CloseAsync();
        await command.DisposeAsync();

        return products;
    }

    private async void newMcSaveButton_Click(object sender, EventArgs e)
    {
        var product = _products.ElementAt(selectProductDropdown.SelectedIndex);
        var mealId = _selectedMeal?.MealId;

        var countText = int.TryParse(newMcCountInput.Text.Trim(), out int newCount);
        var measure = newMcMeasureInput.Text.Trim();

        if (mealId is null || product is null || !countText) return;

        await using var tran = _connection.BeginTransaction();
        try
        {
            if (!_isEditingMcMode)
            {
                var suchProductInMealCountCommand = _connection.CreateCommand();
                suchProductInMealCountCommand.CommandText = $"""
                    select count(*) as ProductCount from Product as p
                    join MealComposition as mc on p.ProductId = mc.ProductId
                    where mc.MealId = {mealId} and p.ProductId = {product.ProductId} and lower(Measure) like '{measure.ToLowerInvariant()}'
                """;

                suchProductInMealCountCommand.Transaction = tran;

                var suchProductInMealCountReader = await suchProductInMealCountCommand.ExecuteReaderAsync();
                if (suchProductInMealCountReader.HasRows)
                {
                    int count = -1;
                    while (await suchProductInMealCountReader.ReadAsync())
                    {
                        count = suchProductInMealCountReader.GetInt32(suchProductInMealCountReader.GetOrdinal("ProductCount"));
                        break;
                    }
                    await suchProductInMealCountReader.CloseAsync();
                    await suchProductInMealCountCommand.DisposeAsync();

                    if (count > 0)
                    {
                        var mealCompositionIdCommand = _connection.CreateCommand();
                        mealCompositionIdCommand.CommandText = $"""
                            select MealCompositionId from MealComposition
                            where MealId = {mealId} and ProductId = {product.ProductId}
                        """;

                        mealCompositionIdCommand.Transaction = tran;

                        var mealCompositionIdReader = await mealCompositionIdCommand.ExecuteReaderAsync();

                        if (mealCompositionIdReader.HasRows)
                        {
                            var mealCompositionId = -1;
                            while (await mealCompositionIdReader.ReadAsync())
                            {
                                mealCompositionId = mealCompositionIdReader.GetInt32(mealCompositionIdReader.GetOrdinal(nameof(MealComposition.MealCompositionId)));
                                break;
                            }

                            await mealCompositionIdReader.CloseAsync();
                            await mealCompositionIdCommand.DisposeAsync();

                            var updateMealCompositionCommand = _connection.CreateCommand();
                            updateMealCompositionCommand.CommandText = $"""
                                update MealComposition
                                set Count = Count + {newCount}
                                where MealId = {mealId} and ProductId = {product.ProductId} and lower(Measure) like '{measure.ToLowerInvariant()}'
                            """;

                            updateMealCompositionCommand.Transaction = tran;

                            await updateMealCompositionCommand.ExecuteNonQueryAsync();

                            await updateMealCompositionCommand.DisposeAsync();
                        }
                    }
                    else
                    {
                        var lastIndexMCCommand = _connection.CreateCommand();
                        lastIndexMCCommand.CommandText = "select max(MealCompositionId) as MaxIndex from MealComposition";

                        lastIndexMCCommand.Transaction = tran;

                        var lastIndexMCCommandReader = await lastIndexMCCommand.ExecuteReaderAsync();
                        var index = -1;
                        if (lastIndexMCCommandReader.HasRows)
                        {
                            while (await lastIndexMCCommandReader.ReadAsync())
                            {
                                index = lastIndexMCCommandReader.GetInt32(lastIndexMCCommandReader.GetOrdinal("MaxIndex"));
                                break;
                            }
                        }
                        else index = 1;

                        await lastIndexMCCommandReader.CloseAsync();
                        await lastIndexMCCommand.DisposeAsync();

                        var addMeasureCompositionCommand = _connection.CreateCommand();
                        addMeasureCompositionCommand.CommandText = $"""
                            insert into MealComposition (MealCompositionId, MealId, ProductId, Count, Measure) 
                            values ({index + 1},{mealId},{product.ProductId},{newCount},'{measure}')
                        """;

                        addMeasureCompositionCommand.Transaction = tran;

                        await addMeasureCompositionCommand.ExecuteNonQueryAsync();
                    }
                }
            }
            else if (_isEditingMcMode && _editingMcIndex != -1)
            {
                var mealComposition = _selectedMealCompositions[_editingMcIndex];
                var updateMealCompositionCommand = _connection.CreateCommand();
                updateMealCompositionCommand.CommandText = "UpdateMealComposition";
                updateMealCompositionCommand.Transaction = tran;
                updateMealCompositionCommand.CommandType = CommandType.StoredProcedure;

                updateMealCompositionCommand.Parameters.AddWithValue("@id", mealComposition.MealCompositionId);
                updateMealCompositionCommand.Parameters.AddWithValue("@productId", product.ProductId);
                updateMealCompositionCommand.Parameters.AddWithValue("@count", newCount);
                updateMealCompositionCommand.Parameters.AddWithValue("@measure", measure);

                await updateMealCompositionCommand.ExecuteNonQueryAsync();
            }

            await tran.CommitAsync();
            await SetMealCompositionsGrid();
        }
        catch
        {
            await tran.RollbackAsync();
        }
        finally
        {
            ClearNewMcForm();
            _isEditingMcMode = false;
            _editingMcIndex = -1;
        }
    }

    private void ClearNewMcForm()
    {
        newMcCountInput.Clear();
        newMcMeasureInput.Clear();
    }

    private async void mealCompDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == mealCompDataGrid.Columns["Edit"].Index)
        {
            _isEditingMcMode = true;
            _editingMcIndex = e.RowIndex;
            var mc = _selectedMealCompositions[_editingMcIndex];
            newMcCountInput.Text = mc.Count.ToString();
            newMcMeasureInput.Text = mc.Measure;
            selectProductDropdown.SelectedIndex = _products.ToList().FindIndex(p => p.Name.Equals(mc.Name, StringComparison.InvariantCultureIgnoreCase));
        }
        else if (e.ColumnIndex == mealCompDataGrid.Columns["Delete"].Index)
        {
            try
            {
                var deleteMcStoreProcCommand = _connection.CreateCommand();
                deleteMcStoreProcCommand.CommandType = CommandType.StoredProcedure;
                deleteMcStoreProcCommand.CommandText = "RemoveMealComposition";

                deleteMcStoreProcCommand.Parameters.AddWithValue("@id", _selectedMealCompositions[e.RowIndex].MealCompositionId);

                await deleteMcStoreProcCommand.ExecuteNonQueryAsync();
                await SetMealCompositionsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


    // Передбачити отримання інформації про кількість рахунків по стравам отриманих у день якщо їх було більше двох
    private async void BillsMore2Button_Click_1(object sender, EventArgs e)
    {
        var date = billsMore2DatePicker.Value.ToString("yyyy-MM-dd");
        var command = _connection.CreateCommand();
        command.CommandText = $"""
                    select [Date], count(*) as Number from Bill
                    where [Date] = '{date}'
                    group by [Date]
                    having count(*) > 2
            """;

        var reader = await command.ExecuteReaderAsync();
        if (reader.HasRows)
        {
            while (await reader.ReadAsync())
            {
                var numberOfBills = reader.GetInt32(reader.GetOrdinal("Number"));
                MessageBox.Show($"{date}: {numberOfBills} bills");
            }
        }
        else
        {
            MessageBox.Show($"{date}: 0 bills");
        }

        await reader.CloseAsync();
        await command.DisposeAsync();
    }
}
