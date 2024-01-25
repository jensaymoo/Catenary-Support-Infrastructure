using CatenarySupport.Database.Tables;
using CatenarySupport.Providers;
using LinqToDB;


namespace CatenarySupport
{
    public partial class MainForm : Form
    {
        private readonly IProvider<PillarData> PillarsProvider;
        public MainForm(IProvider<PillarData> provider)
        {
            PillarsProvider = provider;

            PillarsProvider.Add(new PillarData() { PillarUUID = Guid.NewGuid() });

            InitializeComponent();
        }
    }
}
