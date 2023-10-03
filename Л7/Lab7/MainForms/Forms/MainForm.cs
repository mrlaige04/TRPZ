using ClassLibrary.Enums;
using ClassLibrary.Models;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text;

namespace MainForms.Forms;
public partial class MainForm : Form
{
    private bool _right_isEditMode = false;
    private int _right_editingIndex = -1;

    private bool _left_isEditMode = false;
    private int _left_editingIndex = -1;
    private BindingList<Grenade> grenadeList { get; set; } = new BindingList<Grenade>();
    private List<Automatic> automaticList { get; set; } = new List<Automatic>();

    public MainForm()
    {
        InitializeComponent();
    }

    private void DataGridColumnRowClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            if (e.ColumnIndex == 0) // Edit
            {
                var grenade = grenadeList[e.RowIndex];
                SetGrenadeFormValue(grenade);
                _right_isEditMode = true;
                _right_editingIndex = e.RowIndex;
            }
            else if (e.ColumnIndex == 1) // Remove
            {
                grenadeList.RemoveAt(e.RowIndex);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void SetGrenadeFormValue(Grenade grenade)
    {
        try
        {
            right_type_input.Text = grenade.Type;
            right_explosionType_input.Text = grenade.ExplosionType.ToString();
            right_blastRadius_input.Text = grenade.BlastRadius.ToString();
            right_info_input.Text = grenade.Info;
            right_weight_input.Text = grenade.Weight.ToString();
            right_manufactured_input.Value = grenade.Manufactured;
            right_manufacturer_input.Text = grenade.Manufacturer;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    private Grenade? GetRightGrenade()
    {
        try
        {
            var type = right_type_input.Text.Trim();
            var explosionType = Enum.Parse<ExplosionType>(right_explosionType_input.Text.Trim());
            var blastRadiues = int.Parse(right_blastRadius_input.Text.Trim());
            var info = right_info_input.Text.Trim();
            var weight = int.Parse(right_weight_input.Text.Trim());
            var manufactured = right_manufactured_input.Value;
            var manufacturer = right_manufacturer_input.Text.Trim();

            var grenade = new Grenade(info, weight, manufacturer, manufactured, type, explosionType, blastRadiues);
            return grenade;
        }
        catch
        {
            MessageBox.Show("TextBoxes have wrong values");
            return null;
        }
    }

    private Automatic? GetLeftAutomatic()
    {
        try
        {
            var manufactured = left_manufactured_input.Value;
            var manufacturer = left_manufacturer_input.Text;
            var weight = int.Parse(left_weight_input.Text);
            var fireRate = int.Parse(left_firerate_input.Text);
            var fireMode = Enum.Parse<FireMode>(left_fireMode_input.Text);
            var magazineCapacity = int.Parse(left_magCap_input.Text);
            var manufactureCountry = left_manufCountry_input.Text;
            var ammoCount = int.Parse(left_ammoCount_input.Text);
            var caliber = left_caliber_input.Text;
            var range = int.Parse(left_range_input.Text);
            var accuracy = int.Parse(left_accuracy_input.Text);
            var info = left_info_input.Text;

            var automatic = new Automatic(info, weight, manufacturer, manufactured, ammoCount, caliber, range, accuracy, fireRate, fireMode, magazineCapacity, manufactureCountry);
            return automatic;
        }
        catch
        {
            MessageBox.Show("TextBoxes have wrong values");
            return null;
        }
    }

    private void SaveGrenage(object sender, EventArgs e)
    {
        try
        {
            var grenade = GetRightGrenade();

            if (grenade != null)
            {
                if (!_right_isEditMode)
                    grenadeList.Add(grenade);
                else
                {
                    if (_right_editingIndex != -1)
                        grenadeList[_right_editingIndex] = grenade;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            ClearRightForm();
        }
    }

    #region Export
    private void AutomaticToRichTextBox(object sender, EventArgs e)
    {
        tabControl1.SelectedIndex = 1;
        var result = new StringBuilder();
        automaticList.ForEach(item => result.Append(item.ToString()).Append("\n"));
        richTextBox1.Text = result.ToString();
    }

    private void GrenadesToRichTextBox(object sender, EventArgs e)
    {
        tabControl1.SelectedIndex = 1;
        var result = new StringBuilder();
        grenadeList.ToList().ForEach(item => result.Append(item.ToString()).Append("\n"));
        richTextBox1.Text = result.ToString();
    }

    private void AutomaticToFile(object sender, EventArgs e)
    {
        var json = JsonConvert.SerializeObject(automaticList);

        using SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "JSON файли (*.json)|*.json|Всі файли (*.*)|*.*";
        saveFileDialog.FilterIndex = 1;
        saveFileDialog.RestoreDirectory = true;

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = saveFileDialog.FileName;
            File.WriteAllText(filePath, json);
        }
    }

    private void GrenadesToFile(object sender, EventArgs e)
    {
        var json = JsonConvert.SerializeObject(grenadeList.ToList());

        using SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "JSON файли (*.json)|*.json|Всі файли (*.*)|*.*";
        saveFileDialog.FilterIndex = 1;
        saveFileDialog.RestoreDirectory = true;

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = saveFileDialog.FileName;
            File.WriteAllText(filePath, json);
        }
    }
    #endregion

    private void AutomaticPrev(object sender, EventArgs e)
    {
        _left_isEditMode = true;
        _left_editingIndex--;
        if (_left_editingIndex < 0) _left_editingIndex = 0;
        UpdateAutomatic();
    }

    private void AutomaticNext(object sender, EventArgs e)
    {
        _left_isEditMode = true;
        _left_editingIndex++;
        if (_left_editingIndex >= automaticList.Count) _left_editingIndex = automaticList.Count - 1;
        UpdateAutomatic();
    }

    private void UpdateAutomatic()
    {
        try
        {
            var automatic = automaticList[_left_editingIndex];
            left_manufactured_input.Value = automatic.Manufactured;
            left_manufacturer_input.Text = automatic.Manufacturer;
            left_weight_input.Text = automatic.Weight.ToString();
            left_firerate_input.Text = automatic.FireRate.ToString();
            left_fireMode_input.Text = automatic.FireMode.ToString();
            left_magCap_input.Text = automatic.MagazineCapacity.ToString();
            left_manufCountry_input.Text = automatic.ManufacturerCountry;
            left_ammoCount_input.Text = automatic.AmmoCount.ToString();
            left_caliber_input.Text = automatic.Caliber;
            left_range_input.Text = automatic.Range.ToString();
            left_accuracy_input.Text = automatic.Accuracy.ToString();
            left_info_input.Text = automatic.Info;
        }
        catch { }
    }

    private void ClearLeftForm()
    {
        left_manufacturer_input.Text = string.Empty;
        left_weight_input.Text = string.Empty;
        left_firerate_input.Text = string.Empty;
        left_fireMode_input.Text = string.Empty;
        left_magCap_input.Text = string.Empty;
        left_manufCountry_input.Text = string.Empty;
        left_ammoCount_input.Text = string.Empty;
        left_caliber_input.Text = string.Empty;
        left_range_input.Text = string.Empty;
        left_accuracy_input.Text = string.Empty;
        left_info_input.Text = string.Empty;
    }

    private void ClearRightForm()
    {
        right_type_input.Clear();
        right_explosionType_input.SelectedIndex = 0;
        right_blastRadius_input.Clear();
        right_info_input.Clear();
        right_weight_input.Clear();
        right_manufacturer_input.Clear();

        _right_isEditMode = false;
        _right_editingIndex = -1;
    }

    private void SaveAutomatic(object sender, EventArgs e)
    {
        try
        {
            var automatic = GetLeftAutomatic();
            if (_left_isEditMode)
            {
                if (automatic is not null) automaticList[_left_editingIndex] = automatic;
            }
            else
            {
                if (automatic is not null) automaticList.Add(automatic);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            _left_isEditMode = false;
            _left_editingIndex = -1;
            ClearLeftForm();
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        dataGridView1.DataSource = grenadeList;
        var editButtonColumn = new DataGridViewButtonColumn
        {
            HeaderText = "Edit",
            Text = "Edit",
            Name = "Edit",
            UseColumnTextForButtonValue = true
        };
        dataGridView1.Columns.Add(editButtonColumn);

        var deleteButtonColumn = new DataGridViewButtonColumn
        {
            HeaderText = "Delete",
            Text = "Delete",
            Name = "Delete",
            UseColumnTextForButtonValue = true
        };
        dataGridView1.Columns.Add(deleteButtonColumn);

    }

    private void DataGridColRowClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            int row = e.RowIndex;
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                _right_isEditMode = true;
                _right_editingIndex = row;
                SetGrenadeFormValue(grenadeList[row]);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                grenadeList.RemoveAt(row);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void NewAutomaticButtonClick (object sender, EventArgs e)
    {
        _left_isEditMode = false;
        _left_editingIndex = -1;
        ClearLeftForm();
    }

    private void Automatic_Delete(object sender, EventArgs e)
    {
        try
        {
            if (_left_isEditMode) automaticList.RemoveAt(_left_editingIndex);
        }
        catch { }
        finally
        {
            _left_isEditMode = false;
            _left_editingIndex = -1;
            ClearLeftForm();
        }
    }
}
