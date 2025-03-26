using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace Automobile_Database
{
    public partial class Form1 : Form
    {
        private DataTable originalDataTable;
        public Form1()
        {
            InitializeComponent();
            LoadDataAndPlot();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\elcom\Downloads\Automobile_data.csv";

            // Verificar si el archivo existe
            if (File.Exists(filePath))
            {
                // Leer el archivo CSV
                originalDataTable = ReadCsv(filePath);

                // Asignar el DataTable al DataGridView
                dgvAutos.DataSource = originalDataTable;
            }
            else
            {
                MessageBox.Show("El archivo CSV no existe.");
            }

            // Asignar el evento TextChanged al TextBox
            txtFilter.TextChanged += txtFilter_TextChanged;
        }

        private DataTable ReadCsv(string filePath)
        {
            DataTable dataTable = new DataTable();

            // Leer todas las líneas del archivo CSV
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length > 0)
            {
                // Obtener los nombres de las columnas desde la primera línea
                string[] columnNames = lines[0].Split(',');

                // Agregar las columnas al DataTable
                foreach (string columnName in columnNames)
                {
                    dataTable.Columns.Add(columnName);
                }

                // Agregar las filas al DataTable
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] rowValues = lines[i].Split(',');
                    DataRow row = dataTable.NewRow();
                    for (int j = 0; j < columnNames.Length; j++)
                    {
                        row[j] = rowValues[j];
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            // Verificar si originalDataTable está inicializado
            if (originalDataTable == null)
            {
                MessageBox.Show("Los datos no se han cargado correctamente.");
                return;
            }

            // Obtener el valor del TextBox
            string marca = txtFilter.Text.Trim();

            // Crear una vista filtrada del DataTable
            DataView dv = originalDataTable.DefaultView;

            // Filtrar los datos
            if (!string.IsNullOrEmpty(marca))
            {
                dv.RowFilter = $"make LIKE '%{marca}%'"; // Filtra por coincidencia parcial en la columna "make"
            }
            else
            {
                dv.RowFilter = ""; // Eliminar el filtro
            }

            // Asignar la vista filtrada al DataGridView
            dgvAutos.DataSource = dv.ToTable();
            LoadDataAndPlot(dv.ToTable());
        }

        private void LoadDataAndPlot(DataTable filteredDataTable = null)
        {
            // Si no se proporciona un DataTable filtrado, usar el original
            DataTable dataTable = filteredDataTable ?? originalDataTable;

            // Si dataTable es null, simplemente retornar sin mostrar mensaje
            if (dataTable == null)
            {
                return;
            }

            // Si el DataTable está vacío, retornar sin mostrar mensaje
            if (dataTable.Rows.Count == 0)
            {
                return;
            }

            // Diccionario para contar la frecuencia de cada tipo de combustible
            var fuelTypeCounts = new Dictionary<string, int>();

            // Recorrer las filas del DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                // Verificar si la fila tiene datos en la columna 3 (índice 3)
                if (row[3] != null && !string.IsNullOrEmpty(row[3].ToString()))
                {
                    string fuelType = row[3].ToString();

                    // Contar la frecuencia de cada tipo de combustible
                    if (fuelTypeCounts.ContainsKey(fuelType))
                    {
                        fuelTypeCounts[fuelType]++;
                    }
                    else
                    {
                        fuelTypeCounts[fuelType] = 1;
                    }
                }
            }

            // Si no hay datos para graficar, retornar sin mostrar mensaje
            if (fuelTypeCounts.Count == 0)
            {
                return;
            }

            // Preparar los datos para la gráfica de pie
            var labels = fuelTypeCounts.Keys.ToArray();
            var values = fuelTypeCounts.Values.Select(v => (double)v).ToArray();

            // Limpiar la gráfica anterior
            plotFuelType.Plot.Clear();



            // Agregar la nueva gráfica de pie
            var pie = plotFuelType.Plot.Add.Pie(values);

            double total = pie.Slices.Select(x => x.Value).Sum();
            double[] percentages = pie.Slices.Select(x => x.Value / total * 100).ToArray();

            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].Label = $"{percentages[i]:0.0}%";
                pie.Slices[i].LabelFontSize = 20;
                pie.Slices[i].LabelBold = true;
                pie.Slices[i].LabelFontColor = Colors.Black.WithAlpha(.5);
            }

            plotFuelType.Plot.Axes.Frameless();
            plotFuelType.Plot.HideGrid();
            // Renderizar la gráfica
            plotFuelType.Refresh();
        }
    }
}
