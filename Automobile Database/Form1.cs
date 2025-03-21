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
            string filePath = @"C:\Users\TecNM\Downloads\Automobile_data.csv";

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

            // Leer todas las l�neas del archivo CSV
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length > 0)
            {
                // Obtener los nombres de las columnas desde la primera l�nea
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
            // Verificar si originalDataTable est� inicializado
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

        //private void LoadDataAndPlot()
        //{
        //    // Ruta al archivo CSV
        //    string filePath = @"C:\Users\TecNM\Downloads\Automobile_data.csv";

        //    // Diccionario para contar la frecuencia de cada tipo de combustible
        //    var fuelTypeCounts = new Dictionary<string, int>();

        //    // Leer el archivo CSV
        //    using (var reader = new StreamReader(filePath))
        //    {
        //        // Saltar la primera l�nea (encabezados)
        //        reader.ReadLine();

        //        while (!reader.EndOfStream)
        //        {
        //            var line = reader.ReadLine();
        //            var valores = line.Split(',');

        //            // Obtener el tipo de combustible (columna 3)
        //            string fuelType = valores[3];

        //            // Contar la frecuencia de cada tipo de combustible
        //            if (fuelTypeCounts.ContainsKey(fuelType))
        //            {
        //                fuelTypeCounts[fuelType]++;
        //            }
        //            else
        //            {
        //                fuelTypeCounts[fuelType] = 1;
        //            }
        //        }
        //    }

        //    // Preparar los datos para la gr�fica de pie
        //    var labels = fuelTypeCounts.Keys.ToArray();
        //    var values = fuelTypeCounts.Values.Select(v => (double)v).ToArray();

        //    var pie = plotFuelType.Plot.Add.Pie(values);
        //}

        private void LoadDataAndPlot(DataTable filteredDataTable = null)
        {
            // Si no se proporciona un DataTable filtrado, usar el original
            DataTable dataTable = filteredDataTable ?? originalDataTable;

            // Diccionario para contar la frecuencia de cada tipo de combustible
            var fuelTypeCounts = new Dictionary<string, int>();

            // Recorrer las filas del DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                // Obtener el tipo de combustible (columna 3)
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

            // Preparar los datos para la gr�fica de pie
            var labels = fuelTypeCounts.Keys.ToArray();
            var values = fuelTypeCounts.Values.Select(v => (double)v).ToArray();

            // Limpiar la gr�fica anterior
            plotFuelType.Plot.Clear();

            // Agregar la nueva gr�fica de pie
            var pie = plotFuelType.Plot.Add.Pie(values);
            //pie.Labels = labels;

            // Renderizar la gr�fica
            plotFuelType.Refresh();
        }
    }
}
