using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateWorking(false);
        }

        private void UpdateWorking(bool working)
        {
            lblWorking.Text = working ? "Working" : "Idle";
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            UpdateWorking(true);
            Thread.Sleep(2000);
            UpdateWorking(false);
        }

        private async void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                UpdateWorking(true);
                var result = await GetData().ConfigureAwait(false);
                MessageBox.Show(result.Content.Length.ToString());
                UpdateWorking(false);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                UpdateWorking(false);
            }
        }

        private Task<IRestResponse> GetData()
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("api/users", Method.GET);
            return client.ExecuteAsync(request);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var awaiter = new ContextAwaiter();
                UpdateWorking(true);
                var result = await GetData().ConfigureAwait(false);
                await awaiter;
                MessageBox.Show(result.Content.Length.ToString());
                UpdateWorking(false);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                UpdateWorking(false);
            }
        }
    }
}