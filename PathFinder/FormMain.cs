namespace PathFinder
{
	using PathFinder.Data;
	using System;
	using System.Collections;
	using System.Linq;
	using System.Windows.Forms;

	partial class FormMain : Form
	{
		internal delegate void SetupComboDataSource(ComboBox targetCombo, IList city);
		private SetupComboDataSource addComboDataSource;

		public FormMain()
		{
			InitializeComponent();

			addComboDataSource = new SetupComboDataSource((targetCombo, citySource) =>
			{
				targetCombo.DataSource = citySource;
				targetCombo.DisplayMember = "Title";
				targetCombo.ValueMember = "Id";
			});
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback((combos) =>
			{
				object[] oList = (object[])combos;
				XmlSource s = new XmlSource("data.xml");
				var cities = s.GetCities();

				if (InvokeRequired)
				{
					foreach (var control in oList)
					{
						Invoke(addComboDataSource, (ComboBox)control, cities.ToList());
					}
				}
			}), new[] { cmbFrom, cmbTo });

		}

		private void btRun_Click(object sender, EventArgs e)
		{
			var pf = new Finder(new XmlSource("data.xml"));

			pf.OnSuccess += (message) => {
				txtLog.Text += message + "\r\n";
			};

			pf.OnError += (message) =>
			{
				txtLog.Text += message + "\r\n";
			};

			pf.Find(Convert.ToInt32(cmbFrom.SelectedValue), Convert.ToInt32(cmbTo.SelectedValue));
		}
	}
}
