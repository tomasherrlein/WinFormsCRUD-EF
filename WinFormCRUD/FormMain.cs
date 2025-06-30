using ApplicationBusiness;
using Data;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormCRUD
{
    public partial class FormMain : Form
    {
        private IRepository<Investigador> _repository;
        private IServiceProvider _serviceProvider;

        public FormMain(IRepository<Investigador> repository, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _repository = repository;
            _serviceProvider = serviceProvider;
        }

        private async void FormMain_LoadAsync(object sender, EventArgs e)
        {
            var investigadores = await _repository.GetAllAsync();
            dataGridView1.DataSource = investigadores;
        }
    }
}
